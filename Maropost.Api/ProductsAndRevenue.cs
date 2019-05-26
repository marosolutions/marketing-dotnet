using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Maropost.Api
{
    public class ProductsAndRevenue : _BaseApi
    {
        /// <param name="accountId">required</param>
        /// <param name="authToken">required</param>
        /// <param name="httpClient">must be non-null</param>
        /// <exception cref="ArgumentException" />
        public ProductsAndRevenue(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "orders", httpClient)
        { }
        /// <summary>
        /// Gets order detais filtered with order id
        /// </summary>
        /// <param name="id">order id to filter</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetOrder(int id)
        {
            var result = await base.Get("find", new KeyValueList { { "where[id]", $"{id}" } });
            return result;
        }
        /// <summary>
        /// Gets order details filtered with original order id
        /// </summary>
        /// <param name="originalOrderId">original order id to filter</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> GetOrderForOriginalOrderId(string originalOrderId)
        {
            var result = await base.Get(originalOrderId, null);
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
        /// <param name="orderItems">must contain at least one orderItem</param>
        /// <param name="customFields">Dictionary Item key represents the field name and the Dictionary Item value is the field value</param>
        /// <param name="addTags">tags to add</param>
        /// <param name="removeTags">tags to remove</param>
        /// <param name="uid">unique id</param>
        /// <param name="listIds">CSV list of IDs (e.g, "12,13")</param>
        /// <param name="grandTotal">grand total</param>
        /// <param name="campaignId">campaign id</param>
        /// <param name="couponCode">coupon code</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> CreateOrder(bool requireUnique,
                                                     string contactEmail,
                                                     string contactFirstName,
                                                     string contactLastName,
                                                     string orderDateTime,
                                                     string orderStatus,
                                                     string originalOrderId,
                                                     IEnumerable<OrderItemInput> orderItems,
                                                     IDictionary<string, string> customFields = null,
                                                     IEnumerable<string> addTags = null,
                                                     IEnumerable<string> removeTags = null,
                                                     string uid = null,
                                                     string listIds = null,
                                                     decimal? grandTotal = null,
                                                     int? campaignId = null,
                                                     string couponCode = null)
        {
            if (string.IsNullOrEmpty(contactEmail))
            {
                return new OperationResult<dynamic>(null, e: new ArgumentException("The provided 'contactEmail' is not a well-formed email address.", "contactEmail"));
            }
            if (orderItems == null || orderItems.Count() == 0)
            {
                return new OperationResult<dynamic>(null, e: new ArgumentException("must provide at least one orderItem", "orderItems"));
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
            order.Add("grand_total", grandTotal?.ToString());

            if (!string.IsNullOrEmpty(listIds))
            {
                order.Add("list_ids", listIds);
            }
            if (customFields != null && customFields.Any())
            {
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
            var result = await base.Post("", keyValuePair, orderArray);
            return result;
        }
        /// <summary>
        /// Updates an existing eCommerce order using unique original_order_id if the details are changed due to partial
        /// return or some other update.
        /// </summary>
        /// <param name="originalOrderId">matches the original_order_id field of the order</param>
        /// <param name="orderDateTime">uses the format: YYYY-MM-DDTHH:MM:SS-05:00</param>
        /// <param name="orderStatus">order status</param>
        /// <param name="orderItems">must provide at least one orderItem</param>
        /// <param name="campaignId">campaign id</param>
        /// <param name="couponCode">coupon code</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> UpdateOrderForOriginalOrderId(string originalOrderId,
                                                                       string orderDateTime,
                                                                       string orderStatus,
                                                                       IEnumerable<OrderItemInput> orderItems,
                                                                       int? campaignId = null,
                                                                       string couponCode = null)
        {
            if (orderItems == null || !orderItems.Any())
            {
                return new OperationResult<dynamic>(null, e: new ArgumentException("must provide at least one orderItem", "orderItems"));
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
            var result = await base.Put(originalOrderId, null, orderArray);
            return result;
        }
        /// <summary>
        /// Updates an existing eCommerce order using unique order_id if the details are changed due to partial return or
        /// some other update.
        /// </summary>
        /// <param name="orderId">matches the Maropost order_id field of the order</param>
        /// <param name="orderDateTime">uses the format: YYYY-MM-DDTHH:MM:SS-05:00</param>
        /// <param name="orderStatus">order status</param>
        /// <param name="orderItems">must provide at least one orderItem</param>
        /// <param name="campaignId">campaign id</param>
        /// <param name="couponCode">coupon code</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> UpdateOrderForOrderId(int orderId,
                                                               string orderDateTime,
                                                               string orderStatus,
                                                               IEnumerable<OrderItemInput> orderItems,
                                                               int? campaignId = null,
                                                               string couponCode = null)
        {
            if (orderItems == null || !orderItems.Any())
            {
                return new OperationResult<dynamic>(null, e: new ArgumentException(), errorMessage: "must provide at least one orderItem");
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
            var result = await base.Put("find", keyValuePair, orderArray);
            return result;
        }
        /// <summary>
        /// Deletes the complete eCommerce order if the order is cancelled or returned using unique original order id
        /// </summary>
        /// <param name="originalOrderId">matches the original_order_id field of the order</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> DeleteForOriginalOrderId(string originalOrderId)
        {
            var result = await base.Delete(originalOrderId);
            return result;
        }
        /// <summary>
        /// Deletes the complete eCommerce order if the order is cancelled or returned using Maropost order id
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> DeleteForOrderId(int id)
        {
            var keyValuePair = new KeyValueList { { "where[id]", $"{id}" } };
            var result = await base.Delete("find", keyValuePair);
            return result;
        }
        /// <summary>
        /// Deletes the specified product(s) from a complete eCommerce order if the product(s) is cancelled or returned,
        /// using unique original_order_id
        /// </summary>
        /// <param name="originalOrderId">matches the original_order_id field of the order</param>
        /// <param name="productIds">the product(s) to delete from the order</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> DeleteProductsForOriginalOrderId(string originalOrderId,
                                                                          object[] productIds)
        {
            var productIdsValidate = productIds.ValidateProductIds();
            if (!productIdsValidate.Success)
            {
                return productIdsValidate;
            }
            var keyValuePair = new KeyValueList { { "product_id", string.Join(",", productIds) } };
            return await base.Delete(originalOrderId, keyValuePair);
        }
        /// <summary>
        /// Deletes the specified product(s) from a complete eCommerce order if the product(s) is cancelled or returned,
        /// using Maropost order_id
        /// </summary>
        /// <param name="id">order id</param>
        /// <param name="productIds">the product(s) to delete from the order</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> DeleteProductsForOrderId(int id,
                                                                  object[] productIds)
        {
            var productIdsValidate = productIds.ValidateProductIds();
            if (!productIdsValidate.Success)
            {
                return productIdsValidate;
            }
            var keyValuePair = new KeyValueList { { "product_id", string.Join(",", productIds) }, { "where[id]", $"{id}" } };
            return await base.Delete("find", keyValuePair);
        }
    }
}