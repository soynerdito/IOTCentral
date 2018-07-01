using Newtonsoft.Json;
using System;

namespace IotCentral.Services
{
    /// <summary>
    /// Message Received from the api
    /// </summary>
    [JsonObject("message")]
    public class MessageDto
    {
        /// <summary>
        /// Information on what to do with this message
        /// JWT Token with type of device and indication 
        /// of workflow to handle it
        /// </summary>
        [JsonProperty("action_token")]
        public string ActionToken { get; set; }
        /// <summary>
        /// Free string for payload to be deliverd.
        /// Receiving end should be able to handle this payload.
        /// Message handlers should be able to handle this message
        /// </summary>
        [JsonProperty("payload")]
        public string RawPayload { get; set; }
        /// <summary>
        /// If message has not been deleted by then delete it. Forger about it
        /// </summary>
        [JsonProperty("expiration_gmt_0")]
        public DateTime? ExpirationGmt0 { get; set; }
    }

    /// <summary>
    /// Message Translated from what was received
    /// </summary>
    public class MessagePayload
    {
        /// <summary>
        /// Inforation should come from access token
        /// </summary>
        public int OwnnerId { get; set; }
        /// <summary>
        /// The id of the account that sends the message
        /// </summary>
        public Guid OwnerAccount { get; set; }
        /// <summary>
        /// When the message arrived to this application.
        /// Time not necessary the same as when the message 
        /// was created in the client side.
        /// </summary>
        public DateTime RecevTimestamp { get; set; }
        /// <summary>
        /// Nothing changed, message as it was received.
        /// Should be kept pure to ensure destin has correct data.
        /// </summary>
        public MessageDto RawMessage { get; set; }

    }
}