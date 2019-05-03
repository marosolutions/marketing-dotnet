using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maropost.Api
{
    public class Reports : _BaseApi
    {
        /// <param name="accountId">required</param>
        /// <param name="authToken">required</param>
        /// <param name="httpClient">must be non-null</param>
        /// <exception cref="ArgumentException" />
        public Reports(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "reports", httpClient) { }
        /// <summary>
        /// Gets the list of reports
        /// </summary>
        /// <param name="id">report ID</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Get(int page)
        {
            var result = await base.Get("", new KeyValueList { { "page", $"{page}" } });
            return result;
        }
        /// <summary>
        /// Gets the list of reports by report id
        /// </summary>
        /// <param name="id">report id</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetReport(int id)
        {
            var result = await base.Get($"{id}");
            return result;
        }

        /// <summary>
        /// Gets the list of open reports based on filters and fields provided
        /// </summary>
        /// <param name="page">page #. (>= 1)</param>
        /// <param name="fields">contact field names to retrieve</param>
        /// <param name="from">the beginning of date range filter</param>
        /// <param name="to">the end of the date range filter</param>
        /// <param name="unique">when true, gets only unique opens</param>
        /// <param name="email">filters by provided email in the contact</param>
        /// <param name="uid">filters by uid</param>
        /// <param name="per">determines how many records per request to receive</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetOpens(int page,
                                                  object[] fields = null,
                                                  DateTime? from = null,
                                                  DateTime? to = null,
                                                  bool? unique = null,
                                                  string email = null,
                                                  string uid = null,
                                                  int? per = null)
        {
            var opensParams = new ExpandoObject() as IDictionary<string, object>;
            opensParams.Add("fields", fields == null ? null : string.Join(",", fields));
            opensParams.Add("from", from == null ? null : ((DateTime)from).ToString("yyyy-MM-dd"));
            opensParams.Add("to", to == null ? null : ((DateTime)to).ToString("yyyy-MM-dd"));
            opensParams.Add("unique", unique);
            opensParams.Add("email", email);
            opensParams.Add("uid", uid);
            opensParams.Add("per", per);
            opensParams.Add("page", page);
            opensParams = opensParams.DiscardNullAndEmptyValues();
            var queryString = new List<KeyValuePair<string, object>>();
            foreach (var openParam in opensParams)
            {
                queryString.Add(new KeyValuePair<string, object>(openParam.Key, openParam.Value));
            }
            var result = await base.Get("opens", queryString);
            return result;
        }
        /// <summary>
        /// Gets a list of click reports
        /// </summary>
        /// <param name="page">page #. (>= 1)</param>
        /// <param name="fields">plucks these contact fields if they exist</param>
        /// <param name="from">Start of specific date range filter</param>
        /// <param name="to">end of date range filter</param>
        /// <param name="unique">If true, gets unique records</param>
        /// <param name="email">Gets Clicks for specific email</param>
        /// <param name="uid">Gets Clicks for provided uid</param>
        /// <param name="per">Gets the specified number of records</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetClicks(int page,
                                                   object[] fields = null,
                                                   DateTime? from = null,
                                                   DateTime? to = null,
                                                   bool? unique = null,
                                                   string email = null,
                                                   string uid = null,
                                                   int? per = null)
        {
            var opensParams = new ExpandoObject() as IDictionary<string, object>;
            opensParams.Add("fields", fields == null ? null : string.Join(",", fields));
            opensParams.Add("from", from == null ? null : ((DateTime)from).ToString("yyyy-MM-dd"));
            opensParams.Add("to", to == null ? null : ((DateTime)to).ToString("yyyy-MM-dd"));
            opensParams.Add("unique", unique);
            opensParams.Add("email", email);
            opensParams.Add("uid", uid);
            opensParams.Add("per", per);
            opensParams.Add("page", page);
            opensParams = opensParams.DiscardNullAndEmptyValues();
            var queryString = new List<KeyValuePair<string, object>>();
            foreach (var openParam in opensParams)
            {
                queryString.Add(new KeyValuePair<string, object>(openParam.Key, openParam.Value));
            }
            var result = await base.Get("clicks", queryString);
            return result;
        }
        /// <summary>
        /// Gets a list of bounce reports
        /// </summary>
        /// <param name="page">page #. (>= 1)/param>
        /// <param name="fields">plucks these contact fields if they exist</param>
        /// <param name="from">Start of specific date range filter</param>
        /// <param name="to">end of date range filter</param>
        /// <param name="unique">If true, gets unique records</param>
        /// <param name="email">Gets Bounces for specific email</param>
        /// <param name="uid">Gets Bounces for provided uid</param>
        /// <param name="type">Gets Bounces for specific type</param>
        /// <param name="per">Gets the specified number of records</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetBounce(int page,
                                                   object[] fields = null,
                                                   DateTime? from = null,
                                                   DateTime? to = null,
                                                   bool? unique = null,
                                                   string email = null,
                                                   string uid = null,
                                                   string type = null,
                                                   int? per = null)
        {
            var opensParams = new ExpandoObject() as IDictionary<string, object>;
            opensParams.Add("fields", fields == null ? null : string.Join(",", fields));
            opensParams.Add("from", from == null ? null : ((DateTime)from).ToString("yyyy-MM-dd"));
            opensParams.Add("to", to == null ? null : ((DateTime)to).ToString("yyyy-MM-dd"));
            opensParams.Add("unique", unique);
            opensParams.Add("email", email);
            opensParams.Add("uid", uid);
            opensParams.Add("type", type);
            opensParams.Add("per", per);
            opensParams.Add("page", page);
            opensParams = opensParams.DiscardNullAndEmptyValues();
            var queryString = new List<KeyValuePair<string, object>>();
            foreach (var openParam in opensParams)
            {
                queryString.Add(new KeyValuePair<string, object>(openParam.Key, openParam.Value));
            }
            var result = await base.Get("bounces", queryString);
            return result;
        }
        /// <summary>
        /// Gets a list of Unsubscribes with provided filter constraints
        /// </summary>
        /// <param name="page">page #. (>= 1)</param>
        /// <param name="fields">plucks these contact fields if they exist</param>
        /// <param name="from">Start of specific date range filter</param>
        /// <param name="to">end of date range filter</param>
        /// <param name="unique">If true, gets unique records</param>
        /// <param name="email">Gets Unsubscribes for specific email</param>
        /// <param name="uid">Gets Unsubscribes for provided uid</param>
        /// <param name="per">Gets the specified number of records</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetUnsubscribes(int page,
                                                         object[] fields = null,
                                                         DateTime? from = null,
                                                         DateTime? to = null,
                                                         bool? unique = null,
                                                         string email = null,
                                                         string uid = null,
                                                         int? per = null)
        {
            var opensParams = new ExpandoObject() as IDictionary<string, object>;
            opensParams.Add("fields", fields == null ? null : string.Join(",", fields));
            opensParams.Add("from", from == null ? null : ((DateTime)from).ToString("yyyy-MM-dd"));
            opensParams.Add("to", to == null ? null : ((DateTime)to).ToString("yyyy-MM-dd"));
            opensParams.Add("unique", unique);
            opensParams.Add("email", email);
            opensParams.Add("uid", uid);
            opensParams.Add("per", per);
            opensParams.Add("page", page);
            opensParams = opensParams.DiscardNullAndEmptyValues();
            var queryString = new List<KeyValuePair<string, object>>();
            foreach (var openParam in opensParams)
            {
                queryString.Add(new KeyValuePair<string, object>(openParam.Key, openParam.Value));
            }
            var result = await base.Get("unsubscribes", queryString);
            return result;
        }
        /// <summary>
        /// Gets a list of complaints filtered by provided params
        /// </summary>
        /// <param name="page">page #. (>= 1)</param>
        /// <param name="fields">plucks these contact fields if they exist</param>
        /// <param name="from">Start of specific date range filter</param>
        /// <param name="to">end of date range filter</param>
        /// <param name="unique">If true, gets unique records</param>
        /// <param name="email">Gets Complaints for specific email</param>
        /// <param name="uid">Gets Complaints for provided uid</param>
        /// <param name="per">Gets the specified number of records</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetComplaints(int page,
                                                       object[] fields = null,
                                                       DateTime? from = null,
                                                       DateTime? to = null,
                                                       bool? unique = null,
                                                       string email = null,
                                                       string uid = null,
                                                       int? per = null)
        {
            var opensParams = new ExpandoObject() as IDictionary<string, object>;
            opensParams.Add("fields", fields == null ? null : string.Join(",", fields));
            opensParams.Add("from", from == null ? null : ((DateTime)from).ToString("yyyy-MM-dd"));
            opensParams.Add("to", to == null ? null : ((DateTime)to).ToString("yyyy-MM-dd"));
            opensParams.Add("unique", unique);
            opensParams.Add("email", email);
            opensParams.Add("uid", uid);
            opensParams.Add("per", per);
            opensParams.Add("page", page);
            opensParams = opensParams.DiscardNullAndEmptyValues();
            var queryString = new List<KeyValuePair<string, object>>();
            foreach (var openParam in opensParams)
            {
                queryString.Add(new KeyValuePair<string, object>(openParam.Key, openParam.Value));
            }
            var result = await base.Get("complaints", queryString);
            return result;
        }
        /// <summary>
        /// Gets a list of Ab Reports
        /// </summary>
        /// <param name="name">To get ab_reports with mentioned name</param>
        /// <param name="page">Beginning of date range filter</param>
        /// <param name="from">End of date range filter</param>
        /// <param name="to">gets the mentioned number of reports</param>
        /// <param name="per">page #. (>= 1)</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetAbReports(string name,
                                                      int page,
                                                      DateTime? from = null,
                                                      DateTime? to = null,
                                                      int? per = null)
        {
            base.UrlPathRoot = "";
            var opensParams = new ExpandoObject() as IDictionary<string, object>;
            opensParams.Add("from", from == null ? null : ((DateTime)from).ToString("yyyy-MM-dd"));
            opensParams.Add("to", to == null ? null : ((DateTime)to).ToString("yyyy-MM-dd"));
            opensParams.Add("per", per);
            opensParams.Add("page", page);
            opensParams = opensParams.DiscardNullAndEmptyValues();
            var queryString = new List<KeyValuePair<string, object>>();
            foreach (var openParam in opensParams)
            {
                queryString.Add(new KeyValuePair<string, object>(openParam.Key, openParam.Value));
            }
            var result = await base.Get("ab_reports", queryString);
            return result;
        }
        /// <summary>
        /// Gets the list of all Journeys
        /// </summary>
        /// <param name="page">page #. (>= 1)</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetJourney(int page)
        {
            var keyValuePair = new KeyValueList { { "page", $"{page}" } };
            var result = await base.Get("journeys", keyValuePair);
            return result;
        }
    }
}