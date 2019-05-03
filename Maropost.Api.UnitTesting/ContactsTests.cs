using System;
using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class ContactsTests : _BaseTests
    {
        [Fact]
        public async Task GetForList()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            //Act
            int listId = 1;
            var result = await api.GetForList(listId, 1);
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
        public async Task GetForEmail()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int listId = 1;
            var resultList = await api.GetForList(listId, 1);
            string email = resultList.ResultData[0]["email"];
            //Act
            var result = await api.GetForEmail(email);
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
        public async Task GetOpens()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int listId = 1;
            var resultList = await api.GetForList(listId, 1);
            int contactId = resultList.ResultData[0]["id"];
            //Act
            var result = await api.GetOpens(contactId, 1);
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
        public async Task GetClicks()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int contactId = 5;//TO DO
            //Act
            var result = await api.GetClicks(contactId, 1);
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
        public async Task GetContactForList()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            int listId = 1;
            var resultList = await api.GetForList(listId, 1);
            int contactId = resultList.ResultData[0]["id"];
            //Act
            var result = await api.GetContactForList(listId, contactId);
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
        public async Task CreateOrUpdateForList_Create()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            //Act
            var createResult = await api.CreateOrUpdateForList(1, email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Assert
            Assert.True(createResult.Success);
            Assert.True(string.IsNullOrEmpty(createResult.ErrorMessage));
            Assert.Null(createResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            Assert.Equal("dotnet_test_fm", resultFirstName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public async Task CreateOrUpdateForList_Update()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = api.CreateOrUpdateForList(1, email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Act
            var updateResult = await api.CreateOrUpdateForList(1, email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, true, true);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
        }

        [Fact]
        public async Task UpdateForListAndContact()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = await api.CreateOrUpdateForList(1, email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            string contactId = createResult.ResultData["id"];
            //Act
            var updateResult = await api.UpdateForListAndContact(1, $"{contactId}", email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, true, true);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
        }

        [Fact]
        public async Task CreateOrUpdateContact_Create()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            //Act
            var createResult = await api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Assert
            Assert.True(createResult.Success);
            Assert.True(string.IsNullOrEmpty(createResult.ErrorMessage));
            Assert.Null(createResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            Assert.Equal("dotnet_test_fm", resultFirstName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public async Task CreateOrUpdateContact_Update()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = await api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Act
            var updateResult = await api.CreateOrUpdateContact(email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, false, false);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public async Task CreateOrUpdateForListAndWorkflows_Create()
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
            var createResult = await api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            //Assert
            Assert.True(createResult.Success);
            Assert.True(string.IsNullOrEmpty(createResult.ErrorMessage));
            Assert.Null(createResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm", resultFirstName);
            Assert.Equal("dotnet_test_lm", resultLastName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public async Task CreateOrUpdateForListAndWorkflows_Update()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            var createResult = await api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            //Act
            var updateResult = await api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm_update", "dotnet_test_lm_update", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            //Assert
            Assert.True(updateResult.Success);
            Assert.True(string.IsNullOrEmpty(updateResult.ErrorMessage));
            Assert.Null(updateResult.Exception);
            var getResult = await api.GetForEmail(email);
            string resultEmail = getResult.ResultData["email"];
            string resultFirstName = getResult.ResultData["first_name"];
            string resultLastName = getResult.ResultData["last_name"];
            Assert.Equal("dotnet_test_fm_update", resultFirstName);
            Assert.Equal("dotnet_test_lm_update", resultLastName);
            Assert.Equal(email, resultEmail);
        }

        [Fact]
        public async Task DeleteFromAllLists()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            var createResult = await api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            int contactId = createResult.ResultData["id"];
            //Act
            var deleteResult = await api.DeleteFromAllLists(email);
            //Assert
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task DeleteFromLists()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var subscribeListIds = new[] { 21, 94, 95 };
            var unsubscribeWorkflowIds = new[] { 7, 45 };
            var createResult = await api.CreateOrUpdateForListAndWorkflows(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", null, customFields, tags, removeTags, false, subscribeListIds, new int[0], unsubscribeWorkflowIds);
            int contactId = createResult.ResultData["id"];
            //Act
            var deleteResult = await api.DeleteFromLists(contactId, new[] { 1 });
            //Assert
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task DeleteContactForUid()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = await api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", "xxx123", customFields, tags, removeTags, false, false);
            var getResult = await api.GetForEmail(email);
            string uid = getResult.ResultData["uid"];
            //Act
            var deleteResult = await api.DeleteContactForUid(uid);
            //Assert
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task DeleteListContact()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = await api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", "xxx123", customFields, tags, removeTags, false, false);
            int contactId = createResult.ResultData["id"];
            //Act
            var deleteResult = await api.DeleteListContact(1, contactId);
            //Assert
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task UnsubscribeAll()
        {
            //Arrange
            var api = new Contacts(AccountId, AuthToken, HttpClient);
            string email = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customFields = new { custom_field_1 = true, custom_field_2 = "abc", custom_field_3 = 123 };
            var tags = new[] { "tag1", "tag2", "tag3" };
            var removeTags = new[] { "remove_tag1", "remove_tag2", "remove_tag3" };
            var createResult = await api.CreateOrUpdateContact(email, "dotnet_test_fm", "dotnet_test_lm", "9999999999", "5555555555", "xxx123", customFields, tags, removeTags, false, false);
            //Act
            var unsubscribeResult = await api.UnsubscribeAll(email);
            //Assert
            Assert.True(unsubscribeResult.Success);
            Assert.True(string.IsNullOrEmpty(unsubscribeResult.ErrorMessage));
            Assert.Null(unsubscribeResult.Exception);
        }
    }
}