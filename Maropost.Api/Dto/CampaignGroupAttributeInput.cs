using System;
using System.Collections.Generic;
using System.Text;

namespace Maropost.Api.Dto
{
    public class CampaignGroupAttributeInput
    {
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
        public string name { get; }
        public string content_id { get; }
        public string subject { get; }
        public string preheader { get; }
        public string from_name { get; }
        public string percentage { get; }
        public string send_at { get; }
    }
}