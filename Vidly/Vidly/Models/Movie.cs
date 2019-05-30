using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }
        
        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name ="Date Added")]
        public DateTime? DateAdded { get; set; }

        
        [Display(Name ="Number In Stock")]
        [Range(1,100)]
        public int NumberInStock { get; set; }
    }
}