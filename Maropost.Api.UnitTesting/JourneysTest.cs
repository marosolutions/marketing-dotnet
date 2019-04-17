﻿using Maropost.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class JourneysTest : _BaseTests
    {
        [Fact]
        public void Get()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            //Act
            var result = api.Get(1);
            //Assert
            int accountId = result.ResultData["account_id"];
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.Equal(AccountId, accountId);
        }

        [Fact]
        public void GetCampaigns()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = api.Get(1);
            //Act
            foreach (var resultData in getResult.ResultData)
            {
                int journeyId = resultData["id"];
                var result = api.GetCampaigns(journeyId, 1);
                //Assert
                if (result.Success && result.ResultData.Count > 0)
                {
                    int accountId = result.ResultData[0]["account_id"];
                    Assert.True(result.Success);
                    Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
                    Assert.Null(result.Exception);
                    Assert.Equal(AccountId, accountId);
                    break;
                }
            }
        }

        [Fact]
        public void GetContacts()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = api.Get(1);
            //Act
            foreach (var resultData in getResult.ResultData)
            {
                int journeyId = resultData["id"];
                var result = api.GetContacts(journeyId, 1);
                //Assert
                if (result.Success && result.ResultData.Count > 0)
                {
                    int accountId = result.ResultData[0]["account_id"];
                    int resultJourneyId = result.ResultData[0]["journey_id"];
                    Assert.True(result.Success);
                    Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
                    Assert.Null(result.Exception);
                    Assert.Equal(AccountId, accountId);
                    Assert.Equal(journeyId, resultJourneyId);
                    break;
                }
            }
        }

        [Fact]
        public void StopAll()
        {
            //Arrange
            var contactApi = new Contacts(AccountId, AuthToken, HttpClient);
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = contactApi.GetForList(1, 1);
            //Act
            foreach (var resultData in getResult.ResultData)
            {
                int contactId = resultData["id"];
                string email = resultData["email"];
                string uid = resultData["uid"];
                var stopResult = api.StopAll(contactId, email, uid, 1);
                if (stopResult.Success)
                {
                    //Assert
                    Assert.True(stopResult.Success);
                    Assert.True(string.IsNullOrEmpty(stopResult.ErrorMessage));
                    Assert.Null(stopResult.Exception);
                    break;
                }
            }
        }

        [Fact]
        public void PauseJourneyForContact()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = api.Get(1);
            int journeyId = 0, contactId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    contactId = contact["contact_id"];
                    //Act
                    var pauseResult = api.PauseJourneyForContact(journeyId, contactId);
                    if (pauseResult.Success)
                    {
                        //Assert
                        Assert.True(pauseResult.Success);
                        Assert.True(string.IsNullOrEmpty(pauseResult.ErrorMessage));
                        Assert.Null(pauseResult.Exception);
                        isTested = true;
                    }
                }
                if (isTested)
                {
                    break;
                }
            }
        }

        [Fact]
        public void PauseJourneyForUid()
        {
            var api = new Journeys(AccountId, AuthToken, HttpClient);
        }

        [Fact]
        public void ResetJourneyForContact()
        {
            var api = new Journeys(AccountId, AuthToken, HttpClient);
        }

        [Fact]
        public void ResetJourneyForUid()
        {
            var api = new Journeys(AccountId, AuthToken, HttpClient);
        }

        [Fact]
        public void StartJourneyForContact()
        {
            var api = new Journeys(AccountId, AuthToken, HttpClient);
        }

        [Fact]
        public void StartJourneyForUid()
        {
            var api = new Journeys(AccountId, AuthToken, HttpClient);
        }
    }
}