//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System.Threading.Tasks;
using System.Collections.Generic;
using Unity.Services.Ccd.Management.Models;
using Unity.Services.Ccd.Management.Http;
using Unity.Services.Ccd.Management.Permissions;

namespace Unity.Services.Ccd.Management.Apis.Permissions
{
    /// <summary>
    /// Interface for the PermissionsApiClient
    /// </summary>
    internal interface IPermissionsApiClient
    {
            /// <summary>
            /// Async Operation.
            /// Create a permission.
            /// </summary>
            /// <param name="request">Request object for CreatePermissionByBucket.</param>
            /// <param name="operationConfiguration">Configuration for CreatePermissionByBucket.</param>
            /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<CcdPermission>> CreatePermissionByBucketAsync(Unity.Services.Ccd.Management.Permissions.CreatePermissionByBucketRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Create a permission.
            /// </summary>
            /// <param name="request">Request object for CreatePermissionByBucketEnv.</param>
            /// <param name="operationConfiguration">Configuration for CreatePermissionByBucketEnv.</param>
            /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<CcdPermission>> CreatePermissionByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.CreatePermissionByBucketEnvRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// delete a permission.
            /// </summary>
            /// <param name="request">Request object for DeletePermissionByBucket.</param>
            /// <param name="operationConfiguration">Configuration for DeletePermissionByBucket.</param>
            /// <returns>Task for a Response object containing status code, headers.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response> DeletePermissionByBucketAsync(Unity.Services.Ccd.Management.Permissions.DeletePermissionByBucketRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// delete a permission.
            /// </summary>
            /// <param name="request">Request object for DeletePermissionByBucketEnv.</param>
            /// <param name="operationConfiguration">Configuration for DeletePermissionByBucketEnv.</param>
            /// <returns>Task for a Response object containing status code, headers.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response> DeletePermissionByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.DeletePermissionByBucketEnvRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Get permissions for bucket.
            /// </summary>
            /// <param name="request">Request object for GetAllByBucket.</param>
            /// <param name="operationConfiguration">Configuration for GetAllByBucket.</param>
            /// <returns>Task for a Response object containing status code, headers, and List&lt;CcdPermission&gt; object.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<List<CcdPermission>>> GetAllByBucketAsync(Unity.Services.Ccd.Management.Permissions.GetAllByBucketRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Get permissions for bucket.
            /// </summary>
            /// <param name="request">Request object for GetAllByBucketEnv.</param>
            /// <param name="operationConfiguration">Configuration for GetAllByBucketEnv.</param>
            /// <returns>Task for a Response object containing status code, headers, and List&lt;CcdPermission&gt; object.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<List<CcdPermission>>> GetAllByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.GetAllByBucketEnvRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Update a permission.
            /// </summary>
            /// <param name="request">Request object for UpdatePermissionByBucket.</param>
            /// <param name="operationConfiguration">Configuration for UpdatePermissionByBucket.</param>
            /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<CcdPermission>> UpdatePermissionByBucketAsync(Unity.Services.Ccd.Management.Permissions.UpdatePermissionByBucketRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Update a permission.
            /// </summary>
            /// <param name="request">Request object for UpdatePermissionByBucketEnv.</param>
            /// <param name="operationConfiguration">Configuration for UpdatePermissionByBucketEnv.</param>
            /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
            /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<CcdPermission>> UpdatePermissionByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.UpdatePermissionByBucketEnvRequest request, Configuration operationConfiguration = null);

    }

    ///<inheritdoc cref="IPermissionsApiClient"/>
    internal class PermissionsApiClient : BaseApiClient, IPermissionsApiClient
    {
        private const int _baseTimeout = 10;
        private Configuration _configuration;
        /// <summary>
        /// Accessor for the client configuration object. This returns a merge
        /// between the current configuration and the global configuration to
        /// ensure the correct combination of headers and a base path (if it is
        /// set) are returned.
        /// </summary>
        public Configuration Configuration
        {
            get {
                // We return a merge between the current configuration and the
                // global configuration to ensure we have the correct
                // combination of headers and a base path (if it is set).
                Configuration globalConfiguration = new Configuration("https://services.unity.com", 10, 4, null);
                return Configuration.MergeConfigurations(_configuration, globalConfiguration);
            }
            set { _configuration = value; }
        }

        /// <summary>
        /// PermissionsApiClient Constructor.
        /// </summary>
        /// <param name="httpClient">The HttpClient for PermissionsApiClient.</param>
        /// <param name="configuration"> PermissionsApiClient Configuration object.</param>
        public PermissionsApiClient(IHttpClient httpClient,
            Configuration configuration = null) : base(httpClient)
        {
            // We don't need to worry about the configuration being null at
            // this stage, we will check this in the accessor.
            _configuration = configuration;

            
        }


