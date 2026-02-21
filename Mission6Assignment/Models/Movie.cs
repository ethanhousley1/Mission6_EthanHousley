using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission6Assignment.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public int? CategoryId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Year is required")]
    [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100")]
    public int? Year { get; set; }

 
    public string? Director { get; set; }

    [Required(ErrorMessage = "Rating is required")]
    public string? Rating { get; set; }

    public int? Edited { get; set; }

    public string? LentTo { get; set; }
    [Required(ErrorMessage = "CopiedToPlex is required")]
    public int CopiedToPlex { get; set; }

    [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
    public string? Notes { get; set; }

    public virtual Category? Category { get; set; }
}
