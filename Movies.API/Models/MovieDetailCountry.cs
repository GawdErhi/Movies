using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class MovieDetailCountry : BaseModel
    {
        [ForeignKey(nameof(MovieDetail))]
        public virtual string MovieDetailId { get; set; }

        [NotMapped]
        public virtual MovieDetail MovieDetail { get; set; }

        [ForeignKey(nameof(Country))]
        public virtual string CountryId { get; set; }

        [NotMapped]
        public virtual Country Country { get; set; }
    }
}
