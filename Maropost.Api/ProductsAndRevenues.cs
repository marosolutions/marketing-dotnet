using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace Maropost.Api
{
    public class ProductsAndRevenues : _BaseApi
    {
        public ProductsAndRevenues(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "orders", httpClient)
        { }
        /// <summary>
        /// Gets order detais filtered with order id
        /// </summary>
        /// <param name="id">order id to filter</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetOrder(int id)
        {
            var result = base.Get("find", new KeyValueList { { "where[id]", $"{id}" } });
            return result;
        }
        /// <summary>
        /// Gets order details filtered with original order id
        /// </summary>
        /// <param name="originalOrderId">original order id to filter</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetOrderForOriginalOrderId(string originalOrderId)
        {
            var result = base.Get(originalOrderId, null);
            return result;
        }
        /// <summary>
        /// Create order with provided order details
        /// </summary>
        /// <param name="requireUnique">true to validate that the order has a unique original_order_id for the given contact</param>
        /// <param name="contactEmail">email address of contact</param>
        /// <param name="contactFirstName">first name of contact</param>
        /// <param name="contactLastName">last name of contact</param>
        /// <param name="orderDateTime">uses the format: "YYYY-MM-DDTHH:MM:SS-05:00</param>
        /// <param name="orderStatus">status of order</param>
        /// <param name="originalOrderId">sets the original_order_id field</param>
        /// <param name="orderItems">array of Maropost.Api.Dto.OrderItemInput object</param>
        /// <param name="customFields">associative array where the key (string) represents the field name and the value is the field value</param>
        /// <param name="addTags">simple array of tags to add (scalar values)</param>
        /// <param name="removeTags">simple array of tags to remove (scalar values)</param>
        /// <param name="uid">unique id</param>
        /// <param name="listIds">CSV list of IDs (e.g, "12,13")</param>
        /// <param name="grandTotal">grand total</param>
        /// <param name="campaignId">campaign id</param>
        /// <param name="couponCode">coupon code</param>
        /// <returns></returns>
        public IOperationResult<dynamic> CreateOrder(bool requireUnique,
                                                     string contactEmail,
                                                     string contactFirstName,
                                                     string contactLastName,
                                                     string orderDateTime,
                                                     string orderStatus,
                                                     string originalOrderId,
                                                     OrderItemInput[] orderItems,
                                                     object customFields = null,
                                                     object[] addTags = null,
                                                     object[] removeTags = null,
                                                     string uid = null,
                                                     string listIds = null,
                                                     string grandTotal = null,
                                                     int? campaignId = null,
                                                     string couponCode = null)
        {
            if (string.IsNullOrEmpty(contactEmail))
            {
                return new OperationResult<dynamic>(null, null, "The provided 'contactEmail' is not a well-formed email address.");
            }
            var orderItemsValidate = orderItems.ValidateOrderItems();
            if (!orderItemsValidate.Success)
            {
                return orderItemsValidate;
            }
            var order = new ExpandoObject() as IDictionary<string, object>;
            order.Add("contact", new { email = contactEmail, first_name = contactFirstName, last_name = contactLastName });
            order.Add("order_date", orderDateTime);
            order.Add("order_status", orderStatus);
            order.Add("original_order_id", originalOrderId);
            order.Add("order_items", orderItems);
            order.Add("uid", uid);
            order.Add("campaign_id", campaignId);
            order.Add("coupon_code", couponCode);
            order.Add("grand_total", grandTotal);

            if (!string.IsNullOrEmpty(listIds))
            {
                order.Add("list_ids", listIds);
            }
            if (customFields != null)
            {
                var customFieldsValidate = customFields.ValidateCustomFields();
                if (!customFieldsValidate.Success)
                {
                    return customFieldsValidate;
                }
                order.Add("custom_field", customFields);
            }
            if (addTags != null)
            {
                order.Add("add_tags", addTags);
            }
            if (removeTags != null)
            {
                order.Add("remove_tags", removeTags);
            }
            var orderArray = new { order };
            var keyValuePair = new KeyValueList { { "unique", "true" } };
            var result = base.Post("", keyValuePair, orderArray);
            return result;
        }
        /// <summary>
        /// Updates an existing eCommerce order using unique original_order_id if the details are changed due to partial
        /// return or some other update.
        /// </summary>
        /// <param name="originalOrderId">matches the original_order_id field of the order</param>
        /// <param name="orderDateTime">uses the format: YYYY-MM-DDTHH:MM:SS-05:00</param>
        /// <param name="orderStatus">order status</param>
        /// <param name="orderItems">restates the orderItems as as array of OrderItemInput objects</param>
        /// <param name="campaignId">campaign id</param>
        /// <param name="couponCode">coupon code</param>
        /// <returns></returns>
        public IOperationResult<dynamic> UpdateOrderForOriginalOrderId(string originalOrderId,
                                                                       string orderDateTime,
                                                                       string orderStatus,
                                                                       object[] orderItems,
                                                                       int? campaignId = null,
                                                                       string couponCode = null)
        {
            var orderItemsValidate = orderItems.ValidateOrderItems();
            if (!orderItemsValidate.Success)
            {
                return orderItemsValidate;
            }
            var order = new ArrayList
            {
                new { order_date = orderDateTime },
                new { order_status = orderStatus },
                new { campaign_id = campaignId },
                new { coupon_code = couponCode },
                new { order_items = orderItems }
            };
            var orderArray = new[] { order };
            var result = base.Put(originalOrderId, null, orderArray);
            return result;
        }
        /// <summary>
        /// Updates an existing eCommerce order using unique order_id if the details are changed due to partial return or
        /// some other update.
        /// </summary>
        /// <param name="orderId">matches the Maropost order_id field of the order</param>
        /// <param name="orderDateTime">uses the format: YYYY-MM-DDTHH:MM:SS-05:00</param>
        /// <param name="orderStatus">order status</param>
        /// <param name="orderItems">restates the orderItems as as array of OrderItemInput objects</param>
        /// <param name="campaignId">campaign id</param>
        /// <param name="couponCode">coupon code</param>
        /// <returns></returns>
        public IOperationResult<dynamic> UpdateOrderForOrderId(int orderId,
                                                               string orderDateTime,
                                                               string orderStatus,
                                                               object[] orderItems,
                                                               int? campaignId = null,
                                                               string couponCode = null)
        {
            var orderItemsValidate = orderItems.ValidateOrderItems();
            if (!orderItemsValidate.Success)
            {
                return orderItemsValidate;
            }
            var order = new ArrayList
            {
                new { order_date = orderDateTime },
                new { order_status = orderStatus },
                new { campaign_id = campaignId },
                new { coupon_code = couponCode },
                new { order_items = orderItems }
            };
            var orderArray = new[] { order };
            var keyValuePair = new KeyValueList { { "where[id]", $"{orderId}" } };
            var result = base.Put("find", keyValuePair, orderArray);
            return result;
        }
        /// <summary>
        /// Deletes the complete eCommerce order if the order is cancelled or returned using unique original order id
        /// </summary>
        /// <param name="originalOrderId">matches the original_order_id field of the order</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteForOriginalOrderId(string originalOrderId)
        {
            var result = base.Delete(originalOrderId);
            return result;
        }
        /// <summary>
        /// Deletes the complete eCommerce order if the order is cancelled or returned using Maropost order id
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteForOrderId(int id)
        {
            var keyValuePair = new KeyValueList { { "where[id]", $"{id}" } };
            var result = base.Delete("find", keyValuePair);
            return result;
        }
        /// <summary>
        /// Deletes the specified product(s) from a complete eCommerce order if the product(s) is cancelled or returned,
        /// using unique original_order_id
        /// </summary>
        /// <param name="originalOrderId">matches the original_order_id field of the order</param>
        /// <param name="productIds">the product(s) to delete from the order</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteProductsForOriginalOrderId(string originalOrderId,
                                                                          object[] productIds)
        {
            var productIdsValidate = productIds.ValidateProductIds();
            if (!productIdsValidate.Success)
            {
                return productIdsValidate;
            }
            var keyValuePair = new KeyValueList { { "product_id", string.Join(",", productIds) } };
            return base.Delete(originalOrderId, keyValuePair);
        }
        /// <summary>
        /// Deletes the specified product(s) from a complete eCommerce order if the product(s) is cancelled or returned,
        /// using Maropost order_id
        /// </summary>
        /// <param name="id">order id</param>
        /// <param name="productIds">the product(s) to delete from the order</param>
        /// <returns></returns>
        public IOperationResult<dynamic> DeleteProductsForOrderId(int id,
                                                                  object[] productIds)
        {
            var productIdsValidate = productIds.ValidateProductIds();
            if (!productIdsValidate.Success)
            {
                return productIdsValidate;
            }
            var keyValuePair = new KeyValueList { { "product_id", string.Join(",", productIds) }, { "where[id]", $"{id}" } };
            return base.Delete("find", keyValuePair);
        }
    }
}