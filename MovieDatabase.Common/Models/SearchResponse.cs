namespace MovieDatabase.Common.Models
{
    public class SearchResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        public decimal AverageRating { get; set; }

        public override string ToString()
        {
            var result = $"Id: {Id} {Title} Released: {YearOfRelease} AverageRating: {AverageRating} Genres: {Genres}";
            return result;
        }

    }
}
