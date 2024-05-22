using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class Writer : BaseModel
    {
        public virtual string Name { get; set; }

        [NotMapped]
        public virtual List<MovieDetailWriter> WriterMovieDetails { get; set; }
    }
}
