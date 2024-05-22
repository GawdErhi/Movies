using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class Country : BaseModel
    {
        public virtual string Name { get; set; }

        [NotMapped]
        public virtual List<MovieDetailCountry> CountryMovieDetails { get; set; }
    }
}
