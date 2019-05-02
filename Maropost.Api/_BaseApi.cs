using Maropost.Api.Dto;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Constructor of _BaseAPI
        /// </summary>
        /// <param name="accountId">account id of account currently using api</param>
        /// <param name="authToken">authentication token of account</param>
        /// <param name="urlPathRoot">url path to be appended on base url</param>
        /// <param name="httpClient">http client object</param>
        /// <param name="baseUrl">base url to be override that user wants to be used as</param>
        /// <exception cref="ArgumentException" />
        public _BaseApi(int accountId, string authToken, string urlPathRoot, HttpClient httpClient, string baseUrl = null)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentException("authToken must be provided.");
            }
            if (accountId <= 0)
            {
                throw new ArgumentException("accountId must be greater than 0.");
            }

            AccountId = accountId;
            AuthToken = authToken;
            UrlPathRoot = urlPathRoot;
            HttpClient = httpClient ?? throw new ArgumentException("httpClient must be non-null.");
            BaseUrl = baseUrl;
        }
        /// <summary>
        /// Generate url from provided override resource and resource
        /// base url is changed if base url is provided else it uses default url
        /// </summary>
        /// <param name="resource">resource to be used</param>
        /// <param name="overrideResource">part of the url to be override when provided</param>
        /// <returns></returns>
        private string GetUrl(string resource = null, string overrideResource = null)
        {
            string url = string.IsNullOrEmpty(BaseUrl) ? $"https://api.maropost.com/accounts/{AccountId}/" : string.Format(BaseUrl, AccountId);
            if (string.IsNullOrEmpty(overrideResource))
            {
                url += string.IsNullOrEmpty(UrlPathRoot) ? "" : UrlPathRoot;
                url += string.IsNullOrEmpty(resource) ? "" : $"/{resource}";
            }
            else
            {
                url += overrideResource;
                url += string.IsNullOrEmpty(resource) ? "" : $"/{resource}";
            }
            return url;
        }
        /// <summary>
        /// Generate query string from provided key value pair
        /// </summary>
        /// <param name="keyValuePairs">collection of key value pair</param>
        /// <returns></returns>
        private string GetQueryString(IEnumerable<KeyValuePair<string, object>> keyValuePairs)
        {
            string queryStr = string.IsNullOrEmpty(AuthToken) ? "" : $"?auth_token={AuthToken}";
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
        /// Gets data from provided url and request params
        /// </summary>
        /// <param name="resource">resource i.e. used to append on url</param>
        /// <param name="querystringParams">query stirng params key value pair data i.e used as query string appended in url</param>
        /// <param name="overrideUrlPathRoot">override url path to be appended on base url if provided before resource and query string</param>
        /// <returns></returns>
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
        /// <summary>
        /// Post and execute requested operation
        /// </summary>
        /// <param name="resource">resource i.e. used to append on url</param>
        /// <param name="querystringParams">query stirng params key value pair data i.e used as query string appended in url</param>
        /// <param name="obj">object to used as request body</param>
        /// <param name="overrideUrlPathRoot">override url path to be appended on base url if provided before resource and query string</param>
        /// <returns></returns>
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
        /// <summary>
        /// Executes put operation for request url path
        /// </summary>
        /// <param name="resource">resource i.e. used to append on url</param>
        /// <param name="querystringParams">query stirng params key value pair data i.e used as query string appended in url</param>
        /// <param name="obj">object to used as request body</param>
        /// <param name="overrideUrlPathRoot">override url path to be appended on base url if provided before resource and query string</param>
        /// <returns></returns>
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
                try
                {
                    responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                }
                catch
                {
                    responseBody = data;
                }
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody, apiResponse, "");
        }
        /// <summary>
        /// Executes delete operation as requested
        /// </summary>
        /// <param name="resource">resource i.e. used to append on url</param>
        /// <param name="querystringParams">query stirng params key value pair data i.e used as query string appended in url</param>
        /// <param name="obj">object to used as request body</param>
        /// <param name="overrideUrlPathRoot">override url path to be appended on base url if provided before resource and query string</param>
        /// <returns></returns>
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
                try
                {
                    responseBody = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                }
                catch
                {
                    responseBody = data;
                }
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }
            return new OperationResult<dynamic>(responseBody, apiResponse, "");
        }
    }
}
