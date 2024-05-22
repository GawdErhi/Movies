using Azure;
using Movies.API.HelperModels;
using Movies.API.Services.Contracts;
using Movies.API.Settings;
using Movies.API.Settings.Contracts;
using Newtonsoft.Json;
using System.Net;
using ILogger = Movies.API.Services.Contracts.ILogger;
namespace Movies.API.Services
{
    public class OMDBService : IOMDBService
    {
        private readonly IOMDBAPIClientSettings _clientSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public OMDBService(IOMDBAPIClientSettings clientSettings, IHttpClientFactory httpClientFactory, ILogger logger)
        {
            _clientSettings = clientSettings;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }


        public async Task SearchMovie(string title)
        {
            string responseContent = string.Empty;
            try
            {
                using(var omdbAPIClient = _httpClientFactory.CreateClient(OMDBAPIClientSettings.NAME))
                {
                    var response = await omdbAPIClient.GetAsync($"?apiKey={_clientSettings.APIKey}&t={WebUtility.HtmlEncode(title)}");
                    response.EnsureSuccessStatusCode();
                    responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonConvert.DeserializeObject<OMDBAPIValidResponseModel>(responseContent);


                }
            }
            catch (HttpRequestException ex)
            {
                _logger.Error($"Unsuccessful response. Response: .. . Exception: {ex}");
                var responseObj = JsonConvert.DeserializeObject<OMDBAPIInvalidResponseModel>(responseContent);
                throw new Exception();
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message, exception);
                throw;
            }
        }
    }
}
