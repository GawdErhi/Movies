using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class MovieDetailActor : BaseModel
    {
        [ForeignKey(nameof(MovieDetail))]
        public virtual string MovieDetailId { get; set; }

        [NotMapped]
        public virtual MovieDetail MovieDetail { get; set; }

        [ForeignKey(nameof(Actor))]
        public virtual string ActorId { get; set; }

        [NotMapped]
        public virtual Actor Actor { get; set; }
    }
}
