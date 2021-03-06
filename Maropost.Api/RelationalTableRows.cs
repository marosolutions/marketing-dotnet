﻿using Maropost.Api.Dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Maropost.Api
{
    public class RelationalTableRows : _BaseApi
    {
        private static string baseUrl = "https://rdb.maropost.com/{0}/";

        public string TableName
        {
            get
            {
                return UrlPathRoot;
            }
            set
            {
                UrlPathRoot = value;
            }
        }

        /// <param name="accountId">required</param>
        /// <param name="authToken">required</param>
        /// <param name="httpClient">must be non-null</param>
        /// <exception cref="ArgumentException" />
        public RelationalTableRows(int accountId, string authToken, HttpClient httpClient, string tableName)
            : base(accountId, authToken, tableName, httpClient, baseUrl) { }
        /// <summary>
        /// Gets the record from the relational table
        /// </summary>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Get()
        {
            var result = await base.Get("");
            return result;
        }
        /// <summary>
        /// Gets the specified record from the relational table
        /// </summary>
        /// <param name="idFieldName">name of the feld representing the unique identifier (eg; id, email)</param>
        /// <param name="idFieldVlaue">value of the identifier field for the record to get</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Show(string idFieldName, string idFieldVlaue)
        {
            var fieldValuePair = new ExpandoObject() as IDictionary<string, object>;
            fieldValuePair.Add(idFieldName, idFieldVlaue);
            var record = new { record = fieldValuePair };
            var result = await base.Post("show", null, record);
            return result;
        }
        /// <summary>
        /// Adds a record to the relational table
        /// </summary>
        /// <param name="keyValues">list of field name/values for the record to be updated</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Create(IDictionary<string, object> keyValues)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValue in keyValues)
            {
                records.Add(keyValue.Key, keyValue.Value);
            }
            var requestRecords = new { record = records };
            var result = await base.Post("create", null, requestRecords);
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
        public async Task<IOperationResult<dynamic>> Update(IDictionary<string, object> keyValues)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValue in keyValues)
            {
                records.Add(keyValue.Key, keyValue.Value);
            }
            var requestRecords = new { record = records };
            var result = await base.Post("update", null, requestRecords);
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
        public async Task<IOperationResult<dynamic>> Upsert(IDictionary<string, object> keyValues)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            foreach (var keyValue in keyValues)
            {
                records.Add(keyValue.Key, keyValue.Value);
            }
            var requestRecords = new { record = records };
            var result = await base.Post("upsert", null, requestRecords);
            return result;
        }
        /// <summary>
        /// Deletes the given record of the relational table
        /// </summary>
        /// <param name="idField">name of the field representing the unique identifier (eg; id, email)</param>
        /// <param name="idFieldValue">value of the identifier field for the record to delete</param>
        /// <returns></returns>
        public async Task<IOperationResult<dynamic>> Delete(string idField, object idFieldValue)
        {
            var records = new ExpandoObject() as IDictionary<string, object>;
            records.Add(idField, idFieldValue);
            var requestRecords = new { record = records };
            var result = await base.Delete("delete", null, requestRecords);
            return result;
        }
    }
}
