using System;
using System.Net.Http;
using Maropost.Api;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class CampaignsTests : _BaseTests
    {
        [Fact]
        public void Get()
        {
            // Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            // Act
            var result = api.Get(1);
            // Assert
            int accountId = result.ResultData[0]["account_id"];
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetCampaign_ValidId()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var getResult = api.Get(1);
            int campaignId = getResult.ResultData[0]["id"];
            //Act
            var result = api.GetCampaign(campaignId);
            //Assert
            int id = result.ResultData["id"];
            int accountId = result.ResultData["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["bounced"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetBounceReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetClickReports_UniqueTrue()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetClickReports(campaignId, 1, true);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetClickReports_UniqueFalse()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetClickReports(campaignId, 1, false);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetClickReports_UniqueNull()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetClickReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetComplaintReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["complaint"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetComplaintReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetDeliveredReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["delivered"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetDeliveredReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetHardBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["hard_bounced"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetHardBounceReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetLinkReports_UniqueTrue()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 0)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetLinkReports(campaignId, 1, true);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            string url = result.ResultData[0]["url"];
            Assert.Equal(id, campaignId);
            Assert.NotEmpty(url);
        }

        [Fact]
        public void GetLinkReports_UniqueFalse()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 0)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetLinkReports(campaignId, 1, false);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            string url = result.ResultData[0]["url"];
            Assert.Equal(id, campaignId);
            Assert.NotEmpty(url);
        }

        [Fact]
        public void GetLinkReports_UniqueNull()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 0)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetLinkReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            string url = result.ResultData[0]["url"];
            Assert.Equal(id, campaignId);
            Assert.NotEmpty(url);
        }

        [Fact]
        public void GetOpenReports_UniqueTrue()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["opened"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetOpenReports(campaignId, 1, true);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetOpenReports_UniqueFalse()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["opened"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetOpenReports(campaignId, 1, false);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetOpenReports_UniqueNull()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["opened"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetOpenReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetSoftBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["soft_bounced"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetSoftBounceReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetUnsubscribeReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["unsubscribed"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = api.GetUnsubscribeReports(campaignId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0);
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }
    }
}
