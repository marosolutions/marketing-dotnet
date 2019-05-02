using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace Maropost.Api
{
    public class RelationalTableRows : _BaseApi
    {
        /// <param name="accountId">required</param>
        /// <param name="authToken">required</param>
        /// <param name="httpClient">must be non-null</param>
        /// <exception cref="ArgumentException" />
        public RelationalTableRows(int accountId, string authToken, string tableName, HttpClient httpClient, string baseUrl = null)
            : base(accountId, authToken, tableName, httpClient, baseUrl) { }
        /// <summary>
        /// Gets the record from the relational table
        /// </summary>
        /// <returns></returns>
        public IOperationResult<dynamic> Get()
        {
            var result = base.Get("");
            return result;
        }
        /// <summary>
        /// Gets the specified record from the relational table
        /// </summary>
        /// <param name="idFieldName">name of the feld representing the unique identifier (eg; id, email)</param>
        /// <param name="idFieldVlaue">value of the identifier field for the record to get</param>
        /// <returns></returns>
        public IOperationResult<dynamic> Show(string idFieldName, string idFieldVlaue)
        {
            var fieldValuePair = new ExpandoObject() as IDictionary<string, object>;
            fieldValuePair.Add(idFieldName, idFieldVlaue);
            var record = new { record = fieldValuePair };
            var result = base.Post("show", null, record);
            return result;
        }
        /// <summary>
        /// Adds a record to the relational table
        /// </summary>
        /// <param name="keyValues">list of field name/values for the record to be updated</param>
        /// <returns></returns>
        public IOperationResult<dynamic> Create(IDictionary<string, object> keyValues)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValue in keyValues)
            {
                records.Add(keyValue.Key, keyValue.Value);
            }
            var requestRecords = new { record = records };
            var result = base.Post("create", null, requestRecords);
            return result;
        }
        /// <summary>
        /// Updates a record in the relational table
        /// </summary>
        /// <param name="keyValues">
        /// list of field name/values for the record to be updated.
        /// NOTE: Any datetime strings must be in on of the three formats: "MM/dd/yyyy", "yyyy-MM-dd" or "yyyy-MM-ddThh:mm:ssTZD"
        /// </param>
        /// <returns></returns>
        public IOperationResult<dynamic> Update(IDictionary<string, object> keyValues)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValue in keyValues)
            {
                records.Add(keyValue.Key, keyValue.Value);
            }
            var requestRecords = new { record = records };
            var result = base.Post("update", null, requestRecords);
            return result;
        }
        /// <summary>
        /// Creates or updates a record in the Relational Table.
        /// </summary>
        /// <param name="keyValues">
        /// list of field name/values for the record to be updated.
        /// NOTE: Any datetime strings must be in on of the three formats: "MM/dd/yyyy", "yyyy-MM-dd" or "yyyy-MM-ddThh:mm:ssTZD"
        /// </param>
        /// <returns></returns>
        public IOperationResult<dynamic> Upsert(IDictionary<string, object> keyValues)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValue in keyValues)
            {
                records.Add(keyValue.Key, keyValue.Value);
            }
            var requestRecords = new { record = records };
            var result = base.Post("upsert", null, requestRecords);
            return result;
        }
        /// <summary>
        /// Deletes the given record of the relational table
        /// </summary>
        /// <param name="idField">name of the field representing the unique identifier (eg; id, email)</param>
        /// <param name="idFieldValue">value of the identifier field for the record to delete</param>
        /// <returns></returns>
        public IOperationResult<dynamic> Delete(string idField, object idFieldValue)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            records.Add(idField, idFieldValue);
            var requestRecords = new { record = records };
            var result = base.Delete("delete", null, requestRecords);
            return result;
        }
    }
}
