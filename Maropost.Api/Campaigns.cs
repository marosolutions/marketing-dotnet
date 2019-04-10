﻿using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System.Net.Http;

namespace Maropost.Api
{
    public class Campaigns : _BaseApi
    {
        public Campaigns(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "campaigns", httpClient)
        { }
        /// <summary>
        /// Gets all campaigns
        /// </summary>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> Get(int page)
        {
            var result = Get(null, new KeyValueList { { "page", page.ToString() } });
            return result;
        }
        /// <summary>
        /// Gets campaign details by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get campaign details</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetCampaign(int id)
        {
            var result = base.Get(id.ToString());
            return result;
        }
        /// <summary>
        /// Get bounce reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get bounce reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetBounceReports(int id, int page)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/bounce_report");
            return result;
        }
        /// <summary>
        /// Get click reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get click reprots of campaign</param>
        /// <param name="page">total number of pages of dta to be loaded</param>
        /// <param name="unique">determinies whether to get unique click reports</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetClickReports(int id, int page, bool? unique = null)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/click_report");
            return result;
        }
        /// <summary>
        /// Gets complaint reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get complaint reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetComplaintReports(int id, int page)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/complaint_report");
            return result;
        }
        /// <summary>
        /// Get delivered reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get delivered reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetDeliveredReports(int id, int page)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/delivered_report");
            return result;
        }
        /// <summary>
        /// Get hard bounce reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get delivered reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetHardBounceReports(int id, int page)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/hard_bounce_report");
            return result;
        }
        /// <summary>
        /// Get link reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get link reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <param name="unique">determines whether to get unique reports of campaign</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetLinkReports(int id, int page, bool? unique = null)
        {
            string isUnique = unique == null ? "true" : unique.ToString();
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() }, { "unique", isUnique } }, $"campaigns/{id}/link_report");
            return result;
        }
        /// <summary>
        /// Get open reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get open reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <param name="unique">determines whether to get unique reports of campaign</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetOpenReports(int id, int page, bool? unique = null)
        {
            string isUnique = unique == null ? "true" : unique.ToString();
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() }, { "unique", isUnique } }, $"campaigns/{id}/open_report");
            return result;
        }
        /// <summary>
        /// Get soft bounce reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get soft bounce reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetSoftBounceReports(int id, int page)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/soft_bounce_report");
            return result;
        }
        /// <summary>
        /// Get unsubscribe reports by campaign id
        /// </summary>
        /// <param name="id">id of campaign to get unsubscribe reports of campaign</param>
        /// <param name="page">total number of pages of data to be loaded</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetUnsubscribeReports(int id, int page)
        {
            var result = base.Get(null, new KeyValueList { { "page", page.ToString() } }, $"campaigns/{id}/unsubscribe_report");
            return result;
        }
    }
}
