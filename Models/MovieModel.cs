//-----------------------------------------------------------------------
// <copyright file="MovieModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace SinglePageApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// this is movie model class
    /// </summary>
    public class MovieModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the movie.
        /// </summary>
        /// <value>
        /// The name of the movie.
        /// </value>
        [Required(ErrorMessage = "Movie name is required.")]
        public string MovieName { get; set; }

        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor.
        /// </value>
        [Required(ErrorMessage = "Actor name is required.")]
        public string Actor { get; set; }

        /// <summary>
        /// Gets or sets the director.
        /// </summary>
        /// <value>
        /// The director.
        /// </value>
        [Required(ErrorMessage = "Director name is required.")]
        public string Director { get; set; }

        /// <summary>
        /// Gets or sets the producer.
        /// </summary>
        /// <value>
        /// The producer.
        /// </value>
        [Required(ErrorMessage = "Producer name is required.")]
        public string Producer { get; set; }

        /// <summary>
        /// Gets or sets the date of release.
        /// </summary>
        /// <value>
        /// The date of release.
        /// </value>
        [Required(ErrorMessage = "date of relesase is required.")]
        public DateTime DOR { get; set; }
    }
}
