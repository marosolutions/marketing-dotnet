using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class RelationalTableRowsTests : _BaseTests
    {
        private string tableName = "phpunit_testing_for_api";
        [Fact]
        public async Task Get()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            //Act
            var result = await api.Get();
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task Show()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            var getResult = await api.Get();
            string email = getResult.ResultData["records"][0]["email"];
            //Act
            var result = await api.Show("email", email);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            string actualEmail = result.ResultData["result"]["record"]["email"];
            Assert.Equal(email, actualEmail);
        }

        [Fact]
        public async Task Create()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            //Act
            var result = await api.Create(keyValuePair);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            int created = result.ResultData["result"]["created"];
            Assert.Equal(1, created);
        }

        [Fact]
        public async Task Update()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            var createResult = await api.Create(keyValuePair);
            var keyValuePairUpdate = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName_update" },
                { "lastName", "test_lastName_update" }
            };
            //Act
            var result = await api.Update(keyValuePairUpdate);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task Upsert_Create()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            //Act
            var result = await api.Upsert(keyValuePair);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            int created = result.ResultData["result"]["created"];
            Assert.Equal(1, created);
        }

        [Fact]
        public async Task Upsert_Update()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            var createResult = await api.Create(keyValuePair);
            var keyValuePairUpdate = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName_update" },
                { "lastName", "test_lastName_update" }
            };
            //Act
            var result = await api.Upsert(keyValuePairUpdate);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task Delete()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, HttpClient, tableName);
            var email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", $"{email}" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            var createResult = await api.Create(keyValuePair);
            //Act
            var result = await api.Delete("email", email);
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