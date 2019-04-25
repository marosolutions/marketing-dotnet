using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class TransactionalCampaignsTests : _BaseTests
    {
        private const string SEND_RECIPIENT = "";
        private const string SEND_RECIPIENT_FIRST_NAME = "";
        private const string SEND_RECIPIENT_LAST_NAME = "";
        private const string SEND_SENDER_NAME = "user-test sender";
        private const string SEND_SENDER_EMAIL = "info@maropost.com";
        private const string SEND_SENDER_REPLYTO = "noreply@maropost.com";
        private const int SEND_CONTENT_ID = 162;
        private const int SEND_CAMPAIGN_ID = 0;

        [Fact]
        public void Get()
        {
            //Arrange
            var api = new TransactionalCampaigns(AccountId, AuthToken, HttpClient);
            //Act
            var result = api.Get(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(AccountId, accountId);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            var api = new TransactionalCampaigns(AccountId, AuthToken, HttpClient);
            string campaignName = $"unitTest_name_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            //Act
            var result = api.Create(campaignName, "unitTest_subject", "unitTest_preheader", SEND_SENDER_NAME, SEND_SENDER_EMAIL, SEND_SENDER_REPLYTO, SEND_CONTENT_ID, false, "32 Koteshowr, Kathmandu, Nepal", "en", new[] { "tag1", "tag2" });
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            string resultName = result.ResultData["name"];
            int accountId = result.ResultData["account_id"];
            Assert.Equal(AccountId, accountId);
            Assert.Equal(campaignName, resultName);
        }

        [Fact]
        public void SendEmail()
        {

        }
    }
}
