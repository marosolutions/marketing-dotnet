using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Maropost.Api
{
    public class TransactionalCampaigns : _BaseApi
    {
        /// <param name="accountId">required</param>
        /// <param name="authToken">required</param>
        /// <param name="httpClient">must be non-null</param>
        /// <exception cref="ArgumentException" />
        public TransactionalCampaigns(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "transactional_campaigns", httpClient) { }
        /// <summary>
        /// Gets the list of Transaction Campaigns
        /// </summary>
        /// <param name="page">page #. (>= 1)</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Get(int page)
        {
            var result = await base.Get("", new KeyValueList { { "page", $"{page}" } });
            return result;
        }
        /// <summary>
        /// Creates a Transactional Campaign
        /// </summary>
        /// <param name="name">campaign name</param>
        /// <param name="subject">campaign subject</param>
        /// <param name="preheader">campaign preheader</param>
        /// <param name="fromName">sender name in the email</param>
        /// <param name="fromEmail">sender email address</param>
        /// <param name="replyTo">reply-to email address</param>
        /// <param name="contentId"></param>
        /// <param name="emailPreviewLink"></param>
        /// <param name="address"></param>
        /// <param name="language">ISO 639-1 language code</param>
        /// <param name="ctags">array of campaign tags</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Create(string name,
                                               string subject,
                                               string preheader,
                                               string fromName,
                                               string fromEmail,
                                               string replyTo,
                                               int contentId,
                                               bool emailPreviewLink,
                                               string address,
                                               string language,
                                               object[] ctags)
        {
            var campaign = new ExpandoObject() as IDictionary<string, object>;
            campaign.Add("name", name);
            campaign.Add("subject", subject);
            campaign.Add("preheader", preheader);
            campaign.Add("from_name", fromName);
            campaign.Add("from_email", fromEmail);
            campaign.Add("reply_to", replyTo);
            campaign.Add("content_id", contentId);
            campaign.Add("email_preview_link", emailPreviewLink);
            campaign.Add("address", address);
            campaign.Add("language", language);
            if (ctags.Length > 0)
            {
                campaign.Add("add_ctags", ctags);
            }
            var campaignObject = new { campaign };
            var result = await base.Post("", null, campaignObject);
            return result;
        }
        /// <summary>
        /// Sends a transactional campaign email to a recipient. Sender's information will be automatically fetched from the
        /// transactional campaign, unless provided in the function arguments.
        /// </summary>
        /// <param name="campaignId">must be a campaign that already exists when you call ->get(). If you don't have one, first call ->create().</param>
        /// <param name="contentId">If provided, the transactional campaign's content will be replaced by this content.</param>
        /// <param name="contentName">If $contentId is null, the transactional campaign's content name will be replaced by this name.</param>
        /// <param name="contentHtmlPart">If $contentId is null, the transactional campaign's content HTML part will be replaced by this HTML part.</param>
        /// <param name="contentTextPart">If $contentId is null, the transactional campaign's content Text part will be replaced by this Text part.</param>
        /// <param name="sendAtHour">Must be 1-12. Otherwise the email will go out immediately. If the hour is less than the current hour, the email will go out the following day.</param>
        /// <param name="sendAtMinute">Must be 0-60. Otherwise will be treated as 0. If the hour and minute combine to less than the current time, the email will go out the following day.</param>
        /// <param name="ignoreDnm">If true, ignores the Do Not Mail list for the recipient contact.</param>
        /// <param name="contactId">contact ID of the recipient.</param>
        /// <param name="recipientEmail">email address. Ignored unless $contactId is null. Otherwise, it must be a well-formed email address according to FILTER_VALIDATE_EMAIL.</param>
        /// <param name="recipientFirstName">recipient's first name. Ignored unless $contactId is null.</param>
        /// <param name="recipientLastName">recipient's last name. Ignored unless $contactId is null.</param>
        /// <param name="recipientCustomFields">
        /// custom fields for the recipient. Ignored unless $contactId is null.
        /// Is an associative array where the item key is the name of the custom field, and the item value is the field value.
        /// All keys must be strings. All values must be non-null scalars.</param>
        /// <param name="bccEmail">BCC recipient. May only pass a single email address, empty string, or null. If provided, it must be a well-formed email address according to FILTER_VALIDATE_EMAIL.</param>
        /// <param name="fromName">sender's name. If $fromEmail is set, it overrides the transactional campaign default sender name. Ignored otherwise.</param>
        /// <param name="fromEmail">sender's email address. Overrides the transactional campaign default sender email.</param>
        /// <param name="subject">subject line of email. Overrides the transactional campaign default subject.</param>
        /// <param name="replyTo">reply-to address. Overrides the transactional campaign default reply-to.</param>
        /// <param name="senderAddress">physical address of sender. Overrides the transactional campaign default sender address.</param>
        /// <param name="tags">associative array where the item key is the name of the tag within the content, and the item value is the tag's replacement upon sending. All keys must be strings. All values must be non-null scalars.</param>
        /// <param name="ctags">campaign tags. Must be a simple array of scalar values.</param>
        /// <returns>data property contains information about the newly created campaign.</returns>
        public async Task<IOperationResult<dynamic>> SendEmail(int campaignId,
                                                   int? contentId = null,
                                                   string contentName = null,
                                                   string contentHtmlPart = null,
                                                   string contentTextPart = null,
                                                   int? sendAtHour = null,
                                                   int? sendAtMinute = null,
                                                   bool? ignoreDnm = null,
                                                   int? contactId = null,
                                                   string recipientEmail = null,
                                                   string recipientFirstName = null,
                                                   string recipientLastName = null,
                                                   IDictionary<object, object> recipientCustomFields = null,
                                                   string bccEmail = null,
                                                   string fromName = null,
                                                   string fromEmail = null,
                                                   string subject = null,
                                                   string replyTo = null,
                                                   string senderAddress = null,
                                                   IDictionary<object, object> tags = null,
                                                   object[] ctags = null)
        {
            var emailRecord = new ExpandoObject() as IDictionary<string, object>;
            emailRecord.Add("campaign_id", campaignId);
            var contentFlag = 0;//nothing provided
            if (contentId != null)
            {
                emailRecord.Add("content_id", contentId);
                contentFlag = 1;//contentId provided
            }
            if (!string.IsNullOrEmpty(contentHtmlPart) || !string.IsNullOrEmpty(contentTextPart) || !string.IsNullOrEmpty(contentName))
            {
                emailRecord.Add("content", new
                {
                    name = contentName,
                    html_part = contentHtmlPart,
                    text_part = contentTextPart
                });
                contentFlag = 2;//content field(s) provided
            }
            if (contentFlag == 3)
            {
                return new OperationResult<dynamic>(null, null, "You may provide EITHER a contentId OR content field values, but not both.");
            }
            if (contactId != null)
            {
                if (!recipientEmail.IsValidEmail())
                {
                    return new OperationResult<dynamic>(null, null, "You must provide a well-formed recipientEmail because contactId is null.");
                }
                emailRecord.Add("contact", new
                {
                    email = recipientEmail,
                    first_name = recipientFirstName,
                    last_name = recipientLastName
                });
                if (recipientCustomFields != null)
                {
                    foreach (var recipientCustomField in recipientCustomFields)
                    {
                        if (!(recipientCustomField.Key is string))
                        {
                            return new OperationResult<dynamic>(null, null, "All keys in your recipientCustomFields array must be strings.");
                        }
                        if (!recipientCustomField.Value.IsScalar())
                        {
                            return new OperationResult<dynamic>(null, null, "All values in your recipientCustomFields array must be non-null scalars (string, float, bool, int).");
                        }
                    }
                    emailRecord.Add("custom_field", recipientCustomFields);
                }
            }
            else
            {
                emailRecord.Add("custom_field", recipientCustomFields);
            }
            if (sendAtHour > 0 && sendAtHour <= 12)
            {
                if (!(sendAtMinute >= 0 && sendAtMinute <= 60))
                {
                    sendAtMinute = 0;
                }
                emailRecord.Add("send_time", new { hour = $"{sendAtHour}", minute = $"{sendAtMinute}" });
            }
            if (ignoreDnm != null && ignoreDnm == true)
            {
                emailRecord.Add("ignore_dnm", true);
            }
            if (!string.IsNullOrEmpty(fromEmail))
            {
                emailRecord.Add("from_email", fromEmail);
                emailRecord.Add("from_name", fromName);
            }
            if (!string.IsNullOrEmpty(replyTo))
            {
                emailRecord.Add("reply_to", replyTo);
            }
            if (!string.IsNullOrEmpty(subject))
            {
                emailRecord.Add("subject", subject);
            }
            if (!string.IsNullOrEmpty(senderAddress))
            {
                emailRecord.Add("address", senderAddress);
            }
            if (!string.IsNullOrEmpty(bccEmail))
            {
                if (bccEmail.IsValidEmail())
                {
                    emailRecord.Add("bcc", bccEmail);
                }
                else
                {
                    return new OperationResult<dynamic>(null, null, "When providing a bccEmail, it needs to be a well-formed email address.");
                }
            }
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    if (!(tag.Key is string))
                    {
                        return new OperationResult<dynamic>(null, null, "All keys in your tags array must be strings.");
                    }
                    if (!tag.Value.IsScalar())
                    {
                        return new OperationResult<dynamic>(null, null, "All values in your tags array must be non-null scalars (string, float, bool, int).");
                    }
                }
                emailRecord.Add("tags", tags);
            }
            if (ctags != null)
            {
                foreach (var ctag in ctags)
                {
                    if (!ctag.IsScalar())
                    {
                        return new OperationResult<dynamic>(null, null, "All values in your ctags array must be non-null scalars (string, float, bool, int).");
                    }
                }
                emailRecord.Add("add_ctags", ctags);
            }
            var requestObj = new { email = emailRecord };
            var result = await base.Post("deliver", null, requestObj, "emails");
            return result;
        }
    }
}