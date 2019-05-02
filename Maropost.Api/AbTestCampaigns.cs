using Maropost.Api.Dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;

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
        /// <param name="language">
        /// Allowed value for language can be either of these:
        /// ['en' for English, 'es' for Spanish, 'de' for German, 'it' for Italian, 'fr' for French, 'pt' for Portuguese, 'pl' for Polish, 'da' for Danish, 'zh' for Chinese, 'nl' for Dutch, 'sv' for Swedish, 'no' for Norwegian]
        /// </param>
        /// <param name="campaignGroupAttributes"></param>
        /// <param name="commit">Allowed values for commit: 'Save as Draft' or 'Send Test' or 'Schedule'</param>
        /// <param name="sendAt">send_at should be in "yyyy-mm-dd %H:%M:%S" where %H - Hour of the day, 24-hour clock (00..23), %M - Minute of the hour (00..59), %S - Second of the minute (00..60)</param>
        /// <param name="brandId"></param>
        /// <param name="suppressedListIds"></param>
        /// <param name="suppressedSegmentIds"></param>
        /// <param name="suppressedJourneyIds"></param>
        /// <param name="emailPreviewLink"></param>
        /// <param name="decidedBy">
        /// Allowed values for decided_by: ('TopChoice' for Top Choices) or
        /// ('Opens' for Highest Open Rate) or ('Clicks' for Highest Click Rate) or ('Manual' for Manual Selection) or
        /// ('click_to_open' for Highest Click-to-Open Rate) or ('conversions' for Highest Conversion Rate)
        /// </param>
        /// <param name="lists"></param>
        /// <param name="cTags"></param>
        /// <param name="segments"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> CreateAbTest(string name,
                                                      string fromEmail,
                                                      string replyTo,
                                                      string address,
                                                      string language,
                                                      string campaignGroupAttributes,
                                                      string commit,
                                                      DateTime sendAt,
                                                      int? brandId = null,
                                                      object[] suppressedListIds = null,
                                                      object[] suppressedSegmentIds = null,
                                                      object[] suppressedJourneyIds = null,
                                                      int? emailPreviewLink = null,
                                                      string decidedBy = null,
                                                      object[] lists = null,
                                                      object[] cTags = null,
                                                      object[] segments = null)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            records.Add("name", name);
            records.Add("from_email", fromEmail);
            records.Add("reply_to", replyTo);
            records.Add("address", address);
            records.Add("language", language);
            records.Add("send_at", sendAt);
            records.Add("commit", commit);
            records.Add("brand_id", brandId);
            records.Add("email_preview_link", emailPreviewLink);
            records.Add("decided_by", decidedBy);
            records.Add("campaign_groups_attributes", campaignGroupAttributes);
            records.Add("suppressed_list_ids", suppressedListIds);
            records.Add("suppressed_segment_ids", suppressedSegmentIds);
            records.Add("suppressed_journey_ids", suppressedJourneyIds);
            records.Add("lists", lists);
            records.Add("ctags", cTags);
            records.Add("segments", segments);
            records = records.DiscardNullAndEmptyValues();
            var result = base.Post("ab_test", null, records);
            return result;
        }
    }
}