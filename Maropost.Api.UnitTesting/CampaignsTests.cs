using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class CampaignsTests : _BaseTests
    {
        [Fact]
        public async Task Get()
        {
            // Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            // Act
            var result = await api.Get(1);
            // Assert
            int accountId = result.ResultData[0]["account_id"];
            Assert.NotNull(result);
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetCampaign_ValidId()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int campaignId = getResult.ResultData[0]["id"];
            //Act
            var result = await api.GetCampaign(campaignId);
            //Assert
            int id = result.ResultData["id"];
            int accountId = result.ResultData["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["bounced"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetBounceReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetClickReports_UniqueTrue()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                    break;
                }
            }
            //Act
            var result = await api.GetClickReports(campaignId, 1, true);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetClickReports_UniqueFalse()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                    break;
                }
            }
            //Act
            var result = await api.GetClickReports(campaignId, 1, false);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetClickReports_UniqueNull()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                    break;
                }
            }
            //Act
            var result = await api.GetClickReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetComplaintReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["complaint"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetComplaintReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetDeliveredReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["delivered"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetDeliveredReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetHardBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["hard_bounced"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                    break;
                }
            }
            if (campaignId > 0)
            {
                //Act
                var result = await api.GetHardBounceReports(campaignId, 1);
                //Assert
                Assert.True(result.Success, "result.Success is false");
                Assert.Null(result.ErrorMessage);
                Assert.Null(result.Exception);
                Assert.True(result.ResultData.Count > 0, $"result.ResultData.Count <= 0; (1) campaignId = {campaignId}.");
                int id = result.ResultData[0]["campaign_id"];
                int accountId = result.ResultData[0]["account_id"];
                Assert.Equal(id, campaignId);
                Assert.Equal(accountId, AccountId);
            }
            else if (results.ResultData.Count > 0)
            {
                // No campaigns have a hard-bounce-report, so any campaign should either work and/or be empty,
                // OR return an internal server error (which is a web service failure, not an API failure).
                campaignId = results.ResultData[0]["id"];
                var result = await api.GetHardBounceReports(campaignId, 1);
                if (result.Success)
                {
                    if (result.ResultData.Count > 0)
                    {
                        int id = result.ResultData[0]["campaign_id"];
                        int accountId = result.ResultData[0]["account_id"];
                        Assert.Equal(id, campaignId);
                        Assert.Equal(accountId, AccountId);
                    }
                    // else, nothing to assert. Is empty array.
                }
                else
                {
                    Assert.Contains("Internal Server Error", result.ErrorMessage);
                }
            }
        }

        [Fact]
        public async Task GetLinkReports_UniqueTrue()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 0)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetLinkReports(campaignId, 1, true);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            string url = result.ResultData[0]["url"];
            Assert.Equal(id, campaignId);
            Assert.NotEmpty(url);
        }

        [Fact]
        public async Task GetLinkReports_UniqueFalse()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 0)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetLinkReports(campaignId, 1, false);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            string url = result.ResultData[0]["url"];
            Assert.Equal(id, campaignId);
            Assert.NotEmpty(url);
        }

        [Fact]
        public async Task GetLinkReports_UniqueNull()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["clicked"];
                if (qtyReports > 0)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetLinkReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            string url = result.ResultData[0]["url"];
            Assert.Equal(id, campaignId);
            Assert.NotEmpty(url);
        }

        [Fact]
        public async Task GetOpenReports_UniqueTrue()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["opened"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetOpenReports(campaignId, 1, true);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetOpenReports_UniqueFalse()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["opened"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetOpenReports(campaignId, 1, false);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetOpenReports_UniqueNull()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["opened"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetOpenReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetSoftBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["soft_bounced"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetSoftBounceReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public async Task GetUnsubscribeReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            var results = await api.Get(1);
            var campaignId = 0;
            var qtyReports = 0;
            for (int i = 0; campaignId == 0 && i < results.ResultData.Count; i++)
            {
                int testCampaignId = results.ResultData[i]["id"];
                var campaignResult = await api.GetCampaign(testCampaignId);
                qtyReports = campaignResult.ResultData["unsubscribed"];
                if (qtyReports > 1)
                {
                    campaignId = testCampaignId;
                }
            }
            //Act
            var result = await api.GetUnsubscribeReports(campaignId, 1);
            //Assert
            Assert.True(result.Success, "result.Success is false");
            Assert.Null(result.ErrorMessage);
            Assert.Null(result.Exception);
            Assert.True(result.ResultData.Count > 0, "result.ResultData.Count <= 0");
            int id = result.ResultData[0]["campaign_id"];
            int accountId = result.ResultData[0]["account_id"];
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }
    }
}
