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
        /// Get contact details for provided email address
        /// </summary>
        /// <param name="email">email address of the contact to be retrived</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetForEmail(string email)
        {
            var keyValuePair = new KeyValueList { { "contact[email]", email } };
            var result = base.Get("email", keyValuePair);
            return result;
        }
        /// <summary>
        /// Get all open contacts
        /// </summary>
        /// <param name="contactId">contact id of a contact</param>
        /// <param name="page">total page</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetOpens(int contactId, int page)
        {
            var resource = $"{contactId}/open_report";
            var result = base.Get(resource, new KeyValueList { { "page", page.ToString() } });
            return result;
        }
        /// <summary>
        /// Get all clicked contacts by contact id
        /// </summary>
        /// <param name="contactId">contact id of a contact</param>
        /// <param name="page">total page</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetClicks(int contactId, int page)
        {
            var resource = $"{contactId}/click_report";
            var result = base.Get(resource, new KeyValueList { { "page", page.ToString() } });
            return result;
        }
        /// <summary>
        /// Get contact for list
        /// </summary>
        /// <param name="listId">list id of a contact with in list</param>
        /// <param name="page">total page</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetForList(int listId, int page)
        {
            var overrideResource = $"lists/{listId}";
            var result = base.Get("contacts", new KeyValueList { { "page", page.ToString() } }, overrideResource);
            return result;
        }
        /// <summary>
        /// Get contact for selected list
        /// </summary>
        /// <param name="listId">list id of a contact</param>
        /// <param name="contactId">contact id of contact</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetContactForList(int listId, int contactId)
        {
            var overrideResource = $"lists/{listId}";
            var result = base.Get($"contacts/{contactId}", null, overrideResource);
            return result;
        }
        /// <summary>
        /// Create or update contact for list
        /// </summary>
        /// <param name="listId">list id of the contact to be created</param>
        /// <param name="email">email address of contact</param>
        /// <param name="firstName">first name of contact</param>
        /// <param name="lastName">last name of contact</param>
        /// <param name="phone">phone number of contact</param>
        /// <param name="fax">fax of contact</param>
        /// <param name="uid">uid of contact</param>
        /// <param name="customField">customfield array object eg; { custom_field_1 = true, custom_field_2 = "abc" }</param>
        /// <param name="addTags">addtags array eg; { "tag1", "tag2", "tag3" }</param>
        /// <param name="removeTags">remove tags array eg; { "remove_tag1", "remove_tag2", "remove_tag3" }</param>
        /// <param name="removeFromDNM">removeFromDNM flag</param>
        /// <param name="subscribe">subscribe flag</param>
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
        /// Update contact for selected list and contact
        /// </summary>
        /// <param name="listId">list id of the contact to be created</param>
        /// <param name="contactId">contact id of contact</param>
        /// <param name="email">email address of contact</param>
        /// <param name="firstName">first name of contact</param>
        /// <param name="lastName">last name of contact</param>
        /// <param name="phone">phone number of contact</param>
        /// <param name="fax">fax of contact</param>
        /// <param name="uid">uid of contact</param>
        /// <param name="customField">customfield array object eg; { custom_field_1 = true, custom_field_2 = "abc" }</param>
        /// <param name="addTags">addtags array eg; { "tag1", "tag2", "tag3" }</param>
        /// <param name="removeTags">remove tags array eg; { "remove_tag1", "remove_tag2", "remove_tag3" }</param>
        /// <param name="removeFromDNM">removeFromDNM flag</param>
        /// <param name="subscribe">subscribe flag</param>
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
        /// Create or update contact by email
        /// </summary>
        /// <param name="email">email address of contact</param>
        /// <param name="firstName">first name of contact</param>
        /// <param name="lastName">last name of contact</param>
        /// <param name="phone">phone number of contact</param>
        /// <param name="fax">fax of contact</param>
        /// <param name="uid">uid of contact</param>
        /// <param name="customField">customfield array object eg; { custom_field_1 = true, custom_field_2 = "abc" }</param>
        /// <param name="addTags">addtags array eg; { "tag1", "tag2", "tag3" }</param>
        /// <param name="removeTags">remove tags array eg; { "remove_tag1", "remove_tag2", "remove_tag3" }</param>
        /// <param name="removeFromDNM">removeFromDNM flag</param>
        /// <param name="subscribe">subscribe flag</param>
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
            return base.Post("", null, contact);
        }
        /// <summary>
        /// Create or update contact for list and workflows
        /// </summary>
        /// <param name="email">email address of contact</param>
        /// <param name="firstName">first name of contact</param>
        /// <param name="lastName">last name of contact</param>
        /// <param name="phone">phone number of contact</param>
        /// <param name="fax">fax of contact</param>
        /// <param name="uid">uid of contact</param>
        /// <param name="customField">customfield array object eg; { custom_field_1 = true, custom_field_2 = "abc" }</param>
        /// <param name="addTags">addtags array eg; { "tag1", "tag2", "tag3" }</param>
        /// <param name="removeTags">remove tags array eg; { "remove_tag1", "remove_tag2", "remove_tag3" }</param>
        /// <param name="removeFromDNM">removeFromDNM flag</param>
        /// <param name="subscribeListIds">array of subscribe list ids array of int</param>
        /// <param name="unsubscribeListIds">array of unsubscribe list ids array of int</param>
        /// <param name="unsubscribeWorkflowIds">array of unsubscribe work flow ids array of int</param>
        /// <param name="unsubscribeCampaign">unsubscribe campaign</param>
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
                                                                           int[] unsubscribeListIds = null,
                                                                           int[] unsubscribeWorkflowIds = null,
                                                                           string unsubscribeCampaign = null)
        {
            var options = new
            {
                subscribe_list_ids = string.Join(",", subscribeListIds),
                unsubscribe_list_ids = string.Join(",", unsubscribeListIds),
                unsubscribe_workflow_ids = string.Join(",", unsubscribeWorkflowIds),
                unsubscribe_campaign = unsubscribeCampaign
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
        /// Delete contact from all provide lists
        /// </summary>
        /// <param name="email">email address of contact</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteFromAllLists(string email)
        {
            var keyValuePair = new KeyValueList { { "contact[email]", email } };
            return base.Delete("delete_all", keyValuePair);
        }
        /// <summary>
        /// Delete contact from list
        /// </summary>
        /// <param name="contactId">contact id of contact</param>
        /// <param name="listIds">list id of contact</param>
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
        /// Delete contact for uid
        /// </summary>
        /// <param name="uid">uid of contact</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteContactForUid(string uid)
        {
            var keyValuePair = new KeyValueList { { "uid", uid } };
            return base.Delete("delete_all", keyValuePair);
        }
        /// <summary>
        /// Delete list of contact from provided list id and contact
        /// </summary>
        /// <param name="listId">list id of contact</param>
        /// <param name="contactId">contact id of contact</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteListContact(int listId, int contactId)
        {
            var overrideResource = $"lists/{listId}";
            return base.Delete($"contacts/{contactId}", null, null, overrideResource);
        }
        /// <summary>
        /// Unsubscribe all contacts with provided field
        /// </summary>
        /// <param name="contactFieldValue">field value</param>
        /// <param name="contactFieldName">field name default is email</param>
        /// <returns></returns>
        public IOperationResult<dynamic> UnsubscribeAll(string contactFieldValue, string contactFieldName = "email")
        {
            var keyValuePair = new KeyValueList { { $"contact[{contactFieldName}]", contactFieldValue } };
            return base.Put("unsubscribe_all", keyValuePair);
        }
    }
}