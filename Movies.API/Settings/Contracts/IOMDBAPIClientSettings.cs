namespace Movies.API.Settings.Contracts
{
    public interface IOMDBAPIClientSettings
    {
        public string BaseURL { get; set; }

        public string APIKey { get; set; }
    }
}
