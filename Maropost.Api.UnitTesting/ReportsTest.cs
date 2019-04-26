using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class ReportsTest : _BaseTests
    {
        [Fact]
        public void Get()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = api.Get(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void GetReport()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var getResult = api.Get(1);
            //Act
            var result = api.GetReport(4829);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void GetOpens_WithPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = api.GetOpens(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public void GetOpens_WithFields()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            //Act
            var result = api.GetOpens(1, fields);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            var email = result.ResultData[0]["contact"]["email"];
            var first_name = result.ResultData[0]["contact"]["first_name"];
            var last_name = result.ResultData[0]["contact"]["last_name"];
            Assert.NotNull(email);
            Assert.NotNull(first_name);
            Assert.NotNull(last_name);
        }

        [Fact]
        public void GetOpens_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            var from = DateTime.Parse("2016-06-28");
            var to = DateTime.Parse("2017-06-28");
            var unique = true;
            var per = 4;
            //Act
            var result = api.GetOpens(1, fields, from, to, unique, null, null, per);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            var email = result.ResultData[0]["contact"]["email"];
            var first_name = result.ResultData[0]["contact"]["first_name"];
            var last_name = result.ResultData[0]["contact"]["last_name"];
            DateTime recordDate = result.ResultData[0]["recorded_at"];
            Assert.NotNull(email);
            Assert.NotNull(first_name);
            Assert.NotNull(last_name);
            Assert.True(recordDate <= to);
            Assert.True(recordDate >= from);
        }
    }
}