using System;
using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class ReportsTests : _BaseTests
    {
        [Fact]
        public async Task Get()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.Get(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetReport()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetReport(19);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetOpens_WithPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetOpens(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetOpens_WithFields()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            //Act
            var result = await api.GetOpens(1, fields);
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
        public async Task GetOpens_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            var from = DateTime.Parse("2016-06-28");
            var to = DateTime.Parse("2017-06-28");
            var unique = true;
            var per = 4;
            //Act
            var result = await api.GetOpens(1, fields, from, to, unique, null, null, per);
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

        [Fact]
        public async Task GetClicks_WithPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetClicks(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetClicks_WithFields()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            //Act
            var result = await api.GetClicks(1, fields);
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
        public async Task GetClicks_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            var from = DateTime.Parse("2016-06-28");
            var to = DateTime.Parse("2017-06-28");
            var unique = true;
            var per = 4;

            //Act
            var result = await api.GetClicks(1, fields, from, to, unique, null, null, per);
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

        [Fact]
        public async Task GetBounce_WithPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetBounce(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetBounce_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            var from = DateTime.Parse("2016-06-28");
            var to = DateTime.Parse("2017-06-28");
            var unique = true;
            var type = "hard";
            var per = 4;

            //Act
            var result = await api.GetBounce(1, fields, from, to, unique, null, null, type, per);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            DateTime recordDate = result.ResultData[0]["recorded_on"];
            Assert.True(recordDate <= to);
            Assert.True(recordDate >= from);
        }

        [Fact]
        public async Task GetUnsubscribes_WithPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetUnsubscribes(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetUnsubscribes_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            var from = DateTime.Parse("2016-06-28");
            var to = DateTime.Parse("2017-06-28");
            var unique = true;
            var per = 4;
            //Act
            var result = await api.GetUnsubscribes(1, fields, from, to, unique, null, null, per);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            DateTime recordDate = result.ResultData[0]["recorded_on"];
            Assert.True(recordDate <= to);
            Assert.True(recordDate >= from);
        }

        [Fact]
        public async Task GetComplaints_WithPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetComplaints(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetComplaints_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var fields = new[] { "email", "first_name", "last_name" };
            var from = DateTime.Parse("2016-06-28");
            var to = DateTime.Parse("2017-06-28");
            var unique = true;
            var per = 4;
            //Act
            var result = await api.GetComplaints(1, fields, from, to, unique, null, null, per);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            DateTime recordDate = result.ResultData[0]["recorded_on"];
            Assert.True(recordDate <= to);
            Assert.True(recordDate >= from);
        }

        [Fact]
        public async Task GetAbReports_WithNameAndPage()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetAbReports("Test", 1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }

        [Fact]
        public async Task GetAbReports_WithParams()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            var from = DateTime.Parse("2017-06-28");
            var to = DateTime.Parse("2018-06-28");
            var per = 4;
            //Act
            var result = await api.GetAbReports("Test", 1, from, to, per);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
            DateTime recordDate = result.ResultData[0]["created_at"];
            Assert.True(recordDate <= to);
            Assert.True(recordDate >= from);
        }

        [Fact]
        public async Task GetJourney()
        {
            //Arrange
            var api = new Reports(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.GetJourney(1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.NotNull(result.ResultData);
        }
    }
}