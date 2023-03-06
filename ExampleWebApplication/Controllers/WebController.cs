using ExampleWebApplication.DTOs;
using ExampleWebApplication.DTOs.Events;
using ExampleWebApplication.Services;
using ExampleWebApplication.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebController : ControllerBase
    {
        private readonly ILogger<WebController> _logger;
        private readonly SaxoInstrumentsService _saxoInstrumentsService;
        private readonly TokenService _tokensService;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="saxoInstrumentsService"></param>
        /// <param name="tokenService"></param>
        public WebController(ILogger<WebController> logger, SaxoInstrumentsService saxoInstrumentsService, TokenService tokenService)
        {
            _logger = logger;
            _saxoInstrumentsService = saxoInstrumentsService;
            _tokensService = tokenService;
        }

        [HttpGet(Name = "GetWeb")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var instrumentRequestEvent = new InstrumentRequestEvent();
                instrumentRequestEvent.Token = HttpContext.Request.Headers.Authorization.ToString();
                //var token = await _tokensService.GetToken().Result.Content.ReadAsStringAsync();
                var response = await _saxoInstrumentsService.FetchInstruments(instrumentRequestEvent);
                return StatusCode(response.ResponseCode, response);
            }
            catch(Exception e)
            {
                _logger.LogError("Error in WebController: " + e.Message + e.StackTrace);
                return StatusCode(500, new ErrorResponse
                {
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            Code = GenericErrorCodes.ExceptionRequest,
                            Message = e.Message,
                            ProgramName = e.Source ?? "WebController"
                        }
                    }
                });
            }
        }
    }
}