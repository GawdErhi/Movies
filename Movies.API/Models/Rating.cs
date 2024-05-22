using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class Rating : BaseModel
    {
        [ForeignKey(nameof(MovieDetail))]
        public string MovieDetailId { get; set; }

        [NotMapped]
        public MovieDetail MovieDetail { get; set; }

        public string Source { get; set; }

        public string Value { get; set; }
    }
}
