using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class MovieDetail : BaseModel
    {
        public virtual string Title { get; set; }

        public virtual string Year { get; set; }

        public virtual string Rated { get; set; }

        public virtual string Released { get; set; }

        public virtual string Runtime { get; set; }

        [NotMapped]
        public virtual List<MovieDetailGenre> Genres { get; set; }

        [ForeignKey(nameof(Director))]
        public virtual string DirectorId { get; set; }

        [NotMapped]
        public virtual Director Director { get; set; }

        [NotMapped]
        public virtual List<MovieDetailWriter> Writers { get; set; }

        [NotMapped]
        public virtual List<MovieDetailActor> Actors { get; set; }

        public virtual string Plot { get; set; }

        [NotMapped]
        public virtual List<MovieDetailLanguage> Languages { get; set; }

        [NotMapped]
        public virtual List<MovieDetailCountry> Countries { get; set; }

        public virtual string Awards { get; set; }

        public virtual string Poster { get; set; }

        public virtual string Metascore { get; set; }

        public virtual string ImdbRating { get; set; }

        public virtual string ImdbVotes { get; set; }

        public virtual string ImdbId { get; set; }

        public virtual string Type { get; set; }

        public virtual string DVD { get; set; }

        public virtual string BoxOffice { get; set; }

        public virtual string Production { get; set; }

        public virtual string Website { get; set; }

        [NotMapped]
        public virtual List<Rating> Ratings { get; set; }
    }
}
