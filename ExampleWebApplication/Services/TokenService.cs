namespace ExampleWebApplication.Services
{
    /// <summary>
    /// Token service used to retrieve authorization tokens for internal requests
    /// </summary>
    public class TokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="configuration"></param>
        public TokenService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        /// <summary>
        /// Get token
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetToken()
        {
            string apiEndpoint = $"{_configuration["Credentials:AuthorizationEndpoint"]}";
            var requestBuilder = new UriBuilder(apiEndpoint);
            requestBuilder.Query = $"response_type=code&client_id={_configuration["Credentials:AppKey"]}&redirect_uri={_configuration["Credentials:RedirectUri"]}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestBuilder.Uri);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            return await _httpClient.SendAsync(request);
        }
    }
}
