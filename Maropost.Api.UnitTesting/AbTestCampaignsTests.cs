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
            string name = $"name_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            string fromEmail = $"frm_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            string replyTo = $"to_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            string address = "The Alternative Daily | 860 US Highway 1 | Suite 210 | North Palm Beach | FL | 33408";
            string lanugage = "en";
            object[] campaignAttr = new[] { new { name = "Group A", content_id = "92", subject = "a", preheader = "232", from_name = "k", percentage = "2", send_at = $"{DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss")}" },
                                            new { name = "Group B", content_id = "92", subject = "b", preheader = "232", from_name = "gg", percentage = "2", send_at = $"{DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss")}" }};
            string sendAt = $"{DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss")}";
            string[] lists = new[] { "15", "24" };
            string[] ctags = new[] { "5", "70" };
            string[] segments = new[] { "5", "7" };
            int brandId = 2;
            string[] suppressListIds = new[] { "66", "63" };
            string[] suppressSegmentIds = new[] { "34", "81" };
            string[] suppressJourneyIds = new[] { "21", "24" };
            int emailPreviewLink = 0;
            string decidedBy = "TopChoice";
            string commit = "Save as Draft";
            //Act
            var result = await api.CreateAbTest(name, fromEmail, replyTo, address, lanugage, campaignAttr, commit, sendAt, brandId, suppressListIds, suppressSegmentIds, suppressJourneyIds, emailPreviewLink, decidedBy, lists, ctags, segments);
            //Assert
            Assert.True(result.Success);
        }
    }
}