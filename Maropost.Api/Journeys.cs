using Maropost.Api.Dto;
using Maropost.Api.Helpers;
using System.Net.Http;

namespace Maropost.Api
{
    public class Journeys : _BaseApi
    {
        public Journeys(int accountId, string authToken, HttpClient httpClient)
            : base(accountId, authToken, "journeys", httpClient)
        { }
        /// <summary>
        /// Get the list of journeys
        /// </summary>
        /// <param name="page">page >= 1</param>
        /// <returns></returns>
        public IOperationResult<dynamic> Get(int page)
        {
            var result = Get(null, new KeyValueList { { "page", $"{page}" } });
            return result;
        }
        /// <summary>
        /// Gets the list of all campaigns for the specified journey
        /// </summary>
        /// <param name="journeyId">journeyid integer value</param>
        /// <param name="page">page >= 1</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetCampaigns(int journeyId, int page)
        {
            var result = Get($"{journeyId}/journey_campaigns", new KeyValueList { { "page", $"{page}" } });
            return result;
        }
        /// <summary>
        /// Gets the list of all contacts for the specified journey
        /// </summary>
        /// <param name="journeyId">journeyid integer value</param>
        /// <param name="page">page >= 1</param>
        /// <returns></returns>
        public IOperationResult<dynamic> GetContacts(int journeyId, int page)
        {
            var result = Get($"{journeyId}/journey_contacts", new KeyValueList { { "page", $"{page}" } });
            return result;
        }
        /// <summary>
        /// Stops all journeys, filtered for the matching parameters
        /// </summary>
        /// <param name="contactId">this filter is ignored if not greater than 0</param>
        /// <param name="recipientEmail">this filter is ignored if null</param>
        /// <param name="uid">this filter is ignored if null</param>
        /// <param name="page">page >= 1</param>
        /// <returns></returns>
        public IOperationResult<dynamic> StopAll(int contactId, string recipientEmail, string uid, int page)
        {
            var keyValuePair = new KeyValueList { { "page", $"{page}" } };
            if (contactId > 0)
            {
                keyValuePair.Add("contact_id", $"{contactId}");
            }
            if (!string.IsNullOrEmpty(recipientEmail))
            {
                keyValuePair.Add("email", $"{recipientEmail}");
            }
            if (!string.IsNullOrEmpty(uid))
            {
                keyValuePair.Add("uid", $"{uid}");
            }
            var result = base.Put("stop_all_journeys", keyValuePair);
            return result;
        }
        /// <summary>
        /// Pause the specified journey for the contact having the specified UID
        /// </summary>
        /// <param name="journeyId">journey id of contact to pause for</param>
        /// <param name="contactId">contact id of contact to pause for</param>
        /// <returns></returns>
        public IOperationResult<dynamic> PauseJourneyForContact(int journeyId, int contactId)
        {
            var result = base.Put($"{journeyId}/stop/{contactId}", null);
            return result;
        }
        /// <summary>
        /// Pause the specified journey for the contact having the specified UID
        /// </summary>
        /// <param name="journeyId">journey id of contact to pause for</param>
        /// <param name="uid">uid of contact to pause for</param>
        /// <returns></returns>
        public IOperationResult<dynamic> PauseJourneyForUid(int journeyId, string uid)
        {
            var result = base.Put($"{journeyId}/stop/uid", new KeyValueList { { "uid", $"{uid}" } });
            return result;
        }
        /// <summary>
        /// Reset the specified journey for the specified active/pause contact.
        /// Resettig a contact to the beginning of the journeys will result in sending of the same journey campaigns as originally sent.
        /// </summary>
        /// <param name="journeyId">journey id of contact to reset for</param>
        /// <param name="contactId">contact id of contact to reset for</param>
        /// <returns></returns>
        public IOperationResult<dynamic> ResetJourneyForContact(int journeyId, int contactId)
        {
            var result = base.Put($"{journeyId}/reset/{contactId}", null);
            return result;
        }
        /// <summary>
        /// Reset the specified journey for the active/paused contact having the specified UID.
        /// Resetting a contact to the beginning of the journeys will result in sending of the same journey campaigns as originally sent.
        /// </summary>
        /// <param name="journeyId">journey id of contact to reset for</param>
        /// <param name="uid">uid of contact to reset for</param>
        /// <returns></returns>
        public IOperationResult<dynamic> ResetJourneyForUid(int journeyId, string uid)
        {
            var result = base.Put($"{journeyId}/reset/uid", new KeyValueList { { "uid", $"{uid}" } });
            return result;
        }
        /// <summary>
        /// Restarts a journey for a paused contact. Adds a new contact in journey.
        /// Retriggers the journey for a contact who has finished its journey once.
        /// (TO retrigger, MAKE SURE that "Retrigger Journey option is enabled.)
        /// </summary>
        /// <param name="journeyId">journey id of contact to restart a journey for</param>
        /// <param name="contactId">contact id of contact to restart a journey for</param>
        /// <returns></returns>
        public IOperationResult<dynamic> StartJourneyForContact(int journeyId, int contactId)
        {
            var result = base.Put($"{journeyId}/start/{contactId}", null);
            return result;
        }
        /// <summary>
        /// Restarts a journey for a paused contact having the specified UID. Adds a new contact in journey.
        /// Retriggers the journey for a contact who has finished its journey once.
        /// (To retrigger, MAKE SURE that "Retrigger Journey" option is enabled.)
        /// </summary>
        /// <param name="journeyId">journey id of contact to restart a journey for</param>
        /// <param name="uid">uid of contact to restart a journey for</param>
        /// <returns></returns>
        public IOperationResult<dynamic> StartJourneyForUid(int journeyId, string uid)
        {
            var result = base.Put($"{journeyId}/start/uid", new KeyValueList { { "uid", $"{uid}" } });
            return result;
        }
    }
}