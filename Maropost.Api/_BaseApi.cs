using Maropost.Api.Dto;
using Maropost.Api.Helpers;
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
        protected string UrlPathRoot { get; set; }
        protected HttpClient HttpClient { get; }
        protected string BaseUrl { get; }

        public _BaseApi(int accountId, string authToken, string urlPathRoot, HttpClient httpClient, string baseUrl = null)
        {
            AccountId = accountId;
            AuthToken = authToken;
            UrlPathRoot = urlPathRoot;
            HttpClient = httpClient;
            BaseUrl = baseUrl;
        }

        private string GetUrl(string resource = null, string overrideResource = null)
        {
            string url = string.IsNullOrEmpty(BaseUrl) ? $"https://api.maropost.com/accounts/{AccountId}/" : string.Format(BaseUrl, AccountId);
            if (string.IsNullOrEmpty(overrideResource))
            {
                url += string.IsNullOrEmpty(UrlPathRoot) ? "" : $"{UrlPathRoot}";
                url += string.IsNullOrEmpty(resource) ? "" : $"/{resource}";
            }
            else
            {
                url += overrideResource;
                url += string.IsNullOrEmpty(resource) ? "" : $"/{resource}";
            }
            return url;
        }

        private string GetQueryString(IEnumerable<KeyValuePair<string, object>> keyValuePairs)
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
        protected IOperationResult<dynamic> Get(string resource, IEnumerable<KeyValuePair<string, object>> querystringParams = null, string overrideUrlPathRoot = null)
        {
            var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            dynamic responseBody;
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = HttpClient.SendAsync(request).Result;
                var data = apiResponse.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody, apiResponse, "");
        }

        protected IOperationResult<dynamic> Post(string resource, IEnumerable<KeyValuePair<string, object>> querystringParams = null, object obj = null, string overrideUrlPathRoot = null)
        {
            dynamic responseBody = null;
            var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = HttpClient.SendAsync(request).Result;
                var data = apiResponse.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody, apiResponse, "");
        }

        protected IOperationResult<dynamic> Put(string resource, IEnumerable<KeyValuePair<string, object>> querystringParams = null, object obj = null, string overrideUrlPathRoot = null)
        {
            dynamic responseBody = null;
            var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = HttpClient.SendAsync(request).Result;
                var data = apiResponse.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody, apiResponse, "");
        }

        protected IOperationResult<dynamic> Delete(string resource, IEnumerable<KeyValuePair<string, object>> querystringParams = null, object obj = null, string overrideUrlPathRoot = null)
        {
            dynamic responseBody = null;
            var url = $"{GetUrl(resource, overrideUrlPathRoot)}.json{GetQueryString(querystringParams)}";
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = HttpClient.SendAsync(request).Result;
                var data = apiResponse.Content.ReadAsStringAsync().Result;
                responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody, apiResponse, "");
        }
    }
}
