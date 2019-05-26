namespace MovieDatabase.Common.Models
{
    public class Top5Movie
    {
        public string Title { get; set; }
        public decimal AverageRating { get; set; }
        public int YearOfRelease { get; set; }
        public string Genres { get; set; }
        public int RunningTime { get; set; }
        public int Id { get; set; }
    }
}
