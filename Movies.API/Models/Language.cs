using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class Language : BaseModel
    {
        public virtual string Name { get; set; }

        [NotMapped]
        public virtual List<MovieDetailLanguage> LanguageMovieDetails { get; set; }
    }
}
