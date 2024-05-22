using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class Actor : BaseModel
    {
        public virtual string Name { get; set; }

        [NotMapped]
        public virtual List<MovieDetailActor> ActorMovieDetails { get; set; }
    }
}
