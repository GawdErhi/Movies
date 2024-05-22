using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Models
{
    public class MovieDetailLanguage : BaseModel
    {
        [ForeignKey(nameof(MovieDetail))]
        public virtual string MovieDetailId { get; set; }

        [NotMapped]
        public virtual MovieDetail MovieDetail { get; set; }

        [ForeignKey(nameof(Language))]
        public virtual string LanguageId { get; set; }

        [NotMapped]
        public virtual Language Language { get; set; }
    }
}
