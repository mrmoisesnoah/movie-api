using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }
        [Required(ErrorMessage = "Title field is required, can't be left blank")]
        [StringLength(50, ErrorMessage = "Field length size is restrict to 50 characteres")]
        public string Genre { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "Duration must be between 70min to 600max minutes")]
        public int Duration { get; set; }

    }
}
