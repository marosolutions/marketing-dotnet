using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class RelationalTableRowsTest : _BaseTests
    {
        private string tableName = "phpunit_testing_for_api";
        private string baseUrl = "https://rdb.maropost.com/accounts/{0}/";
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
            //Act
            var result = api.Show("email", "asdf@marapost.com");
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void Create()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", "asdf@marapost.com" },
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
        }

        [Fact]
        public void Update()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", "asdf@marapost.com" },
                { "firstName", "test_firstName" },
                { "lastName", "test_lastName" }
            };
            //Act
            var result = api.Update(keyValuePair);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void Upsert()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            var keyValuePair = new Dictionary<string, object>
            {
                { "email", "asdf@marapost.com" },
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
        }

        [Fact]
        public void Delete()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient, baseUrl);
            //Act
            var result = api.Delete("email", "asdf@marapost.com");
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }
    }
}