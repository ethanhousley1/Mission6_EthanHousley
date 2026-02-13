using System.ComponentModel.DataAnnotations;

namespace Mission6Assignment.Models
{
    public class Form
    {

        public int FormID { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public required string Category { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        public required string Year { get; set; }
        [Required(ErrorMessage = "Director is required")]
        public required string Director { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public required string Rating { get; set; }
        public bool? isEdited { get; set; }
        public string? Lent { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
        public string? Notes { get; set; }
    }
}
