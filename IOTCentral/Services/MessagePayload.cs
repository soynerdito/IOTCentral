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
        [JsonProperty("payload")]
        public string RawPayload { get; set; }
        [JsonProperty("expiration_gmt0")]
        public DateTime? ExpirationGmt0 { get; set; }
    }

    /// <summary>
    /// Message Translated from what was received
    /// </summary>
    public class MessagePayload
    {
        public int OwnnerId { get; set; }
        public Guid OwnerAccount { get; set; }
        public DateTime RecevTimestamp { get; set; }
        public MessageDto RawMessage { get; set; }

    }
}