using System;
using System.Collections.Generic;
using System.Text;

namespace Maropost.Api
{
    public class AbTestCampaigns : _BaseApi
    {
        public AbTestCampaigns(int accountId, string authToken)
            : base(accountId, authToken, "campaigns")
        { }
    }
}
