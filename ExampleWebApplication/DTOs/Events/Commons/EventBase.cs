namespace ExampleWebApplication.DTOs.Events.Commons
{
    /// <summary>
    /// The basic event base class
    /// </summary>
    public class EventBase
    {
        /// <summary>
        /// Reponse code
        /// </summary>
        public int ResponseCode { get; set; }
        /// <summary>
        /// Response message
        /// </summary>
        public string ResponseMessage { get; set; }
    }
}
