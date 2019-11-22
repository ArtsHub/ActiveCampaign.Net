namespace ActiveCampaign.Net.Models.Campaign
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the response received as a part of adding the message.
    /// </summary>
    public class MessageGetResponse : Result
    {
        #region Properties

        public Message message { get; set; }
        #endregion
    }
}
