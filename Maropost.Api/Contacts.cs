using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Maropost.Api
{
    public class Contacts : _BaseApi

    {
        public Contacts(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "contacts", httpClient)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetForEmail(string email)
        {
            var keyValuePair = new KeyValueList { { "contact[email]", email } };
            var result = base.Get("email", keyValuePair);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetOpens(int contactId, int page)
        {
            var resource = $"{contactId}/open_report";
            var result = base.Get(resource, new KeyValueList { { "page", page.ToString() } });
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetClicks(int contactId, int page)
        {
            var resource = $"{contactId}/click_report";
            var result = base.Get(resource, new KeyValueList { { "page", page.ToString() } });
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetForList(int listId, int page)
        {
            var overrideResource = $"lists/{listId}";
            var result = base.Get("contacts", new KeyValueList { { "page", page.ToString() } }, overrideResource);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetContactForList(int listId, int contactId)
        {
            var overrideResource = $"lists/{listId}";
            var result = base.Get($"contacts/{contactId}", null, overrideResource);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="uid"></param>
        /// <param name="customField"></param>
        /// <param name="addTags"></param>
        /// <param name="removeTags"></param>
        /// <param name="removeFromDNM"></param>
        /// <param name="subscribe"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> CreateOrUpdateForList(int listId,
                                                               string email,
                                                               string firstName = null,
                                                               string lastName = null,
                                                               string phone = null,
                                                               string fax = null,
                                                               string uid = null,
                                                               object customField = null,
                                                               object addTags = null,
                                                               object removeTags = null,
                                                               bool removeFromDNM = true,
                                                               bool subscribe = true)
        {
            var contact = new
            {
                email,
                first_name = firstName,
                last_name = lastName,
                phone,
                fax,
                uid,
                custom_field = customField,
                add_tags = addTags,
                remove_tags = removeTags,
                removeFromDNM,
                subscribe
            };
            string overrideResource = $"lists/{listId}";
            var getResult = this.GetForEmail(email);
            if (getResult.Success)
            {
                int? contactId = getResult.ResultData["id"];
                if (contactId != null)
                {
                    return base.Put($"contacts/{contactId}", null, contact, overrideResource);
                }
            }
            return base.Post("contacts", null, contact, overrideResource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="contactId"></param>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="uid"></param>
        /// <param name="customField"></param>
        /// <param name="addTags"></param>
        /// <param name="removeTags"></param>
        /// <param name="removeFromDNM"></param>
        /// <param name="subscribe"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> UpdateForListAndContact(int listId,
                                                                 string contactId,
                                                                 string email,
                                                                 string firstName = null,
                                                                 string lastName = null,
                                                                 string phone = null,
                                                                 string fax = null,
                                                                 string uid = null,
                                                                 object customField = null,
                                                                 object addTags = null,
                                                                 object removeTags = null,
                                                                 bool removeFromDNM = true,
                                                                 bool subscribe = true)
        {
            var contact = new
            {
                email,
                first_name = firstName,
                last_name = lastName,
                phone,
                fax,
                uid,
                custom_field = customField,
                add_tags = addTags,
                remove_tags = removeTags,
                removeFromDNM,
                subscribe
            };
            string overrideResource = $"lists/{listId}";
            return base.Put($"contacts/{contactId}", null, contact, overrideResource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="uid"></param>
        /// <param name="customField"></param>
        /// <param name="addTags"></param>
        /// <param name="removeTags"></param>
        /// <param name="removeFromDNM"></param>
        /// <param name="subscribe"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> CreateOrUpdateContact(string email,
                                                               string firstName = null,
                                                               string lastName = null,
                                                               string phone = null,
                                                               string fax = null,
                                                               string uid = null,
                                                               object customField = null,
                                                               object addTags = null,
                                                               object removeTags = null,
                                                               bool removeFromDNM = true,
                                                               bool subscribe = true)
        {
            var contact = new
            {
                email,
                first_name = firstName,
                last_name = lastName,
                phone,
                fax,
                uid,
                custom_field = customField,
                add_tags = addTags,
                remove_tags = removeTags,
                removeFromDNM,
                subscribe
            };
            var getResult = this.GetForEmail(email);
            if (getResult.Success)
            {
                int? contactId = getResult.ResultData["id"];
                if (contactId != null)
                {
                    return base.Put($"{contactId}", null, contact);
                }
            }
            return base.Put("", null, contact);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="uid"></param>
        /// <param name="customField"></param>
        /// <param name="addTags"></param>
        /// <param name="removeTags"></param>
        /// <param name="removeFromDNM"></param>
        /// <param name="subscribeListIds"></param>
        /// <param name="unsubscriveListIds"></param>
        /// <param name="unsubscribeWorkflowIds"></param>
        /// <param name="unsubscriveCamaign"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> CreateOrUpdateForListAndWorkflows(string email,
                                                                           string firstName = null,
                                                                           string lastName = null,
                                                                           string phone = null,
                                                                           string fax = null,
                                                                           string uid = null,
                                                                           object customField = null,
                                                                           object addTags = null,
                                                                           object removeTags = null,
                                                                           bool removeFromDNM = false,
                                                                           int[] subscribeListIds = null,
                                                                           int[] unsubscriveListIds = null,
                                                                           int[] unsubscribeWorkflowIds = null,
                                                                           string unsubscriveCamaign = null)
        {
            var options = new
            {
                subscribe_list_ids = string.Join(",", subscribeListIds),
                unsubscribe_list_ids = string.Join(",", unsubscriveListIds),
                unsubscribe_workflow_ids = string.Join(",", unsubscribeWorkflowIds),
                unsubscribe_campaign = unsubscriveCamaign
            };
            var contact = new
            {
                email,
                first_name = firstName,
                last_name = lastName,
                phone,
                fax,
                uid,
                custom_field = customField,
                add_tags = addTags,
                remove_tags = removeTags,
                removeFromDNM,
                options
            };
            var getResult = this.GetForEmail(email);
            if (getResult.Success)
            {
                int? contactId = getResult.ResultData["id"];
                if (contactId != null)
                {
                    return base.Put($"{contactId}", null, contact);
                }
            }
            return base.Post("", null, contact);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteFromAllLists(string email)
        {
            var keyValuePair = new KeyValueList { { "contact[email]", email } };
            return base.Delete("delete_all", keyValuePair);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="listIds"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteFromLists(int contactId, int[] listIds = null)
        {
            var keyValuePair = new KeyValueList();
            if (listIds != null)
            {
                keyValuePair.Add("list_ids", string.Join(",", listIds));
            }
            return base.Delete($"{contactId}", keyValuePair);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteContactForUid(string uid)
        {
            var keyValuePair = new KeyValueList { { "uid", uid } };
            return base.Delete("delete_all", keyValuePair);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteListContact(int listId, int contactId)
        {
            var overrideResource = $"lists/{listId}";
            return base.Delete($"contacts/{contactId}", null, overrideResource);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactFieldValue"></param>
        /// <param name="contactFieldName"></param>
        /// <returns></returns>
        public IOperationResult<dynamic> UnsubscribeAll(string contactFieldValue, string contactFieldName = "email")
        {
            var keyValuePair = new KeyValueList { { $"contact[{contactFieldName}]", contactFieldValue } };
            return base.Put("unsubscribe_all", keyValuePair);
        }
    }
}