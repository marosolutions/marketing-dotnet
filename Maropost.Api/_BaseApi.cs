using Maropost.Api.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maropost.Api
{
    public abstract class _BaseApi
    {
        protected int AccountId { get; }
        protected string AuthToken { get; }
        protected string UrlPathRoot { get; }

        public _BaseApi(int accountId, string authToken, string urlPathRoot)
        {
            AccountId = accountId;
            AuthToken = authToken;
            UrlPathRoot = urlPathRoot;
        }

        /// <summary>
        /// </summary>
        /// <remarks>We use IEnumerable instead of Dictionary, because Dictionary builds hash table and enforces unique key, which may or may not be desirable.</remarks>
        public IOperationResult<dynamic> Get(string resource, IEnumerable<KeyValuePair<string, string>> querystringParams = null, string overrideUrlPathRoot = null)
        {
            var url = new StringBuilder("");

            // build the httpClient, and setup everything, for an http GET operation.
            // See the "_get" function at
            // https://github.com/marosolutions/marketing-php/blob/master/src/Abstractions/Api.php

            try
            {
                // the only thing in here should be the actual http GET execution.
            }
            catch (Exception e)
            {
                return new OperationResult<dynamic>(null, e);
            }

            var responseBody = (dynamic)null; // Json.Deserialize( httpClient.Response.Body )

            return new OperationResult<dynamic>(responseBody);
        }
    }
}
