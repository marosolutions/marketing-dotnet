using System.Threading.Tasks;
using Xunit;

namespace Maropost.Api.UnitTesting
{
    public class JourneysTests : _BaseTests
    {
        [Fact]
        public async Task Get()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            //Act
            var result = await api.Get(1);
            //Assert
            int accountId = result.ResultData[0]["account_id"];
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
            Assert.Equal(AccountId, accountId);
        }

        [Fact]
        public async Task GetCampaigns()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            //Act
            foreach (var resultData in getResult.ResultData)
            {
                int journeyId = resultData["id"];
                var result = await api.GetCampaigns(journeyId, 1);
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
        public async Task GetContacts()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            //Act
            foreach (var resultData in getResult.ResultData)
            {
                int journeyId = resultData["id"];
                var result = await api.GetContacts(journeyId, 1);
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
        public async Task StopAll()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = getResult.ResultData[0]["id"];
            var contactResult = await api.GetContacts(journeyId, 1);
            int contactId = 0;
            string email = "";
            string uid = "";
            foreach (var contact in contactResult.ResultData)
            {
                contactId = contact["contact_id"];
                email = contact["email"];
                uid = contact["uid"];
                if (contactId > 0 && !string.IsNullOrEmpty(email))
                {
                    break;
                }
            }
            //Act
            var result = await api.StopAll(contactId, email, uid, 1);
            //Assert
            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            Assert.Null(result.Exception);
        }

        [Fact]
        public async Task PauseJourneyForContact()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = 0, contactId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = await api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    contactId = contact["contact_id"];
                    //Act
                    var pauseResult = await api.PauseJourneyForContact(journeyId, contactId);
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
        public async Task PauseJourneyForUid()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = await api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    string uid = resultData["uid"];
                    //Act
                    var pauseResult = await api.PauseJourneyForUid(journeyId, uid);
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
        public async Task ResetJourneyForContact()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = 0, contactId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = await api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    contactId = contact["contact_id"];
                    //Act
                    var pauseResult = await api.ResetJourneyForContact(journeyId, contactId);
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
        public async Task ResetJourneyForUid()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = await api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    string uid = resultData["uid"];
                    //Act
                    var pauseResult = await api.ResetJourneyForUid(journeyId, uid);
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
        public async Task StartJourneyForContact()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = 0, contactId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = await api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    contactId = contact["contact_id"];
                    //Act
                    var pauseResult = await api.StartJourneyForContact(journeyId, contactId);
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
        public async Task StartJourneyForUid()
        {
            //Arrange
            var api = new Journeys(AccountId, AuthToken, HttpClient);
            var getResult = await api.Get(1);
            int journeyId = 0;
            bool isTested = false;
            foreach (var resultData in getResult.ResultData)
            {
                journeyId = resultData["id"];
                var contactResult = await api.GetContacts(journeyId, 1);
                foreach (var contact in contactResult.ResultData)
                {
                    string uid = resultData["uid"];
                    //Act
                    var pauseResult = await api.StartJourneyForUid(journeyId, uid);
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
    }
}