# Summary

This provides programmatic access to several services within the Maropost API. The functions contained perform actions against your Maropost account, and they return a result object indicating success/failure, any Exceptions thrown, and the resulting data.

# Installation

[NuGet](https://www.nuget.org/) is the standard .NET packaging system. You can find this package at https://www.nuget.org/packages/Maropost.Api. In Visual Studio's NuGet Package Manager, you can search
for "Maropost.Api", or in the Package Manager Console, you can simply `Install-Package Maropost.Api`.

# Usage
To use a service, first instantiate it, providing your Maropost AccountId
and Auth Token. For example, to get your list of reports using the Reports
service, execute:

    var reports = new Maropost.Api.Reports(myAccountId, myAuthToken, myHttpClient);
    var result = reports.Get();
    if (result.Success) {
        myReports = result.ResultData;
    }

The result object contains three fields:

- `Success` (bool)
- `ErrorMessage` (string)
- `Exception` (System.Exception)

If `Success` is `false`, then `ErrorMessage` will contain information, and
`Exception` *might* contain an exception, depending upon the reason for
failure. If `Exception` is not `null`, then `Success` will always be `false`.

The object might also contain one property, `ResultData` (dynamic), which contains whatever
data the operation itself provides. Some operations, such as `Delete()`
operations, might not provide any data.

# Specific APIs
The specific APIs contained are:

- [Campaigns](#campaigns)
- [AB Test Campaigns](#ab-test-campaigns)
- [Transactional Campaigns](#transactional-campaigns)
- [Contacts](#contacts)
- [Journeys](#journeys)
- [Product and Revenue](#product-and-revenue)
- [Relational Table Rows](#relational-table-rows)
- [Reports](#reports)

## Campaigns
### Instantiation:

    new Maropost.Api.Campaigns(int accountId, string authToken, HttpClient httpClient)

### Available methods:

 - `public async Task<IOperationResult<dynamic>> Get(int page)`
   - returns the list of campaigns for the account
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> GetCampaign(int id)`
   - returns the given campaign
   - `id: campaign id`
 - `public async Task<IOperationResult<dynamic>> GetBounceReports(int id, int page)`
   - returns the list of bounce reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> GetClickReports(int id, int page, bool? unique = null)`
   - returns the list of click reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
   - `unique`: `true` = get for unique contacts. Otherwise, `false`. 
 - `public async Task<IOperationResult<dynamic>> GetComplaintReports(int id, int page)`
   - returns the list of complaint reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> GetDeliveredReports(int id, int page)`
   - returns the list of delivered reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> GetHardBounceReports(int id, int page)`
   - returns the list of hard bounces for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> GetLinkReports(int id, int page, bool? unique = null)`
   - returns the list of link reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
   - `unique`: `true` = get for unique contacts. Otherwise, `false`. 
 - `public async Task<IOperationResult<dynamic>> GetOpenReports(int id, int page, bool? unique = null)`
   - returns the list of open reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
   - `unique`: `true` = get for unique contacts. Otherwise, `false`. 
 - `public async Task<IOperationResult<dynamic>> GetSoftBounceReports(int id, int page)`
   - returns the list of soft bounce reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> GetUnsubscribeReports(int id, int page)`
   - returns the list of unsubscribe reports for the given campaign ID
   - `id: campaign id`
   - `page`: page # (>= 1). Up to 200 records returned per page.
   
## AB Test Campaigns
### Instantiation:

    new Maropost.Api.AbTestCampaigns(int accountId, string authToken, HttpClient httpClient)

### Available Methods:
 - `public async Task<IOperationResult<dynamic>> CreateAbTest(string name, string fromEmail, string replyTo, string address, string language, string campaignGroupAttributes,`
                                                  `string commit, DateTime sendAt, int? brandId = null, object[] suppressedListIds = null, object[] suppressedSegmentIds = null,`
                                                  `object[] suppressedJourneyIds = null, int? emailPreviewLink = null, string decidedBy = null, object[] lists = null,`
                                                  `object[] cTags = null, object[] segments = null)`
   * Creates an Ab Test campaign
   - `name`: name of the new campaign
   - `fromEmail`: default sender email address for campaign emails
   - `replyTo`: default reply-to email address for campaign emails
   - `address`: default physical address included on campaign emails
   - `language`: ISO 639-1 language code (e.g, `"en"`). 2 characters.
   - `campaignGroupsAttributes`: array of attributes. Each attribute is
								 itself an object with the following properties (all strings):
   - `commit`: Allowed values for commit: 'Save as Draft' or 'Send Test' or 'Schedule'
   - `sendAt`: send_at should be in "yyyy-mm-dd %H:%M:%S" where %H - Hour of the day, 24-hour clock (00..23), %M - Minute of the hour (00..59), %S - Second of the minute (00..60)
   - `brandId`:
   - `supressedListIds`:
   - `supressedSegmentIds`:
   - `supressedJourneyIds`:
   - `emailPreviewLink`:
   - `decidedBy`: Allowed values for decided_by: ('TopChoice' for Top Choices) or ('Opens' for Highest Open Rate) or ('Clicks' for Highest Click Rate) or ('Manual' for Manual Selection) or ('click_to_open' for Highest Click-to-Open Rate) or ('conversions' for Highest Conversion Rate)
   - `lists`:
   - `cTags`:
   - `segments`:
   
## Transactional Campaigns

### Instantiation:

    new Maropost.Api.TransactionalCampaigns(int accountId, string authToken, HttpClient httpClient)

### Available methods:
 - `public async Task<IOperationResult<dynamic>> Get(int page)`
     * returns the list of Transaction Campaigns
   - `page`: page # (>= 1). Up to 200 records returned per page.
 - `public async Task<IOperationResult<dynamic>> Create(string name, string subject, string preheader, string fromName, string fromEmail, string replyTo,`
                                           `int contentId, bool emailPreviewLink, string address, string language, object[] ctags)`
     * Creates a Transactional Campaign
     - `name` campaign name
     - `subject` campaign subject
     - `preheader` campaign preheader
     - `fromName` sender name in the email
     - `fromEmail` sender email address
     - `replyTo` reply-to email address
     - `contentId`
     - `emailPreviewLink`
     - `address` physical address
     - `language` ISO 639-1 language code
     - `ctags` array of campaign tags

 - `public async Task<IOperationResult<dynamic>> SendEmail(int campaignId, int? contentId = null, string contentName = null, string contentHtmlPart = null, string contentTextPart = null,`
                                              `int? sendAtHour = null, int? sendAtMinute = null, bool? ignoreDnm = null, int? contactId = null, string recipientEmail = null,`
                                              `string recipientFirstName = null, string recipientLastName = null, IDictionary<object, object> recipientCustomFields = null,`
                                              `string bccEmail = null, string fromName = null, string fromEmail = null, string subject = null, string replyTo = null,`
                                              `string senderAddress = null, IDictionary<object, object> tags = null, object[] ctags = null)`
     * Sends a transactional campaign email to a recipient. Sender's information will be automatically fetched from the transactional campaign, unless provided in the function arguments.
     - `campaignId`: must be a campaign that already exists when you call `$svc->get()`. If you don't have one, first call `$svc->create()`.
     - `contentId`: If provided, the transactional campaign's content will be replaced by this content.
     - `contentName`: If $contentId is null, the transactional campaign's content name will be replaced by this name.
     - `contentHtmlPart`: If $contentId is null, the transactional campaign's content HTML part will be replaced by this HTML part.
     - `contentTextPart`: If $contentId is null, the transactional campaign's content Text part will be replaced by this Text part.
     - `sendAtHour`: Must be 1-12. Otherwise the email will go out immediately. If the hour is less than the current hour, the email will go out the following day.
     - `sendAtMinute`: Must be 0-60. Otherwise will be treated as 0. If the hour and minute combine to less than the current time, the email will go out the following day.
     - `ignoreDnm`: If true, ignores the Do Not Mail list for the recipient contact.
     - `contactId`: contact ID of the recipient.
     - `recipientEmail`: email address. Ignored unless `$contactId` is null. Otherwise, it must be a well-formed email address according to `FILTER_VALIDATE_EMAIL`.
     - `recipientFirstName`: recipient's first name. Ignored unless `$contactId` is null.
     - `recipientLastName`: recipient's last name. Ignored unless `$contactId` is null.
     - `recipientCustomFields`: custom fields for the recipient. Ignored unless `$contactId` is null. Is an associative array where the item key is the name of the custom field, and the item value is the field value. All keys must be strings. All values must be non-null scalars.
     - `bccEmail`: BCC recipient. May only pass a single email address, empty string, or null. If provided, it must be a well-formed email address according to `FILTER_VALIDATE_EMAIL`.
     - `fromName`: sender's name. If `$fromEmail` is set, it overrides the transactional campaign default sender name. Ignored otherwise.
     - `fromEmail`: sender's email address. Overrides the transactional campaign default sender email.
     - `subject`: subject line of email. Overrides the transactional campaign default subject.
     - `replyTo`: reply-to address. Overrides the transactional campaign default reply-to.
     - `senderAddress`: physical address of sender. Overrides the transactional campaign default sender address.
     - `tags`: associative array where the item key is the name of the tag within the content, and the item value is the tag's replacement upon sending. All keys must be strings. All values must be non-null scalars.
     - `ctags`: campaign tags. Must be a simple array of scalar values.
     
## Contacts

### Instantiation:
	
	new Maropost.Api.Contacts(int accountId, string authToken, HttpClient httpClient)

### Available methods:

 - `public async Task<IOperationResult<dynamic>> GetForEmail(string email)`
   * Gets the contact according to email address 
   - `email`: email address of the contact

 - `public async Task<IOperationResult<dynamic>> GetOpens(int contactId, int page)`
   * Gets the list of opens for the specified contact
   - `contactId`: contact id of contact to for which the contact is being retrieved
   - `page`: page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> GetClicks(int contactId, int page)`
   * Gets the list of clicks for the specified contact
   - `contactId`: contact id of contact to for which the contact is being retrieved
   - `page`: page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> GetForList(int listId, int page)`
   * Gets the list of contacts for the specified list
   - `listId`: ID of the list to which the contact being retrieved
   - `page`: page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> GetContactForList(int listId, int contactId)`
   - Gets the specified contact from the specified list
   - `listId`: ID of the list to which the contact is being retrieved
   - `contactId`: contact id of contact to for which the contact is being retrieved

 - `public async Task<IOperationResult<dynamic>> CreateOrUpdateForList(int listId, string email, string firstName = null, string lastName = null, string phone = null,`
														  `string fax = null, string uid = null, object customField = null, object addTags = null,`
														  `object removeTags = null, bool removeFromDNM = true, bool subscribe = true)`
     * Creates a contact within a list. Updates if previous contact is matched by email
     - `listId`: ID of the list to which the contact being updated belongs
     - `contactId`: ID of the contact being updated
     - `email`: Email address for the contact to be updated
     - `firstName`: first name of Contact
     - `lastName`: last name of Contact
     - `phone`: phone number of Contact
     - `fax`: fax number of Contact
     - `uid`: UID for the Contact
     - `customField`: custom fields passed as associative array. Keys represent the field names while values represent the values
     - `addTags`: tags to add to the contact. Simple array of tag names
     - `removeTags`: tags to remove from the contact. Simple array of tag names
     - `removeFromDNM`: set this true to subscribe contact to the list, and remove it from DNM)
     - `subscribe`: set this true to subscribe contact to the list; false otherwise
  
 - `public async Task<IOperationResult<dynamic>> UpdateForListAndContact(int listId, string contactId, string email, string firstName = null, string lastName = null, string phone = null, string fax = null,`
															`string uid = null, object customField = null, object addTags = null, object removeTags = null, bool removeFromDNM = true, bool subscribe = true)`
     * Creates a contact within a list. Updates if previous contact is matched by email.
     - `listId`: ID of the list for which the contact is being created
     - `email`: email address for the contact to be created|updated
     - `firstName`: first name of Contact
     - `lastName`: last Name of Contact
     - `phone`: phone number of Contact
     - `fax`: fax number of Contact
     - `uid`: UID for the contact
     - `customField`: custom fields passed as associative array. Keys represent the field names while values represent the values.
     - `addTags`: tags to add to the contact. Simple array of tag names (strings).
     - `removeTags`: tags to remove from the contact. Simple array of tag names (strings).
     - `removeFromDNM`: Set this true to subscribe contact to the list, and remove it from DNM.
     - `subscribe`: true to subscribe the contact to the list; false otherwise.

 - `public async Task<IOperationResult<dynamic>> CreateOrUpdateContact(string email, string firstName = null, string lastName = null, string phone = null, string fax = null, string uid = null,`
														  `object customField = null, object addTags = null, object removeTags = null, bool removeFromDNM = true, bool subscribe = true)`
     * Creates a contact without a list. Updates if already existing email is passed.
     - `contactId`: ID of the contact
     - `email`: Email address for the contact to be created|updated
     - `firstName`: first name of Contact
     - `lastName`: last Name of Contact
     - `phone`: phone number of Contact
     - `fax`: fax number of Contact
     - `uid`: UID for the contact
     - `customField`: custom fields passed as associative array. Keys represent the field names while values represent the values
     - `addTags`: tags to add to the contact. Simple array of tag names (strings).
     - `removeTags`: tags to remove from the contact. Simple array of tag names (strings).
     - `removeFromDNM`: set this true to subscribe contact to the list, and remove it from DNM
	 - `subscribe`: true to subscribe the contact to the list; false otherwise.

 - `public async Task<IOperationResult<dynamic>> CreateOrUpdateForListAndWorkflows(string email, string firstName = null, string lastName = null, string phone = null, string fax = null, string uid = null,`
																	  `object customField = null, object addTags = null, object removeTags = null, bool removeFromDNM = false, int[] subscribeListIds = null,`
																	  `int[] unsubscribeListIds = null, int[] unsubscribeWorkflowIds = null, string unsubscribeCampaign = null)`
     * Creates or updates Contact
        - Multiple lists can be subscribed, unsubscribed. 
        - Multiple workflows can be unsubscribed.
     - `email`: email address for the contact to be created|updated
     - `firstName`: first name of Contact
     - `lastName`: last name of Contact
     - `phone`: phone number of Contact
     - `fax`: fax number of Contact
     - `uid`: UID for the Contact
     - `customField`: custom fields passed as associative array. Keys represent the field names while values represent the values
     - `addTags`: tags to add to the contact. Simple array of tag names (strings)
     - `removeTags`: tags to remove from the contact. Simple array of tag names (strings)
     - `removeFromDNM`: set this true to subscribe contact to the list, and remove it from DNM
     - `subscribeListIds`: simple array of IDs of lists to subscribe the contact to
     - `unsubscribeListIds`: simple array of IDs of Lists to unsubscribe the contact from
     - `unsubscribeWorkflowIds`: simple array of list of IDs of workflows to unsubscribe the contact from
     - `unsubscribeCampaign`: campaignID to unsubscribe the contact from

 - `public async Task<IOperationResult<dynamic>> DeleteFromAllLists(string email)`
     * Deletes specified contact from all lists
     - `email`: email address of the contact

 - `public async Task<IOperationResult<dynamic>> DeleteFromLists(int contactId, int[] listIds = null)`
     * Deletes the specified contact from the specified lists
     - `contactId`: id of the contact
     - `listIds`: simple array of ids of the lists

 - `public async Task<IOperationResult<dynamic>> DeleteContactForUid(string uid)`
     * Deletes contact having the specified UID
	 - `uid`: UID of the Contact for which the contact is being deleted

 - `public async Task<IOperationResult<dynamic>> DeleteListContact(int listId, int contactId)`
     * Deletes specified contact from the specified list
	 - `listId`: ID of the list for which the contact is being deleted
	 - `contactId`: contact id of the list for which the contact is being deleted

 - `public async Task<IOperationResult<dynamic>> UnsubscribeAll(string contactFieldValue, string contactFieldName = "email")`
     * Unsubscribes contact having the specified field name/value.
     - `contactFieldValue`: the value of the field for the contact(s) being unsubscribed
     - `contactFieldName`: the name of the field being checked for the value. At present, the accepted field names are: 'email' or 'uid'

## Journeys

### Instantiation:

    new Maropost.Api.Journeys(int accountId, string authToken, HttpClient httpClient)

### Available methods:

 - `public async Task<IOperationResult<dynamic>> Get(int page)`
     * Gets the list of journeys
     - `page`: page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> GetCampaigns(int journeyId, int page)`
     * Gets the list of all campaigns for the specified journey
	 - `journeyId`: get campaigns filtered with journeyid
     - `page`: page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> GetContacts(int journeyId, int page)`
     * Gets the list of all contacts for the specified journey
	 - `journeyId`: get contacts filtered with journeyid
     - `page` : page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> StopAll(int contactId, string recipientEmail, string uid, int page)`
     * Stops all journeys, filtered for the matching parameters
     - `contactId`: this filter ignored unless greater than 0
     - `recipientEmail`: this filter ignored if null
     - `uid`: this filter ignored if null
	 - `page`: page # (>= 1). Up to 200 record returned per page.

 - `public async Task<IOperationResult<dynamic>> PauseJourneyForContact(int journeyId, int contactId)`
     * Pause the specified journey for the specified contact
	 - `journeyId`: pause journey for speficied journey id
	 - `contactId`: pause journey for speficied contact id

 - `public async Task<IOperationResult<dynamic>> PauseJourneyForUid(int journeyId, string uid)`
     * Pause the specified journey for the contact having the specified UID
	 - `journeyId`: pause journey for specified journey id
	 - `uid`: pause journey for speficified uid

 - `public async Task<IOperationResult<dynamic>> ResetJourneyForContact(int journeyId, int contactId)`
     * Reset the specified journey for the specified active/paused contact. Resetting a contact to the beginning of the journeys will result in sending of the same journey campaigns as originally sent.
	 - `journeyId`: reset journey for contact with specified journey id
	 - `contactId`: reset journey for specified contact id

 - `public function resetJourneyForUid(int journeyId, string uid)`
     * Reset the specified journey for the active/paused contact having the specified UID. Resetting a contact to the beginning of the journeys will result in sending of the same journey campaigns as originally sent.
	 - `journeyId`: reset journey for specified journey id
	 - `uid`: reset journey for specified uid

 - `public function startJourneyForContact(int journeyId, int contactId)`
     * Restarts a journey for a paused contact. Adds a new contact in journey. Retriggers the journey for a contact who has finished its journey once. (To retrigger, *make sure* that "Retrigger Journey" option is enabled.)
	 - `journeyId`: start journey for contact with specified journey id
	 - `contactId`: start journey for specified journey id

 - `public async Task<IOperationResult<dynamic>> ResetJourneyForUid(int journeyId, string uid)`
     * Restarts a journey for a paused contact having the specified UID. Adds a new contact in journey. Retriggers the journey for a contact who has finished its journey once. (To retrigger, *make sure* that "Retrigger Journey" option is enabled.)
	 - `journeyId`: reset journey for specified journey id
	 - `uid`: reste journey for specified uid

 - `public async Task<IOperationResult<dynamic>> StartJourneyForContact(int journeyId, int contactId)`
	* Starts a journey for contact having specified journeyId
	- `journeyId`: start journey for specified journey id
	- `contactId`: contact id of contact to start journey

 - `public async Task<IOperationResult<dynamic>> StartJourneyForUid(int journeyId, string uid)`
	* Starts a journey for contact having specified uid and journeyId
	- 'journeyId': journey id to start journey
	- 'uid': uid of contact to start journey

## Product and Revenue

### Instantiation:

    new Maropost.Api.ProductsAndRevenues(int accountId, string authToken, HttpClient httpClient)

### Available methods:

 - `public async Task<IOperationResult<dynamic>> GetOrder(int id)`
     * Gets the specified order
 - `public async Task<IOperationResult<dynamic>> GetOrderForOriginalOrderId(string originalOrderId)`
     * Gets the specified order

 - `public async Task<IOperationResult<dynamic>> CreateOrder(bool requireUnique,`
                                                `string contactEmail,`
                                                `string contactFirstName,`
                                                `string contactLastName,`
                                                `string orderDateTime,`
                                                `string orderStatus,`
                                                `string originalOrderId,`
                                                `OrderItemInput[] orderItems,`
                                                `object customFields = null,`
                                                `object[] addTags = null,`
                                                `object[] removeTags = null,`
                                                `string uid = null,`
                                                `string listIds = null,`
                                                `string grandTotal = null,`
                                                `int? campaignId = null,`
                                                `string couponCode = null)`
     * Creates an order
     - `requireUnique`: true to validate that the order has a unique original_order_id for the given contact.
     - `contactEmail`: email address of contact
     - `contactFirstName`: first name of contact
     - `contactLastName`: last name of contact
     - `orderDateTime`: uses the format: "YYYY-MM-DDTHH:MM:SS-05:00"
     - `orderStatus`: status of order
     - `originalOrderId`: sets the original_order_id field
     - `orderItems` an array of \Maropost\Api\InputTypes\OrderItemInput objects.
     - `customFields` associative array where the key (string) represents the field name and the value is the field value
     - `addTags` simple array of tags to add (scalar values)
     - `removeTags` simple array of tags to remove (scalar values)
     - `uid`: unique id
     - `listIds` CSV list of IDs (e.g, "12,13")
     - `grandTotal`: grand total
     - `campaignId`: campaign id
     - `couponCode`: coupon code

 - `public async Task<IOperationResult<dynamic>> UpdateOrderForOriginalOrderId(string originalOrderId,`
                                                                  `string orderDateTime,`
                                                                  `string orderStatus,`
                                                                  `object[] orderItems,`
                                                                  `int? campaignId = null,`
                                                                  `string couponCode = null)`
     * Updates an existing eCommerce order using unique original_order_id if the details are changed due to partial return or some other update.
     - `originalOrderId`: matches the original_order_id field of the order
     - `orderDateTime`: uses the format: YYYY-MM-DDTHH:MM:SS-05:00
     - `orderStatus`: order status
     - `orderItems`: campaign id
     - `couponCode`: coupon code

 - `public async Task<IOperationResult<dynamic>> UpdateOrderForOrderId(int orderId,`
                                                          `string orderDateTime,`
                                                          `string orderStatus,`
                                                          `object[] orderItems,`
                                                          `int? campaignId = null,`
                                                          `string couponCode = null)`
     * Updates an existing eCommerce order using unique order_id if the details are changed due to partial return or some other update.
     - `orderId`: matches the Maropost order_id field of the order
     - `orderDateTime`: uses the format: YYYY-MM-DDTHH:MM:SS-05:00
     - `orderStatus`: order status
     - `orderItems`: restates the orderItems as as array of OrderItemInput objects.
     - `campaignId`: campaign id
     - `couponCode`: coupon code
    
 - `public async Task<IOperationResult<dynamic>> DeleteForOriginalOrderId(string originalOrderId)`
     * Deletes the complete eCommerce order if the order is cancelled or returned
     - `originalOrderId` matches the original_order_id field of the order

 - `public async Task<IOperationResult<dynamic>> DeleteForOrderId(int id)`
     * Deletes the complete eCommerce order if the order is cancelled or returned using Maropost order id
     - `id`: Maropost order_id

 - `public async Task<IOperationResult<dynamic>> DeleteProductsForOriginalOrderId(string originalOrderId,`
                                                                     `object[] productIds)`
     * Deletes the specified product(s) from a complete eCommerce order if the product(s) is cancelled or returned
     - `originalOrderId`: matches the original_order_id field of the order
     - `productIds`: the product(s) to delete from the order

 - `public async Task<IOperationResult<dynamic>> DeleteProductsForOrderId(int id,`
                                                             `object[] productIds)`
     * Deletes the specified product(s) from a complete eCommerce order if the product(s) is cancelled or returned
     - `id`: Maropost order_id
     - `productIds`: the product(s) to delete from the order

## Relational Table Rows

### Instantiation:
Unlike the other services, the constructor for this requires a fourth
parameter: `tableName`. So for example:

    new Maropost.Api.RelationalTableRows(myAccountId, myAuthToken, myHttpClient, "someTableName")

`tableName` sets which relational table the service's operations should act against.
To switch tables, you do not need to re-instantiate the service. Simply update the `TableName` property of the instance:

    var rows = new Maropost.Api.RelationalTableRows(myId, myToken, myHttpClient, "table1");
	rows.TableName = "table2";

### Available functions:

 - `public async Task<IOperationResult<dynamic>> Get()`
     * Gets the records of the Relational Table

 - `public async Task<IOperationResult<dynamic>> Show(string idFieldName, string idFieldVlaue)`
     * Gets the specified record from the Relational Table
     * `id`: ID of the existing record you wish to read

 - `public async Task<IOperationResult<dynamic>> Create(IDictionary<string, object> keyValues)`
     * Adds a record to the Relational Table
     * `keyValues`: Multiple `Dictionary<stringm object>` objects, for the
     record to be created, each item consisting of two fields:
       - `key`: string representing the name of the field
       - `value`: scalar value representing the new value for the field.
         - Any DateTime strings must be in one of three formats: "MM/DD/YYYY", 
         "YYYY-MM-DD", or "YYYY-MM-DDThh:mm:ssTZD".
       - NOTE: One of the KeyValues must represent the unique identifier.

 - `public async Task<IOperationResult<dynamic>> Update(IDictionary<string, object> keyValues)`
     * Updates a record in the Relational Table.
     * `keyValues`: Multiple `Dictionary<stringm object>` objects, for the
     record to be created, each item consisting of two fields:
       - `key`: string representing the name of the field
       - `value`: scalar value representing the new value for the field.
         - Any DateTime strings must be in one of three formats: "MM/DD/YYYY", 
         "YYYY-MM-DD", or "YYYY-MM-DDThh:mm:ssTZD".
       - NOTE: One of the KeyValues must represent the unique identifier.

 - `public async Task<IOperationResult<dynamic>> Upsert(IDictionary<string, object> keyValues)`
     * Creates or updates a record in the Relational Table.
     * `keyValues`: Multiple `Dictionary<stringm object>` objects, for the
     record to be created, each item consisting of two fields:
       - `key`: string representing the name of the field
       - `value`: scalar value representing the new value for the field.
         - Any DateTime strings must be in one of three formats: "MM/DD/YYYY", 
         "YYYY-MM-DD", or "YYYY-MM-DDThh:mm:ssTZD".
       - NOTE: One of the KeyValues must represent the unique identifier.

 - `public async Task<IOperationResult<dynamic>> Delete(string idField, object idFieldValue)`
     * Deletes the given record of the Relational Table
     * `idField` name of the field representing the unique identifier (E.g., "id", "email")
     * `idFieldValue` value of the identifier field, for the record to delete.

## Reports

### Instantiation:

    new Maropost.Api.Reports(int accountId, string authToken, HttpClient httpClient)

### Available methods:
 - `public async Task<IOperationResult<dynamic>> Get(int page)`
   - returns the list of reports
   - `page`: page # (>= 1). Up to 200 records returned per page.

 - `public async Task<IOperationResult<dynamic>> GetReport(int id)`
   - Gets the list of reports
   - `id`: report ID

 - `public async Task<IOperationResult<dynamic>> GetOpens(int page,`
                                             `object[] fields = null,`
                                             `DateTime? from = null,`
                                             `DateTime? to = null,`
                                             `bool? unique = null,`
                                             `string email = null,`
                                             `string uid = null,`
                                             `int? per = null)`
   * returns the list of open reports based on filters and fields provided
   - `page`: page # (>= 1). Up to 200 records returned per page.
   * `fields`: contact field names to retrieve
   * `from`: the beginning of date range filter
   * `to`: the end of the date range filter
   * `unique`: when true, gets only unique opens
   * `email`: filters by provided email in the contact
   * `uid`: filters by uid
   * `per`: determines how many records per request to receive

 - `public async Task<IOperationResult<dynamic>> GetClicks(int page,`
                                              `object[] fields = null,`
                                              `DateTime? from = null,`
                                              `DateTime? to = null,`
                                              `bool? unique = null,`
                                              `string email = null,`
                                              `string uid = null,`
                                              `int? per = null)`
   * returns the list of click reports
   * `page`: page # (>= 1). Up to 200 records returned per page.
   * `fields`: plucks these contact fields if they exist
   * `from`: start of specific date range filter
   * `to`: end of date range filter
   * `unique`: if true, gets unique records
   * `email`: gets Clicks for specific email
   * `uid`: gets Clicks for provided uid
   * `per`: gets the specified number of records

 - `public async Task<IOperationResult<dynamic>> GetBounce(int page,`
                                              `object[] fields = null,`
                                              `DateTime? from = null,`
                                              `DateTime? to = null,`
                                              `bool? unique = null,`
                                              `string email = null,`
                                              `string uid = null,`
                                              `string type = null,`
                                              `int? per = null)`
   * returns the list of bounce reports
   * `page`: page # (>= 1). Up to 200 records returned per page.
   * `fields`: plucks these contact fields if they exist
   * `from`: start of specific date range filter
   * `to`: end of date range filter
   * `unique`: if true, gets unique records
   * `email`: gets Bounces for specific email
   * `uid`: gets Bounces for provided uid
   * `per`: gets the specified number of records

 - ` public async Task<IOperationResult<dynamic>> GetUnsubscribes(int page,`
                                                     `object[] fields = null,`
                                                     `DateTime? from = null,`
                                                     `DateTime? to = null,`
                                                     `bool? unique = null,`
                                                     `string email = null,`
                                                     `string uid = null,`
                                                     `int? per = null)`
   * returns the list of Unsubscribes with provided filter constraints
   * `page`: page # (>= 1). Up to 200 records returned per page.
   * `fields`: plucks these contact fields if they exist
   * `from`: start of specific date range filter
   * `to`: end of date range filter
   * `unique` if true, gets unique records
   * `email` gets Unsubscribes for specific email
   * `uid` gets Unsubscribes for provided uid
   * `per` gets the specified number of records

 - `public async Task<IOperationResult<dynamic>> GetComplaints(int page,`
                                                  `object[] fields = null,`
                                                  `DateTime? from = null,`
                                                  `DateTime? to = null,`
                                                  `bool? unique = null,`
                                                  `string email = null,`
                                                  `string uid = null,`
                                                  `int? per = null)`
   * returns the list of complaints filtered by provided params
   * `page`: page # (>= 1). Up to 200 records returned per page.
   * `fields`: plucks these contact fields if they exist
   * `from`: start of specific date range filter
   * `to`: end of date range filter
   * `unique`: if true, gets unique records
   * `email`: gets Complaints for specific email
   * `uid`: gets Complaints for provided uid
   * `per`: gets the specified number of records

 - ` public async Task<IOperationResult<dynamic>> GetAbReports(string name,`
                                                  `int page,`
                                                  `DateTime? from = null,`
                                                  `DateTime? to = null,`
                                                  `int? per = null)`
   * returns the list of Ab Reports
   * `name`: to get ab_reports with mentioned name
   * `page`: page # (>= 1). Up to 200 records returned per page.
   * `from`: beginning of date range filter
   * `to`: end of date range filter
   * `per`: gets the mentioned number of reports

 - `public async Task<IOperationResult<dynamic>> GetJourney(int page)`
   * returns the list of all Journeys
   * `page`: page # (>= 1). Up to 200 records returned per page.
