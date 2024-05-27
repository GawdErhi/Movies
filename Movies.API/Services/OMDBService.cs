using Azure;
using Movies.API.DTOs;
using Movies.API.HelperModels;
using Movies.API.Models;
using Movies.API.Repository.Contracts;
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
        private readonly IGenreRepository _genreRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IWriterRepository _writerRepository;
        private readonly IActorRepository _actorRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMovieDetailRepository _movieDetailRepository;
        private readonly ILogger _logger;

        public OMDBService(IOMDBAPIClientSettings clientSettings, IHttpClientFactory httpClientFactory, IGenreRepository genreRepository, IDirectorRepository directorRepository, IWriterRepository writerRepository, IActorRepository actorRepository,  ILogger logger, ILanguageRepository languageRepository, ICountryRepository countryRepository, IMovieDetailRepository movieDetailRepository)
        {
            _clientSettings = clientSettings;
            _logger = logger;
            _genreRepository = genreRepository;
            _directorRepository = directorRepository;
            _writerRepository = writerRepository;
            _actorRepository = actorRepository;
            _httpClientFactory = httpClientFactory;
            _languageRepository = languageRepository;
            _countryRepository = countryRepository;
            _movieDetailRepository = movieDetailRepository;
        }

        /// <summary>
        /// searches for movie with title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<dynamic> SearchMovie(string title)
        {
            string responseContent = string.Empty;
            try
            {
                var existingMovie = await _movieDetailRepository.GetMovieByTitle(title);
                if(existingMovie != null) { return existingMovie; }

                using(var omdbAPIClient = _httpClientFactory.CreateClient(OMDBAPIClientSettings.NAME))
                {
                    var response = await omdbAPIClient.GetAsync($"?apiKey={_clientSettings.APIKey}&t={WebUtility.HtmlEncode(title)}");
                    response.EnsureSuccessStatusCode();
                    responseContent = await response.Content.ReadAsStringAsync();
                    var responseObj = JsonConvert.DeserializeObject<OMDBAPIValidResponseModel>(responseContent);
                    if (!responseObj.Response) { return JsonConvert.DeserializeObject<OMDBAPIInvalidResponseModel>(responseContent); }
                    //begin transaction
                    _movieDetailRepository.CreateTransaction();

                    //get genres
                    List<GenreDTO> genres = new List<GenreDTO>();
                    foreach (var genreName in responseObj.Genre.Split(",")) { genres.Add(await _genreRepository.TrySaveAsync(genreName)); }

                    //get director
                    DirectorDTO director = await _directorRepository.TrySaveAsync(responseObj.Director);

                    //get writers
                    List<WriterDTO> writers = new List<WriterDTO>();
                    foreach (var writerName in responseObj.Writers.Split(",")) { writers.Add(await _writerRepository.TrySaveAsync(writerName)); }

                    //get actors
                    List<ActorDTO> actors = new List<ActorDTO>();
                    foreach (var actorName in responseObj.Actors.Split(",")) { actors.Add(await _actorRepository.TrySaveAsync(actorName)); }

                    //get supported languages
                    List<LanguageDTO> supportedLanguages = new List<LanguageDTO>();
                    foreach (var languageName in responseObj.Languages.Split(",")) { supportedLanguages.Add(await _languageRepository.TrySaveAsync(languageName)); }

                    //get supported countries
                    List<CountryDTO> supportedCountries = new List<CountryDTO>();
                    foreach (var countryName in responseObj.Country.Split(",")) { supportedCountries.Add(await _countryRepository.TrySaveAsync(countryName)); }

                    string movieDetailId = Guid.NewGuid().ToString();

                    //build movie detail model
                    MovieDetail movieDetails = new MovieDetail
                    {
                        Id = movieDetailId,
                        Title = responseObj.Title,
                        Year = responseObj.Year,
                        Rated = responseObj.Rated,
                        Released = responseObj.Released,
                        Runtime = responseObj.Runtime,
                        Genres = genres.Select(x => new MovieDetailGenre { Id = Guid.NewGuid().ToString(), MovieDetailId = movieDetailId, GenreId = x.Id }).ToList(),
                        DirectorId = director.Id,
                        Writers = writers.Select(x => new MovieDetailWriter { Id = Guid.NewGuid().ToString(), MovieDetailId = movieDetailId, WriterId = x.Id }).ToList(),
                        Actors = actors.Select(x => new MovieDetailActor { Id = Guid.NewGuid().ToString(), MovieDetailId = movieDetailId, ActorId = x.Id }).ToList(),
                        Plot = responseObj.Plot,
                        Languages = supportedLanguages.Select(x => new MovieDetailLanguage { Id = Guid.NewGuid().ToString(), MovieDetailId = movieDetailId, LanguageId = x.Id }).ToList(),
                        Countries = supportedCountries.Select(x => new MovieDetailCountry { Id = Guid.NewGuid().ToString(), MovieDetailId = movieDetailId, CountryId = x.Id }).ToList(),
                        Awards = responseObj.Awards,
                        Poster = responseObj.Poster,
                        Metascore = responseObj.Metascore,
                        ImdbRating = responseObj.ImdbRating,
                        ImdbVotes = responseObj.ImdbVotes,
                        ImdbId = responseObj.ImdbID,
                        Type = responseObj.Type,
                        DVD = responseObj.DVD,
                        BoxOffice = responseObj.BoxOffice,
                        Production = responseObj.Production,
                        Website = responseObj.Website,
                        Ratings = responseObj.Ratings.Select(x => new Rating { Id = Guid.NewGuid().ToString(), MovieDetailId = movieDetailId, Source = x.Source, Value = x.Value }).ToList()
                    };

                    _movieDetailRepository.Add(movieDetails);
                    await _movieDetailRepository.SaveChangesAsync();
                    _movieDetailRepository.CommitTransaction();

                    return new MovieDetailDTO { Id = movieDetailId, Title = movieDetails.Title, Poster = movieDetails.Poster, Rated = movieDetails.Rated, Runtime = movieDetails.Runtime, Year = movieDetails.Year };
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.Error($"Unsuccessful response. Exception: {ex}");
                var responseObj = JsonConvert.DeserializeObject<OMDBAPIInvalidResponseModel>(responseContent);
                return responseObj;
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message, exception);
                throw;
            }
        }

        /// <summary>
        /// Gets movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MovieDetailDTO> GetMovie(string id)
        {
            try
            {
                return await _movieDetailRepository.GetMovieById(id);
            }catch(Exception exception)
            {
                _logger.Error(exception.Message, exception);
                throw;
            }
        }
    }
}
