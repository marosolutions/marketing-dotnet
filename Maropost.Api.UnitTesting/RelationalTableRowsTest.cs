using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class RelationalTableRowsTest : _BaseTests
    {
        private string tableName = "relational_tables";
        [Fact]
        public void Get()
        {
            //Arrange
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient);
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
            var api = new RelationalTableRows(AccountId, AuthToken, tableName, HttpClient);
            //Act
            var result = api.Show("email", "asdf@marapost.com");
            //Assert

        }
    }
}