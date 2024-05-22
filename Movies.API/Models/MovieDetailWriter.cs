using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class MovieDetailWriter : BaseModel
    {
        [ForeignKey(nameof(MovieDetail))]
        public virtual string MovieDetailId { get; set; }

        [NotMapped]
        public virtual MovieDetail MovieDetail { get; set; }

        [ForeignKey(nameof(Writer))]
        public virtual string WriterId { get; set; }

        [NotMapped]
        public virtual Writer Writer { get; set; }
    }
}
