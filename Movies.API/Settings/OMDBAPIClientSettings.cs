using Movies.API.Settings.Contracts;

namespace Movies.API.Settings
{
    public class OMDBAPIClientSettings : IOMDBAPIClientSettings
    {
        public static string NAME = "OMDBAPIClient";

        public string BaseURL { get; set; }

        public string APIKey { get; set; }
    }
}
