namespace MovieDatabase.Common.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MovieRating
    {
        [Key]
        public int MovieRatingId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Column(TypeName = "decimal(18,1)")]
        public decimal Rating { get; set; }
        public int UserId { get; set; }
        public bool IsValid => Rating >= 1 && Rating <= 5;
    }
}
