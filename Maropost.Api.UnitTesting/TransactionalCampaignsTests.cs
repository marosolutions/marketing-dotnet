﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class TransactionalCampaignsTests : _BaseTests
    {
        private const string SEND_RECIPIENT = "test@maropost.com";
        private const string SEND_RECIPIENT_FIRST_NAME = "test_receiverFN";
        private const string SEND_RECIPIENT_LAST_NAME = "test_receiverLN";
        private const string SEND_SENDER_NAME = "user-test sender";
        private const string SEND_SENDER_EMAIL = "info@maropost.com";
        private const string SEND_SENDER_REPLYTO = "noreply@maropost.com";
        private const int SEND_CONTENT_ID = 150;
        private const int SEND_CAMPAIGN_ID = 4961;

        [Fact]
        public async Task Get()
        {
            //Arrange
            var api = new TransactionalCampaigns(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.Get(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(AccountId, accountId);
        }

        [Fact]
        public async Task Create()
        {
            //Arrange
            var api = new TransactionalCampaigns(AccountId, AuthToken, HttpClient);
            string campaignName = $"unitTest_name_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            //Act
            var result = await api.Create(campaignName, "unitTest_subject", "unitTest_preheader", SEND_SENDER_NAME, SEND_SENDER_EMAIL, SEND_SENDER_REPLYTO, SEND_CONTENT_ID, false, "32 Koteshowr, Kathmandu, Nepal", "en", new[] { "tag1", "tag2" });
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
        public async Task SendEmail()
        {
            //Arrange
            var api = new TransactionalCampaigns(AccountId, AuthToken, HttpClient);
            var resultGet = await api.Get(1);
            var transactionCampaignId = (int)resultGet.ResultData[0].id;
            var contentId = (int)resultGet.ResultData[0].content_id;

            var customFields = new Dictionary<string, object>
            {
                { "city", "San Luis Obispo" },
                { "state", "California" }
            };
            var tags = new Dictionary<string, object>
            {
                { "field1", "value1" },
                { "field2", "value2" }
            };
            //Act
            var result = await api.SendEmail(transactionCampaignId, contentId, "test content", "<h2>Custom HTML</h2>", "Test Content Text",
                                       null, null, true, 1, SEND_RECIPIENT, SEND_RECIPIENT_FIRST_NAME, SEND_RECIPIENT_LAST_NAME,
                                       customFields, null, SEND_SENDER_NAME, SEND_SENDER_REPLYTO, "Test Subject", SEND_SENDER_EMAIL,
                                       "Test Sender Address", tags, new[] { "ctag1", "ctag2" });
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }

        [Fact]
        public async Task SendEmail_BothContentIdContentFields()
        {
            //Arrange
            var api = new TransactionalCampaigns(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.SendEmail(SEND_CAMPAIGN_ID, 162, "test content", null, null, null, null, true, null, SEND_RECIPIENT, SEND_RECIPIENT_FIRST_NAME, SEND_RECIPIENT_LAST_NAME);
            //Assert
            Assert.False(result.Success);
            Assert.False(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }
    }
}
