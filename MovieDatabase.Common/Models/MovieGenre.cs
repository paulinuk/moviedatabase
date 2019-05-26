using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Common.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
