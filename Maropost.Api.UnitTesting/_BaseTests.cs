using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public abstract class _BaseTests
    {
        protected int AccountId { get; }
        protected string AuthToken { get; }

        public _BaseTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            AccountId = int.Parse(config["AppSettings:AccountId"]);
            AuthToken = config["AppSettings:AuthToken"];
        }
    }
}
