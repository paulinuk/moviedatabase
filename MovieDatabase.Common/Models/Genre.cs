using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Common.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }

    }
}
