using Newtonsoft.Json;

namespace Movies.API.HelperModels
{
    public class OMDBAPIResponseModel
    {
        [JsonProperty("Response")]
        public bool Response { get; set; }
    }

    public class OMDBAPIValidResponseModel : OMDBAPIResponseModel
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Released")]
        public string Released { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Writer")]
        public string Writers { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("Language")]
        public string Languages { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Awards")]
        public string Awards { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("Ratings")]
        public List<OMDBAPIRatingResponse> Ratings { get; set; }

        [JsonProperty("Metascore")]
        public string Metascore { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }

        [JsonProperty("imdbVotes")]
        public string ImdbVotes { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("DVD")]
        public string DVD { get; set; }

        [JsonProperty("BoxOffice")]
        public string BoxOffice { get; set; }

        [JsonProperty("Production")]
        public string Production { get; set; }

        [JsonProperty("Website")]
        public string Website { get; set; }
    }

    public class OMDBAPIRatingResponse
    {
        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public class OMDBAPIInvalidResponseModel : OMDBAPIResponseModel
    {
        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
