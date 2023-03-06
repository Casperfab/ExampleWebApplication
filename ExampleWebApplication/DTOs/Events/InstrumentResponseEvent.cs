using ExampleWebApplication.DTOs.Events.Commons;
using ExampleWebApplication.DTOs.Instruments;

namespace ExampleWebApplication.DTOs.Events
{
    /// <summary>
    /// The response event object of instrument service
    /// </summary>
    public class InstrumentResponseEvent : IntegrationEvent
    {
        /// <summary>
        /// Instrument response
        /// </summary>
        public InstrumentResponseDTO InstrumentResponse { get; set; }
        /// <summary>
        /// Generic error response
        /// </summary>
        public ErrorResponse ErrorResponse { get; set; }
    }
}
