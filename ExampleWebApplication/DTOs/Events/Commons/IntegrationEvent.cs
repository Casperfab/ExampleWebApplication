namespace ExampleWebApplication.DTOs.Events.Commons
{
    /// <summary>
    /// Base integration for communications
    /// </summary>
    public class IntegrationEvent : EventBase
    {
        /// <summary>
        /// The token used for authorization
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Correlation id used to correlate across services
        /// </summary>
        public Guid CorrelationId { get; set; } = Guid.NewGuid();
    }
}
