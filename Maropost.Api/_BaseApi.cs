using Maropost.Api.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Maropost.Api
{
    public abstract class _BaseApi
    {
        protected int AccountId { get; }
        protected string AuthToken { get; }
        protected string UrlPathRoot { get; }
        protected HttpClient HttpClient { get; }

        public _BaseApi(int accountId, string authToken, string urlPathRoot, HttpClient httpClient)
        {
            AccountId = accountId;
            AuthToken = authToken;
            UrlPathRoot = urlPathRoot;
            HttpClient = httpClient;
        }

        private string GetUrl(string resource = null, string overrideResource = null)
        {
            string url = $"https://api.maropost.com/accounts/{AccountId}/";
            if (string.IsNullOrEmpty(overrideResource))
            {
                url += string.IsNullOrEmpty(UrlPathRoot) ? "" : $"{UrlPathRoot}";
                url += string.IsNullOrEmpty(resource) ? "" : $"/{resource}";
            }
            else
            {
                url += overrideResource;
                url += string.IsNullOrEmpty(resource) ? $"/{resource}" : "";
            }
            return url;
        }

        private string GetQueryString(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            string queryStr = $"?auth_token={AuthToken}";
            if (keyValuePairs != null)
            {
                foreach (var keyValuePair in keyValuePairs)
                {
                    queryStr += $"&{keyValuePair.Key}={keyValuePair.Value}";
                }
            }
            queryStr = queryStr.Replace(' ', '+');
            return queryStr;
        }

        /// <summary>
        /// </summary>
        /// <remarks>We use IEnumerable instead of Dictionary, because Dictionary builds hash table and enforces unique key, which may or may not be desirable.</remarks>
        protected IOperationResult<dynamic> Get(string resource, IEnumerable<KeyValuePair<string, string>> querystringParams = null, string overrideUrlPathRoot = null)
        {
            // build the httpClient, and setup everything, for an http GET operation.
            // See the "_get" function at
            // https://github.com/marosolutions/marketing-php/blob/master/src/Abstractions/Api.php
            dynamic responseBody = null;
            try
            {
                // the only thing in here should be the actual http GET execution.
                var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = HttpClient.SendAsync(request).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody);
        }

        protected IOperationResult<dynamic> Post(string resource, IEnumerable<KeyValuePair<string, string>> querystringParams, object obj, string overrideUrlPathRoot = null)
        {
            dynamic responseBody = null;
            try
            {
                var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = HttpClient.SendAsync(request).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody);
        }

        protected IOperationResult<dynamic> Put(string resource, IEnumerable<KeyValuePair<string, string>> querystringParams, object obj, string overrideUrlPathRoot = null)
        {
            dynamic responseBody = null;
            try
            {
                var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = HttpClient.SendAsync(request).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody);
        }
    }
}