        /// <summary>
        /// Async Operation.
        /// Create a permission.
        /// </summary>
        /// <param name="request">Request object for CreatePermissionByBucket.</param>
        /// <param name="operationConfiguration">Configuration for CreatePermissionByBucket.</param>
        /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<CcdPermission>> CreatePermissionByBucketAsync(Unity.Services.Ccd.Management.Permissions.CreatePermissionByBucketRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(CcdPermission)   },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("POST",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            var handledResponse = ResponseHandler.HandleAsyncResponse<CcdPermission>(response, statusCodeToTypeMap);
            return new Response<CcdPermission>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Create a permission.
        /// </summary>
        /// <param name="request">Request object for CreatePermissionByBucketEnv.</param>
        /// <param name="operationConfiguration">Configuration for CreatePermissionByBucketEnv.</param>
        /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<CcdPermission>> CreatePermissionByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.CreatePermissionByBucketEnvRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(CcdPermission)   },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("POST",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            var handledResponse = ResponseHandler.HandleAsyncResponse<CcdPermission>(response, statusCodeToTypeMap);
            return new Response<CcdPermission>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// delete a permission.
        /// </summary>
        /// <param name="request">Request object for DeletePermissionByBucket.</param>
        /// <param name="operationConfiguration">Configuration for DeletePermissionByBucket.</param>
        /// <returns>Task for a Response object containing status code, headers.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response> DeletePermissionByBucketAsync(Unity.Services.Ccd.Management.Permissions.DeletePermissionByBucketRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"204",  null },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("DELETE",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            ResponseHandler.HandleAsyncResponse(response, statusCodeToTypeMap);
            return new Response(response);
        }


        /// <summary>
        /// Async Operation.
        /// delete a permission.
        /// </summary>
        /// <param name="request">Request object for DeletePermissionByBucketEnv.</param>
        /// <param name="operationConfiguration">Configuration for DeletePermissionByBucketEnv.</param>
        /// <returns>Task for a Response object containing status code, headers.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response> DeletePermissionByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.DeletePermissionByBucketEnvRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"204",  null },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("DELETE",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            ResponseHandler.HandleAsyncResponse(response, statusCodeToTypeMap);
            return new Response(response);
        }


        /// <summary>
        /// Async Operation.
        /// Get permissions for bucket.
        /// </summary>
        /// <param name="request">Request object for GetAllByBucket.</param>
        /// <param name="operationConfiguration">Configuration for GetAllByBucket.</param>
        /// <returns>Task for a Response object containing status code, headers, and List&lt;CcdPermission&gt; object.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<List<CcdPermission>>> GetAllByBucketAsync(Unity.Services.Ccd.Management.Permissions.GetAllByBucketRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(List<CcdPermission>)   },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            var handledResponse = ResponseHandler.HandleAsyncResponse<List<CcdPermission>>(response, statusCodeToTypeMap);
            return new Response<List<CcdPermission>>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Get permissions for bucket.
        /// </summary>
        /// <param name="request">Request object for GetAllByBucketEnv.</param>
        /// <param name="operationConfiguration">Configuration for GetAllByBucketEnv.</param>
        /// <returns>Task for a Response object containing status code, headers, and List&lt;CcdPermission&gt; object.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<List<CcdPermission>>> GetAllByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.GetAllByBucketEnvRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(List<CcdPermission>)   },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            var handledResponse = ResponseHandler.HandleAsyncResponse<List<CcdPermission>>(response, statusCodeToTypeMap);
            return new Response<List<CcdPermission>>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Update a permission.
        /// </summary>
        /// <param name="request">Request object for UpdatePermissionByBucket.</param>
        /// <param name="operationConfiguration">Configuration for UpdatePermissionByBucket.</param>
        /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<CcdPermission>> UpdatePermissionByBucketAsync(Unity.Services.Ccd.Management.Permissions.UpdatePermissionByBucketRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(CcdPermission)   },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("PUT",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            var handledResponse = ResponseHandler.HandleAsyncResponse<CcdPermission>(response, statusCodeToTypeMap);
            return new Response<CcdPermission>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Update a permission.
        /// </summary>
        /// <param name="request">Request object for UpdatePermissionByBucketEnv.</param>
        /// <param name="operationConfiguration">Configuration for UpdatePermissionByBucketEnv.</param>
        /// <returns>Task for a Response object containing status code, headers, and CcdPermission object.</returns>
        /// <exception cref="Unity.Services.Ccd.Management.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<CcdPermission>> UpdatePermissionByBucketEnvAsync(Unity.Services.Ccd.Management.Permissions.UpdatePermissionByBucketEnvRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(CcdPermission)   },{"400", typeof(InlineResponse400)   },{"401", typeof(InlineResponse401)   },{"403", typeof(InlineResponse403)   },{"404", typeof(InlineResponse404)   },{"429", typeof(InlineResponse429)   },{"500", typeof(InlineResponse500)   },{"503", typeof(InlineResponse503)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("PUT",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout,
                finalConfiguration.RetryPolicyConfiguration,
                finalConfiguration.StatusCodePolicyConfiguration);

            var handledResponse = ResponseHandler.HandleAsyncResponse<CcdPermission>(response, statusCodeToTypeMap);
            return new Response<CcdPermission>(response, handledResponse);
        }

    }
}
