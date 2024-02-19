using System;
using System.Threading.Tasks;
using Unity.Services.Ccd.Management.Http;

namespace Unity.Services.Ccd.Management.ErrorMitigation
{
    /// <summary>
    /// Retry Policy Provider class
    /// </summary>
    internal class RetryPolicyProvider : IRetryPolicyProvider
    {
        /// <summary>
        /// Constructs a RetryPolicy based on the passed in operations type.
        /// </summary>
        /// <param name="operation">The operation we are using.</param>
        /// <typeparam name="T">The type of the operation.</typeparam>
        /// <returns>A IRetryPolicy</returns>
        public IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation)
        {
            return RetryPolicy<T>.ForOperation(operation);
        }

        /// <summary>
        /// Constructs a RetryPolicy based on the passed in operations type
        /// without the number of retries.
        /// </summary>
        /// <param name="operation">The operation we are using.</param>
        /// <typeparam name="T">The type of the operation.</typeparam>
        /// <returns>A IRetryPolicy</returns>
        public IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation)
        {
            return RetryPolicy<T>.ForOperation(operation);
        }
    }

    /// <summary>
    /// Retry Policy class that defines how exponential backoff and retry
    /// behaviour should work. 
    /// </summary>
    /// <typeparam name="T">The type of the operation.</typeparam>
    internal class RetryPolicy<T> : IRetryPolicy<T>
    {
        private RetryPolicyConfig _retryPolicyConfig = new RetryPolicyConfig();
        private Func<int, Task<T>> CreateOperation { get; set; }
        private Func<T, Task<bool>> RetryCondition { get; set; }

        private RetryPolicy(Func<int, Task<T>> createAsyncOp)
        {
            CreateOperation = createAsyncOp;
        }

        private RetryPolicy(Func<Task<T>> createAsyncOp)
        {
            CreateOperation = (int _) => createAsyncOp.Invoke();
        }

        private static float AddJitter(float number, float magnitude)
        {
            return number + (UnityEngine.Random.value * magnitude);
        }

        private static float Pow2(float exponent, float scale)
        {
            return (float)(Math.Pow(2.0f, exponent) * scale);
        }

        private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale,
            float jitterMagnitude)
        {
            float delayTime = Pow2(attemptNumber, delayScale);
            delayTime = AddJitter(delayTime, jitterMagnitude);
            delayTime = Math.Min(delayTime, maxDelayTime);
            return delayTime;
        }

        /// <summary>
        /// Sets the Jitter Magnitude to help prevent a service from being
        /// overloaded with retry requests at regular intervals.
        /// </summary>
        /// <param name="magnitude">The magnitude to use, clamped between 0.001f and 1.0f.</param>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> WithJitterMagnitude(float magnitude)
        {
            _retryPolicyConfig.JitterMagnitude = magnitude;
            return this;
        }

        /// <summary>
        /// Sets a Delay Scale that is used to calculate the time between each retry.
        /// </summary>
        /// <param name="scale">The delay scale to use, clamped between 0.05f and 1.0f.</param>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> WithDelayScale(float scale)
        {
            _retryPolicyConfig.DelayScale = scale;
            return this;
        }

        /// <summary>
        /// Sets a Max Delay time between each retry.
        /// </summary>
        /// <param name="time">The maximum delay time, clamped between 100 milliseconds and 60 seconds.</param>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> WithMaxDelayTime(float time)
        {
            _retryPolicyConfig.MaxDelayTime = time;
            return this;
        }

        /// <summary>
        /// Constructs a RetryPolicy based on the passed in operations type.
        /// </summary>
        /// <param name="operation">
        /// The operation we are executing as a function that returns the type
        /// of operation as a `Task` and has an `int` parameter representing
        /// which retry attempt we are on.
        /// </param>
        /// <returns>A RetryPolicy{T}.</returns>
        public static RetryPolicy<T> ForOperation(Func<int, Task<T>> operation)
        {
            return new RetryPolicy<T>(operation);
        }

        /// <summary>
        /// Constructs a RetryPolicy based on the passed in operations type
        /// without the number of retries.
        /// </summary>
        /// <param name="operation">
        /// The operation we are executing as a function that returns the type
        /// of operation as a `Task` and has an `int` parameter representing
        /// which retry attempt we are on.
        /// </param>
        /// <returns>A RetryPolicy{T}.</returns>
        public static RetryPolicy<T> ForOperation(Func<Task<T>> operation)
        {
            return new RetryPolicy<T>(operation);
        }

        /// <summary>
        /// Sets a Retry Condition method that returns whether or not there
        /// should be another retry.
        /// </summary>
        /// <param name="shouldRetry">A function that takes a response and returns a bool.</param>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry)
        {
            RetryCondition = shouldRetry;
            return this;
        }

        /// <summary>
        /// Sets the maximum number of retries.
        /// </summary>
        /// <param name="amount">The max amount of retries.</param>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> UptoMaximumRetries(uint amount)
        {
            _retryPolicyConfig.MaxRetries = amount;
            return this;
        }

        /// <summary>
        /// Adds an exception type that, if thrown, should trigger a retry.
        /// </summary>
        /// <typeparam name="TException">The exception type to retry on.</typeparam>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> HandleException<TException>() where TException : Exception
        {
            _retryPolicyConfig.HandleException<TException>();
            return this;
        }

        /// <summary>
        /// Adds an exception type and a condition that, if thrown and the condition matches, should trigger a retry.
        /// </summary>
        /// <typeparam name="TException">The exception type to retry on.</typeparam>
        /// <param name="condition">A condition function for specifying additional behaviour when checking if we should retry with this exception type.</param>
        /// <returns>An IRetryPolicy{T}.</returns>
        public IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception
        {
            _retryPolicyConfig.HandleException<TException>(condition);
            return this;
        }

        /// <summary>
        /// Runs the specified operation async and will retry if the shouldRetry
        /// method returns true and the number of retries hasn't reached the
        /// maximum.
        /// </summary>
        /// <param name="retryPolicyConfig">The retry policy for this operation.</param>
        /// <returns>A Task{T}.</returns>
        public async Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null)
        {
            T opResult = default;

            // If we haven't specified a retryPolicyConfig for this operation,
            // use the one associated with the RetryPolicy.
            if (retryPolicyConfig == null)
            {
                retryPolicyConfig = _retryPolicyConfig;
            }

            for (var attempt = 0; attempt <= retryPolicyConfig.MaxRetries; ++attempt)
            {
                // Wrap the CreateOperation function with a task and await to
                // ensure the execution is returned to the scheduler.
                try
                {
                    opResult = await CreateOperation(attempt + 1);
                }
                catch (Exception e)
                {
                    // If we catch an exception, first check if it is one we are supposed to
                    // handle. If so, we can retry, otherwise, we should throw.                    
                    if (!retryPolicyConfig.IsHandledException(e))
                    {
                        // Rethrow the exception
                        throw;
                    }
                }
                
                // If RetryCondition is not null, invoke the RetryCondition and
                // check if the CreateOperation succeeded. Also check if
                // asyncOp is null, if it is that likely means we have thrown an
                // exception and should retry anyway.
                if (RetryCondition != null && opResult != null)
                {
                    bool shouldRetry = await RetryCondition(opResult);

                    if (!shouldRetry)
                    {
                        break;
                    }
                }
                else if (opResult != null)
                {
                    break;
                }

                var delayTime = CalculateDelay(attempt, retryPolicyConfig.MaxDelayTime, retryPolicyConfig.DelayScale, retryPolicyConfig.JitterMagnitude);
                await Task.Delay((int)(delayTime * 1000));
            }

            return opResult;
        }
    }
}
