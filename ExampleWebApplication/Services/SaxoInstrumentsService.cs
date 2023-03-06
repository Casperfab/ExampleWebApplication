using ExampleWebApplication.DTOs;
using ExampleWebApplication.DTOs.Events;
using ExampleWebApplication.DTOs.Instruments;
using ExampleWebApplication.Utils;
using System.Text.Json;

namespace ExampleWebApplication.Services
{
    /// <summary>
    /// Service used to handle instruments logic
    /// </summary>
    public class SaxoInstrumentsService
    {
        private readonly SaxoInstrumentsCommunicationService _saxoInstrumentsCommunicationService;
        private readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="saxoInstrumentsCommunicationService"></param>
        public SaxoInstrumentsService(SaxoInstrumentsCommunicationService saxoInstrumentsCommunicationService)
        {
            _saxoInstrumentsCommunicationService = saxoInstrumentsCommunicationService;
        }
        /// <summary>
        /// Fetching various instruments
        /// </summary>
        /// <param name="instrumentRequestEvent"></param>
        /// <returns></returns>
        public async Task<InstrumentResponseEvent> FetchInstruments(InstrumentRequestEvent instrumentRequestEvent)
        {
            var responseEvent = new InstrumentResponseEvent();
            try
            {
                //Write Validations - if any
                var httpResponse = await _saxoInstrumentsCommunicationService.GetInstruments(instrumentRequestEvent.Token);
                var httpResponseContent = await httpResponse.Content.ReadAsStringAsync();
                //Add Logging
                switch ((int)httpResponse.StatusCode)
                {
                    case 200:
                        responseEvent.ResponseCode = StatusCodes.Status200OK;
                        responseEvent.InstrumentResponse = JsonSerializer.Deserialize<InstrumentResponseDTO>(httpResponseContent, options);
                        break;
                    default:
                        responseEvent.ResponseCode = (int)httpResponse.StatusCode;
                        responseEvent.ErrorResponse = new ErrorResponse
                        {
                            Errors = new List<Error>()
                            {
                                new Error
                                {
                                    Code = GenericErrorCodes.ErrorRequest,
                                    Message = GenericErrorDescriptions.ErrorRequest,
                                    ProgramName = "SaxoInstrumentsService_GetInstruments"
                                }
                            }
                        };
                        break;
                }
            }
            catch(Exception e)
            {
                //Log exception
                responseEvent.ResponseCode = StatusCodes.Status500InternalServerError;
                responseEvent.ErrorResponse = new ErrorResponse
                {
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            Code = GenericErrorCodes.ExceptionRequest,
                            Message = e.Message,
                            ProgramName = "SaxoInstrumentsService_GetInstruments"
                        }
                    }
                };
            }
            return responseEvent;
        }
    }
}
