using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class Genre : BaseModel
    {
        public virtual string Name { get; set; }

        [NotMapped]
        public virtual List<MovieDetailGenre> GenreMovieDetails { get; set; }
    }
}
