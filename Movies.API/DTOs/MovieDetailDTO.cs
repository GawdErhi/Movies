namespace Movies.API.DTOs
{
    public class MovieDetailDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string Rated { get; set; }

        public string Runtime { get; set; }

        public string Poster { get; set; }

        public string Plot { get; set; }

        public List<RatingDTO> Ratings { get; set; }

        public List<WriterDTO> Writers { get; set; }

        public List<ActorDTO> Actors { get; set; }

        public List<LanguageDTO> SupportedLanguages { get; set; }

        public List<CountryDTO> AvailableCountries { get; set; }

        public string Metascore { get; set; }

        public string ImdbRating { get; set; }

        public string ImdbVotes { get; set; }

        public string BoxOffice { get; set; }

        public string Production { get; set; }

        public string Website { get; set; }
    }
}
