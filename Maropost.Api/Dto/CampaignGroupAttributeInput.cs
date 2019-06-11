using System;
using System.Collections.Generic;
using System.Text;

namespace Maropost.Api.Dto
{
    public class CampaignGroupAttributeInput
    {
        /// <param name="name">name of the group</param>
        /// <param name="contentId">content ID</param>
        /// <param name="subject">subject line of emails</param>
        /// <param name="preheader"></param>
        /// <param name="fromName">"from name" on emails</param>
        /// <param name="percentage">percentage of emails that should be sent with these settings</param>
        /// <param name="sendAt">DateTime to send this group</param>
        public CampaignGroupAttributeInput(string name, int contentId, string subject, string preheader, string fromName, int percentage, DateTime sendAt)
        {
            this.name = name;
            this.content_id = contentId.ToString();
            this.subject = subject;
            this.preheader = preheader;
            this.from_name = fromName;
            this.percentage = percentage.ToString();
            this.send_at = sendAt.ToString("yyyy-MM-dd H:mm:ss");
        }
        /// <summary>
        /// name of the group
        /// </summary>
        public string name { get; }
        /// <summary>
        /// content ID
        /// </summary>
        public string content_id { get; }
        /// <summary>
        /// subject line of emails
        /// </summary>
        public string subject { get; }
        public string preheader { get; }
        /// <summary>
        /// "from name" on emails
        /// </summary>
        public string from_name { get; }
        /// <summary>
        /// percentage of emails that should be sent with these settings
        /// </summary>
        public string percentage { get; }
        /// <summary>
        /// DateTime to send this group
        /// </summary>
        public string send_at { get; }
    }
}