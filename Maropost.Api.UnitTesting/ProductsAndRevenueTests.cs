using Maropost.Api.Dto;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class ProductsAndRevenueTests : _BaseTests
    {
        [Fact]
        public async Task GetOrder()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            var getResult = await api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            //Act
            var result = await api.GetOrder(orderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = await api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task GetOrderForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            //Act
            var result = await api.GetOrderForOriginalOrderId(originalOrderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = await api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task CreateOrder()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            //Act
            var result = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = await api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task UpdateOrderForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            //Act
            var result = await api.UpdateOrderForOriginalOrderId(originalOrderId, "2019-04-24T18:05:24-04:00", "Processed", orderItems);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = await api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task UpdateOrderForOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            var getResult = await api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = await getResult.ResultData["id"];
            //Act
            var result = await api.UpdateOrderForOrderId(orderId, "2019-04-24T18:05:24-04:00", "Processed", orderItems);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = await api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public async Task DeleteForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            //Act
            var result = await api.DeleteForOriginalOrderId(originalOrderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }

        [Fact]
        public async Task DeleteForOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            var getResult = await api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            //Act
            var result = await api.DeleteForOrderId(orderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }

        [Fact]
        public async Task DeleteProductsForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            var productIds = new[] { "12", "13", "14" };
            //Act
            var result = await api.DeleteProductsForOriginalOrderId(originalOrderId, productIds);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }

        [Fact]
        public async Task DeleteProductsForOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenue(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var createResult = await api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems);
            var getResult = await api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            var productIds = new[] { "12", "13", "14" };
            //Act
            var result = await api.DeleteProductsForOrderId(orderId, productIds);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }
    }
}