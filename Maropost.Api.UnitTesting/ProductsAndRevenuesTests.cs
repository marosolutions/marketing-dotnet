using Maropost.Api.Dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class ProductsAndRevenuesTests : _BaseTests
    {
        [Fact]
        public void GetOrder()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            var getResult = api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            //Act
            var result = api.GetOrder(orderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void GetOrderForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            //Act
            var result = api.GetOrderForOriginalOrderId(originalOrderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void CreateOrder()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            //Act
            var result = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void UpdateOrderForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2019-04-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            //Act
            var result = api.UpdateOrderForOriginalOrderId(originalOrderId, "2019-04-24T18:05:24-04:00", "Processed", orderItems);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void UpdateOrderForOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            var getResult = api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            //Act
            var result = api.UpdateOrderForOrderId(orderId, "2019-04-24T18:05:24-04:00", "Processed", orderItems);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void DeleteForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            //Act
            var result = api.DeleteForOriginalOrderId(originalOrderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }

        [Fact]
        public void DeleteForOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            var getResult = api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            //Act
            var result = api.DeleteForOrderId(orderId);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void DeleteProductsForOriginalOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            var productIds = new[] { "12", "13", "14" };
            //Act
            var result = api.DeleteProductsForOriginalOrderId(originalOrderId, productIds);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }

        [Fact]
        public void DeleteProductsForOrderId()
        {
            //Arrange
            var api = new ProductsAndRevenues(AccountId, AuthToken, HttpClient);
            string originalOrderId = $"dotnet_test{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}";
            var orderItems = new[] { new OrderItemInput("2","1340", "2", "test_description_2", "ad_code_2", "category_2"),
                                     new OrderItemInput("3","1350", "3", "test_description_3", "ad_code_3", "category_3")};
            string email = $"test_email_{DateTime.UtcNow.ToString("yyyyMMddhhmmssfff")}@maropost.com";
            var customField = new ExpandoObject() as IDictionary<string, object>;
            customField.Add("country", "test_country");
            customField.Add("gender", "male");
            var addTags = new[] { "tag_name1", "tag_name2" };
            var removeTags = new[] { "rm_tag_name1", "rm_tag_name2" };
            var createResult = api.CreateOrder(true, email, "test_firstName", "test_lastName", "2017-10-13T18:05:24-04:00", "Processed", originalOrderId, orderItems, customField, addTags, removeTags, "abcd", "12,13", "1234");
            var getResult = api.GetOrderForOriginalOrderId(originalOrderId);
            int orderId = getResult.ResultData["id"];
            var productIds = new[] { "12", "13", "14" };
            //Act
            var result = api.DeleteProductsForOrderId(orderId, productIds);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            //Delete
            var deleteResult = api.DeleteForOriginalOrderId(originalOrderId);
            Assert.True(deleteResult.Success);
            Assert.True(string.IsNullOrEmpty(deleteResult.ErrorMessage));
            Assert.Null(deleteResult.Exception);
        }
    }
}