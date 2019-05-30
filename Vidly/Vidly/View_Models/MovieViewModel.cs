
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.View_Models
{
    public class MovieViewModel
    {
        
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        [Display(Name ="Movie Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name ="Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name ="Date Added")]
        public DateTime? DateAdded { get; set; }

        
        [Display(Name ="Number In Stock")]
        [Range(1,100)]
        public int? NumberInStock { get; set; }



        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            DateAdded = movie.DateAdded;
            ReleaseDate = movie.ReleaseDate;

        }

    }
}