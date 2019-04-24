using Maropost.Api.Dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;

namespace Maropost.Api
{
    internal static class Tools
    {
        internal static OperationResult<dynamic> ValidateOrderItems(this object[] orderItems)
        {
            var operation = new OperationResult<dynamic>(null, null, "");
            if (orderItems == null)
            {
                operation = new OperationResult<dynamic>(null, null, "No orderItems were provided. Each order must contain at least one orderItem.");
            }
            foreach (var orderItem in orderItems)
            {
                if (orderItem.GetType() != typeof(OrderItemInput))
                {
                    operation = new OperationResult<dynamic>(null, null, "All orderItems must be instance of Maropost.Api.Dto.OrderItemInput. At least on orderItem was not.");
                }
            }
            return operation;
        }

        internal static OperationResult<dynamic> ValidateCustomFields(this object customFields)
        {
            var operation = new OperationResult<dynamic>(null, null, "");
            foreach (var customField in customFields as IDictionary<string, object>)
            {
                if (!Regex.IsMatch($"{customField.Key}", "^[a-zA-Z]+$"))
                {
                    operation = new OperationResult<dynamic>(null, null, "All keys in your 'customFields' array must be strings.");
                }
                else if (customField.Value == null)
                {
                    operation = new OperationResult<dynamic>(null, null, "All values in your 'customFields' array must be non-null scalars (string, float, bool, int).");
                }
            }
            return operation;
        }

        internal static OperationResult<dynamic> ValidateProductIds(this object[] productIds)
        {
            var operation = new OperationResult<dynamic>(null, null, "");
            if (productIds == null || productIds.Length == 0)
            {
                operation = new OperationResult<dynamic>(null, null, "No productIds were provided.");
            }
            foreach (var productId in productIds)
            {
                if (!Regex.IsMatch($"{productId}", "^[0-9]+$"))
                {
                    operation = new OperationResult<dynamic>(null, null, "At least one productId is invalid.");
                }
            }
            return operation;
        }

        internal static IDictionary<string, object> DiscardNullAndEmptyValues(this IDictionary<string, object> keyValuePairs)
        {
            var keyValues = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Value != null)
                {
                    keyValues.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            return keyValues;
        }

        internal static bool IsValidEmail(this string email)
        {
            bool result = false;
            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            result = Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
            return result;
        }
    }
}