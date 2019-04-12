using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Maropost.Api
{
    public class Contacts : _BaseApi
    {
        public Contacts(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "contacts", httpClient)
        { }

        public IOperationResult<dynamic> GetForEmail(string email)
        {
            var keyValuePair = new KeyValueList { { "contact[email]", email } };
            var result = base.Get("email", keyValuePair);
            return result;
        }

        public IOperationResult<dynamic> GetOpens(int contactId, int page)
        {
            var resource = $"{contactId}/open_report";
            var result = base.Get(resource, new KeyValueList { { "page", page.ToString() } });
            return result;
        }

        public IOperationResult<dynamic> GetClicks(int contactId, int page)
        {
            var resource = $"{contactId}/click_report";
            var result = base.Get(resource, new KeyValueList { { "page", page.ToString() } });
            return result;
        }

        public IOperationResult<dynamic> GetForList(int listId, int page)
        {
            var overrideResource = $"lists/{listId}";
            var result = base.Get("contacts", new KeyValueList { { "page", page.ToString() } }, overrideResource);
            return result;
        }

        public IOperationResult<dynamic> GetContactForList(int listId, int contactId)
        {
            var overrideResource = $"lists/{listId}";
            var result = base.Get($"contacts/{contactId}", null, overrideResource);
            return result;
        }

        public IOperationResult<dynamic> CreateOrUpdateForList(int listId,
                                                               string email,
                                                               string firstName = null,
                                                               string lastName = null,
                                                               string phone = null,
                                                               string fax = null,
                                                               string uid = null,
                                                               Array customField = null,
                                                               Array addTags = null,
                                                               Array removeTags = null,
                                                               bool removeFromDNM = true,
                                                               bool subscribe = true)
        {
            return null;
        }

        public IOperationResult<dynamic> UpdateForListAndContact(int listId,
                                                                 string contactId,
                                                                 string email,
                                                                 string firstName = null,
                                                                 string lastName = null,
                                                                 string phone = null,
                                                                 string fax = null,
                                                                 string uid = null,
                                                                 Array customField = null,
                                                                 Array addTags = null,
                                                                 Array removeTags = null,
                                                                 bool removeFromDNM = true,
                                                                 bool subscribe = true)
        {
            return null;
        }

        public IOperationResult<dynamic> CreateOrUpdateContact(string email,
                                                               string firstName = null,
                                                               string lastName = null,
                                                               string phone = null,
                                                               string fax = null,
                                                               string uid = null,
                                                               Array customField = null,
                                                               Array addTags = null,
                                                               Array removeTags = null,
                                                               bool removeFromDNM = true,
                                                               bool subscribe = true)
        {
            return null;
        }

        public IOperationResult<dynamic> CreateOrUpdateForListAndWorkflows(string email,
                                                                           string firstName = null,
                                                                           string lastNmae = null,
                                                                           string phone = null,
                                                                           string fax = null,
                                                                           string uid = null,
                                                                           Array customField = null,
                                                                           Array addTags = null,
                                                                           Array removeTags = null,
                                                                           bool removeFromDNM = false,
                                                                           Array subscribeListIds = null,
                                                                           Array unsubscriveListIds = null,
                                                                           Array unsubscribeWEorkflowIds = null,
                                                                           string unsubscriveCamaign = null)
        {
            return null;
        }
    }
}