using System;

namespace Maropost.Api
{
    public abstract class _BaseApi
    {
        protected string AccountId { get; }
        protected string AuthToken { get; }
        protected string UrlPathRoot { get; }

        public _BaseApi(string accountId, string authToken, string urlPathRoot)
        {
            AccountId = accountId;
            AuthToken = authToken;
            UrlPathRoot = urlPathRoot;
        }
    }
}
