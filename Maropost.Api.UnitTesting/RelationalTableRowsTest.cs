using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class RelationalTableRowsTest : _BaseTests
    {
        private string tableName = "phpunit_testing_for_api";
        private string baseUrl = "https://rdb.maropost.com/{0}/";
        [Fact]
        public void Get()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            //Act
            var result = api.Get();
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void Show()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var getResult = api.Get();
            string email = getResult.ResultData["records"][0]["email"];
            //Act
            var result = api.Show("email", email);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            string actualEmail = result.ResultData["result"]["record"]["email"];
            Assert.Equal(email, actualEmail);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            //Act
            var result = api.Create(keyValuePair);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            int created = result.ResultData["result"]["created"];
            Assert.Equal(1, created);
        }

        [Fact]
        public void Update()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            var createResult = api.Create(keyValuePair);
            var keyValuePairUpdate = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName_update" },
                { "lastName", "test_lastName_update" }
            };
            //Act
            var result = api.Update(keyValuePairUpdate);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void Upsert_Create()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            //Act
            var result = api.Upsert(keyValuePair);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            int created = result.ResultData["result"]["created"];
            Assert.Equal(1, created);
        }

        [Fact]
        public void Upsert_Update()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            var createResult = api.Create(keyValuePair);
            var keyValuePairUpdate = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName_update" },
                { "lastName", "test_lastName_update" }
            };
            //Act
            var result = api.Upsert(keyValuePairUpdate);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            var createResult = api.Create(keyValuePair);
            //Act
            var result = api.Delete("email", email);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            string actualEmail = result.ResultData["record"]["email"];
            Assert.Equal(email, actualEmail);
        }
    }
}