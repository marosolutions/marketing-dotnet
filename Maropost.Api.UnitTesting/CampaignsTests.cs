using System;
using System.Net.Http;
using Maropost.Api;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class CampaignsTests : _BaseTests
    {
        [Fact]
        public void Get_ReturnsProperPagedResults()
        {
            // Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            // Act
            var result = api.Get(1);
            // Assert
            int accountId = result.ResultData[0]["account_id"];
            Assert.NotNull(result);
            Assert.True(result.Success);
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
            Assert.True(result.Success);
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetBounceReports()
        {
            //Arrange
            var api = new Campaigns(AccountId, AuthToken, HttpClient);
            int campaignId = 9249;
            //Act
            var result = api.GetBounceReports(campaignId, 1);
            //Assert
            int id = result.ResultData["id"];
            int accountId = result.ResultData["account_id"];
            Assert.True(result.Success);
            Assert.Equal(id, campaignId);
            Assert.Equal(accountId, AccountId);
        }
    }
}
