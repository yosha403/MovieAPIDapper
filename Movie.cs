using System.ComponentModel.DataAnnotations;

namespace MovieAPI
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }

        public int Year { get; set; }
        public int Runtime { get; set; }
    }
}
