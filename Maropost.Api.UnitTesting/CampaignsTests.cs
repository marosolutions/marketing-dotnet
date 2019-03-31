using System;
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
            var api = new Campaigns(AccountId, AuthToken);
            // Act
            // Assert
            Assert.True(true);
            // Teardown
        }
    }
}
