using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePageApp.Models
{
    public class MovieModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie name is required.")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = "Actor name is required.")]
        public string Actor { get; set; }

        [Required(ErrorMessage = "Director name is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Producer name is required.")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "date of relesase is required.")]
        public string DOR { get; set; }
    }
}
