namespace MovieDatabase.Common.Models
{
    public class SearchCriteria
    {
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public string Genres { get; set; }

        public bool IsValid
        {
            get
            {
                var result = string.IsNullOrEmpty(Title) == false || string.IsNullOrEmpty(Genres) == false || YearOfRelease != 0;
                return result;
            }
        }
    }
}
