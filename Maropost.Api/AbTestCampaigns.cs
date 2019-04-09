using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Maropost.Api
{
    public class AbTestCampaigns : _BaseApi
    {
        public AbTestCampaigns(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "campaigns", httpClient)
        { }
    }
}
