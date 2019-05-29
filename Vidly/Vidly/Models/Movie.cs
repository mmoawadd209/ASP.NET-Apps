

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

       
        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        
        [Display(Name ="Added On")]
        public DateTime? DateAdded { get; set; }

        
        [Display(Name ="Number In Stock")]
        public int NumberInStock { get; set; }
    }
}