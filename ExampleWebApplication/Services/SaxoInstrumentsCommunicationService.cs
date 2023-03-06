namespace ExampleWebApplication.Services
{
    /// <summary>
    /// Communication service for instruments
    /// </summary>
    public class SaxoInstrumentsCommunicationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="configuration"></param>
        public SaxoInstrumentsCommunicationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        /// <summary>
        /// Communication method to get instruments
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetInstruments(string token)
        {
            string apiEndpoint = $"{_configuration["Endpoints:Instruments"]}";
            var requestBuilder = new UriBuilder(apiEndpoint);
            var request = new HttpRequestMessage(HttpMethod.Get, requestBuilder.Uri);
            request.Headers.TryAddWithoutValidation("Accept", "application/json");
            request.Headers.TryAddWithoutValidation("Authorization", token);
            //string body = JsonConvert.SerializeObject(Inåut class)
            //request.Content.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            //Invoke service
            return await _httpClient.SendAsync(request);
        }
    }
}
