using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.Common.Models
{
    public class Movie
    {
        public int MovieId
        {
            get => Id;
            set => Id = value;
        }
            
        public int Id { get; set; }
        public string Title { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<MovieRating> MovieRatings { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }

        public string MovieGenresText
        {
            get
            {
                var result = string.Join(",", MovieGenres.Select(x => x.Genre.Name));
                return result;
            }
        }
    }
}