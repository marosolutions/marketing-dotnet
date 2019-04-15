﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Maropost.Api.Dto
{
    public interface IOperationResult
    {
        string ErrorMessage { get; set; }
        Exception Exception { get; set; }
        bool Success { get; }
    }

    public interface IOperationResult<T> : IOperationResult
    {
        T ResultData { get; set; }
    }

    public class OperationResult : IOperationResult
    {
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                if (!string.IsNullOrEmpty(_errorMessage))
                {
                    return _errorMessage;
                }
                if (Exception != null)
                {
                    // return the inner-most Exception message (up to 10 layers of InnerExceptions).
                    var exception = Exception;
                    var i = 0;
                    while (exception.InnerException != null && i++ < 10)
                    {
                        exception = exception.InnerException;
                    }
                    return exception.Message;
                }
                return null;
            }
            set { _errorMessage = value; }
        }
        public Exception Exception { get; set; }
        public bool Success
        {
            get
            {
                return Exception == null && String.IsNullOrEmpty(ErrorMessage);
            }
        }

        /// <summary>
        /// to indicate success, don't pass any arguments.
        /// </summary>
        public OperationResult(Exception e = null, string errorMessage = null)
        {
            Exception = e;
            ErrorMessage = errorMessage;
        }

        public OperationResult(dynamic apiResponse, string errorMessage)
        {
            if (apiResponse == null)
            {
                ErrorMessage = errorMessage;
            }
            else
            {
                var body = apiResponse["body"];
                ErrorMessage = string.IsNullOrEmpty(errorMessage) ? apiResponse["body"]["error"] ?? "" : errorMessage;
                if (apiResponse["code"] >= 200 && apiResponse["code"] < 300)
                {
                    ErrorMessage = string.Empty;
                }
                else
                {
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        string message = apiResponse["body"]["message"] ?? "";
                        int code = apiResponse["code"];
                        if (string.IsNullOrEmpty(message))
                        {
                            ErrorMessage = apiResponse["body"]["message"];
                        }
                        else if (code >= 500)
                        {
                            ErrorMessage = $"{code}: Maropost experienced a server error and could not complete your request.";
                        }
                        else if (code >= 400)
                        {
                            ErrorMessage = $"{code}: Either your accountId, authToken, or one (or more) of your function arguments are invalid.";
                        }
                        else if (code >= 300)
                        {
                            ErrorMessage = $"{code}: This Maropost API function is currently unavailable.";
                        }
                        else
                        {
                            ErrorMessage = $"{code}: Unexpected final response from Maropost.";
                        }
                    }
                }
            }
        }
    }

    public class OperationResult<T> : OperationResult, IOperationResult<T>
    {
        public T ResultData { get; set; }

        public OperationResult(T resultData, Exception e = null, string errorMessage = null)
            : base(e, errorMessage)
        {
            ResultData = resultData;
        }

        public OperationResult(T apiResponse, string errorMessage)
            : base(apiResponse, errorMessage)
        {
            ResultData = apiResponse;
        }
    }
}
