using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Maropost.Api
{
    public class Campaigns : _BaseApi
    {
        public Campaigns(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "campaigns", httpClient)
        { }

        public IOperationResult<dynamic> Get(int page)
        {
            // qsParams would also work in place of the new KeyValueList used below.
            //var qsParams = new Dictionary<string, string>();
            //qsParams.Add("page", page.ToString());

            var result = Get(null, new KeyValueList { { "page", page.ToString() } });
            return result;
        }

        public IOperationResult<dynamic> GetCampain(int campaignId)
        {
            var result = base.Get(campaignId.ToString());
            return result;
        }
    }
}
