using Maropost.Api.Dto;
using Maropost.Api.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Maropost.Api
{
    public class AbTestCampaigns : _BaseApi
    {
        /// <param name="accountId">required</param>
        /// <param name="authToken">required</param>
        /// <param name="httpClient">must be non-null</param>
        /// <exception cref="ArgumentException" />
        public AbTestCampaigns(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "campaigns", httpClient)
        { }

        /// <summary>
        /// Creates an Ab Test campaign
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fromEmail"></param>
        /// <param name="replyTo"></param>
        /// <param name="address"></param>
        /// <param name="language"></param>
        /// <param name="campaignGroupAttributes"></param>
        /// <param name="commit"></param>
        /// <param name="sendAt"></param>
        /// <param name="brandId"></param>
        /// <param name="suppressedListIds"></param>
        /// <param name="suppressedSegmentIds"></param>
        /// <param name="suppressedJourneyIds"></param>
        /// <param name="emailPreviewLink"></param>
        /// <param name="decidedBy"></param>
        /// <param name="lists"></param>
        /// <param name="cTags"></param>
        /// <param name="segments"></param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> CreateAbTest(string name,
                                                      string fromEmail,
                                                      string replyTo,
                                                      string address,
                                                      Enums.Language language,
                                                      IEnumerable<CampaignGroupAttributeInput> campaignGroupAttributes,
                                                      Commit commit,
                                                      DateTime sendAt,
                                                      int? brandId = null,
                                                      IEnumerable<int> suppressedListIds = null,
                                                      IEnumerable<int> suppressedSegmentIds = null,
                                                      IEnumerable<int> suppressedJourneyIds = null,
                                                      string emailPreviewLink = null,
                                                      DecidedBy? decidedBy = null,
                                                      IEnumerable<int> lists = null,
                                                      IEnumerable<int> cTags = null,
                                                      IEnumerable<int> segments = null)
        {
            if (sendAt == null)
            {
                throw new ArgumentNullException("sendAt");
            }

            var records = new ExpandoObject() as IDictionary<string, object>;
            records.Add("name", name);
            records.Add("from_email", fromEmail);
            records.Add("reply_to", replyTo);
            records.Add("address", address);
            records.Add("language", language.ToAbbreviation());
            records.Add("send_at", sendAt.ToString("yyyy-MM-dd H:mm:ss"));
            records.Add("commit", commit.ToFriendlyString());
            records.Add("brand_id", brandId.ToString());
            records.Add("email_preview_link", emailPreviewLink);
            records.Add("decided_by", decidedBy?.ToFriendlyString());
            records.Add("campaign_groups_attributes", campaignGroupAttributes);
            records.Add("suppressed_list_ids", suppressedListIds?.Select(id => id.ToString()));
            records.Add("suppressed_segment_ids", suppressedSegmentIds?.Select(id => id.ToString()));
            records.Add("suppressed_journey_ids", suppressedJourneyIds?.Select(id => id.ToString()));
            records.Add("lists", lists?.Select(list => list.ToString()));
            records.Add("ctags", cTags?.Select(ct => ct.ToString()));
            records.Add("segments", segments?.Select(s => s.ToString()));
            records = records.DiscardNullAndEmptyValues();
            var data = new { campaign = records };
            var result = await base.Post("ab_test", null, data);
            return result;
        }
    }
}