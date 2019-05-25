using System;
using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class AbTestCampaignsTests : _BaseTests
    {
        [Fact]
        public async Task CreateAbTest()
        {
            //Arrange
            var api = new AbTestCampaigns(AccountId, AuthToken, HttpClient);
            var name = $"name_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var fromEmail = $"frm_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var replyTo = $"to_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var address = "The Alternative Daily | 860 US Highway 1 | Suite 210 | North Palm Beach | FL | 33408";
            var language = Enums.Language.English;
            var campaignGroupAttrs = new[] { new Dto.CampaignGroupAttributeInput("Group A", 92, "a", "232", "k", 2, DateTime.UtcNow.AddDays(1)),
                                            new Dto.CampaignGroupAttributeInput("Group B", 92, "b", "232", "gg", 2, DateTime.UtcNow.AddDays(1)) };
            var sendAt = DateTime.UtcNow.AddDays(1);
            var lists = new[] { 15, 24 };
            var ctags = new[] { 5, 70 };
            var segments = new[] { 5, 7 };
            int brandId = 2;
            var suppressListIds = new[] { 66, 63 };
            var suppressSegmentIds = new[] { 34, 81 };
            var suppressJourneyIds = new[] { 21, 24 };
            var emailPreviewLink = "0";
            var decidedBy = Enums.DecidedBy.TopChoices;
            var commit = Enums.Commit.SaveAsDraft;
            //Act
            var result = await api.CreateAbTest(name, fromEmail, replyTo, address, language, campaignGroupAttrs, commit, sendAt, brandId, suppressListIds, suppressSegmentIds, suppressJourneyIds, emailPreviewLink, decidedBy, lists, ctags, segments);
            //Assert
            Assert.NotNull(result);
        }
    }
}