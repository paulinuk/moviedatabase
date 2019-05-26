namespace MovieDatabase.Common.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<MovieRating> MovieRatings { get; set; }

        public User()
        {
            MovieRatings = new List<MovieRating>();
        }
    }
}
