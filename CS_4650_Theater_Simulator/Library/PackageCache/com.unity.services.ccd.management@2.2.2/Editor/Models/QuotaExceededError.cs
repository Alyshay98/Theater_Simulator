//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Ccd.Management.Http;



namespace Unity.Services.Ccd.Management.Models
{
    /// <summary>
    /// QuotaExceededError model
    /// </summary>
    [Preserve]
    [DataContract(Name = "QuotaExceededError")]
    public class QuotaExceededError
    {
        /// <summary>
        /// Creates an instance of QuotaExceededError.
        /// </summary>
        /// <param name="title">title param</param>
        /// <param name="status">status param</param>
        /// <param name="detail">detail param</param>
        [Preserve]
        public QuotaExceededError(string title = default, int status = default, string detail = default)
        {
            Title = title;
            Status = status;
            Detail = detail;
        }

        /// <summary>
        /// Parameter title of QuotaExceededError
        /// </summary>
        [Preserve]
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title{ get; }
        
        /// <summary>
        /// Parameter status of QuotaExceededError
        /// </summary>
        [Preserve]
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status{ get; }
        
        /// <summary>
        /// Parameter detail of QuotaExceededError
        /// </summary>
        [Preserve]
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public string Detail{ get; }
    
        /// <summary>
        /// Formats a QuotaExceededError into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Title != null)
            {
                serializedModel += "title," + Title + ",";
            }
            serializedModel += "status," + Status.ToString() + ",";
            if (Detail != null)
            {
                serializedModel += "detail," + Detail;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a QuotaExceededError as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Title != null)
            {
                var titleStringValue = Title.ToString();
                dictionary.Add("title", titleStringValue);
            }
            
            var statusStringValue = Status.ToString();
            dictionary.Add("status", statusStringValue);
            
            if (Detail != null)
            {
                var detailStringValue = Detail.ToString();
                dictionary.Add("detail", detailStringValue);
            }
            
            return dictionary;
        }
    }
}
