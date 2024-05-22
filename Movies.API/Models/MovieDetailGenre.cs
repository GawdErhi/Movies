using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class MovieDetailGenre : BaseModel
    {
        [ForeignKey(nameof(MovieDetail))]
        public virtual string MovieDetailId { get; set; }

        [NotMapped]
        public virtual MovieDetail MovieDetail { get; set; }

        [ForeignKey(nameof(Genre))]
        public virtual string GenreId { get; set; }

        [NotMapped]
        public virtual Genre Genre { get; set; }
    }
}
