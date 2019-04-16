using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class ContactsTests : _BaseTests
    {
        [Fact]
        public void GetForList()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            //Act
            int listId = 1;
            var result = api.GetForList(listId, 1);
            //Assert
            int accountId = result.ResultData[0]["account_id"];
            int id = result.ResultData[0]["id"];
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.Equal(id, listId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void GetForEmail()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int listId = 1;
            var resultList = api.GetForList(listId, 1);
            string email = resultList.ResultData[0]["email"];
            //Act
            var result = api.GetForEmail(email);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            int id = result.ResultData["id"];
            int accountId = result.ResultData["account_id"];
            string resultEmail = result.ResultData["email"];
            Assert.Equal(id, listId);
            Assert.Equal(accountId, AccountId);
            Assert.Equal(resultEmail, email);
        }

        [Fact]
        public void GetOpens()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int listId = 1;
            var resultList = api.GetForList(listId, 1);
            int contactId = resultList.ResultData[0]["id"];
            //Act
            var result = api.GetOpens(contactId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            foreach (var openReport in result.ResultData)
            {
                int id = openReport["contact_id"];
                Assert.Equal(id, contactId);
            }
        }

        [Fact]
        public void GetClicks()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int contactId = 5;//TO DO
            //Act
            var result = api.GetClicks(contactId, 1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            foreach (var openReport in result.ResultData)
            {
                int id = openReport["contact_id"];
                Assert.Equal(id, contactId);
            }
        }

        [Fact]
        public void GetContactForList()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int listId = 1;
            var resultList = api.GetForList(listId, 1);
            int contactId = resultList.ResultData[0]["id"];
            //Act
            var result = api.GetContactForList(listId, contactId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            int id = result.ResultData["id"];
            int accountId = result.ResultData["account_id"];
            Assert.Equal(id, contactId);
            Assert.Equal(accountId, AccountId);
        }

        [Fact]
        public void CreateOrUpdateForList_Create()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            //Act
            var createResult = api.CreateOrUpdateForList(1, email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Assert
            Assert.True(createResult.Success);
            Assert.True(string.IsNullOrEmpty(createResult.ErrorMessage));
            Assert.Null(createResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            Assert.Equal("dotnet_test_fm", resultFirstName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public void CreateOrUpdateForList_Update()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = api.CreateOrUpdateForList(1, email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Act
            var updateResult = api.CreateOrUpdateForList(1, email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, true, true);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
        }

        [Fact]
        public void UpdateForListAndContact()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = api.CreateOrUpdateForList(1, email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            string contactId = createResult.ResultData["id"];
            //Act
            var updateResult = api.UpdateForListAndContact(1, $"{contactId}", email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, true, true);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
        }

        [Fact]
        public void CreateOrUpdateContact_Create()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            //Act
            var createResult = api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Assert
            Assert.True(createResult.Success);
            Assert.True(string.IsNullOrEmpty(createResult.ErrorMessage));
            Assert.Null(createResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            Assert.Equal("dotnet_test_fm", resultFirstName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public void CreateOrUpdateContact_Update()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Act
            var updateResult = api.CreateOrUpdateContact(email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public void CreateOrUpdateForListAndWorkflows_Create()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            //Act
            var createResult = api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            //Assert
            Assert.True(createResult.Success);
            Assert.True(string.IsNullOrEmpty(createResult.ErrorMessage));
            Assert.Null(createResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm", resultFirstName);
            Assert.Equal("dotnet_test_lm", resultLastName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public void CreateOrUpdateForListAndWorkflows_Update()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            var createResult = api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            //Act
            var updateResult = api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public void DeleteFromAllLists()
        {

        }

        [Fact]
        public void DeleteFromLists()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            var createResult = api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            int contactId = createResult.ResultData["id"];
            //Act
            var deleteResult = api.DeleteFromLists(contactId, new[] { 1 });
            //Assert
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void DeleteContactForUid()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            var createResult = api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            string uid = createResult.ResultData["uid"];
            //Act
            var deleteResult = api.DeleteContactForUid(uid);
            //Assert
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void DeleteListContact()
        {

        }

        [Fact]
        public void UnsubscribeAll()
        {

        }
    }
}