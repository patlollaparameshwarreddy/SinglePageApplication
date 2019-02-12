//-----------------------------------------------------------------------
// <copyright file="MovieController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace SinglePageApp.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using SinglePageApp.Models;
    using SinglePageApp.Repository;

    /// <summary>
    /// this class is used as controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        /// <summary>
        /// Gets the movies.
        /// </summary>
        /// <returns>the list of movies</returns>
       [Route("AllMovies")]
        public IList<MovieModel> GetMovies()
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<MovieModel> movies = movieRepository.GetAllMovies().Result;
            return movies;
        }

        /// <summary>
        /// Gets the actors.
        /// </summary>
        /// <returns>the list of actors</returns>
        [Route("person/{type}")]
        public IList<PersonTypeModel> GetActors(string type)
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<PersonTypeModel> actors = movieRepository.GetActors(type).Result;
            return actors;
        }

        /// <summary>
        /// Gets the movies by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>list of movie by id</returns>
        [HttpGet("{id}")]
        
        public IList<MovieModel> GetMoviesById(int id)
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<MovieModel> movies = movieRepository.GetMovieById(id).Result;
            return movies;
        }

        /// <summary>
        /// Adds the movie.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the response</returns>
        [HttpPost]
        public ActionResult AddMovie(MovieModel model)
        {
            MovieRepository movieRepository = new MovieRepository();
            bool response = movieRepository.InserteMovie(model);
            return this.Ok(response);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the boolean</returns>
        [HttpDelete("{id}")]
        [Route("Delete")]
        public bool Delete(int id)
        {
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.DeleteById(id);
            return true;
        }

        /// <summary>
        /// Updates the movie.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// the boolean
        /// </returns>
        [Route("Update")]
        public ActionResult UpdateMovie(MovieModel model)
        {
            MovieRepository movieRepository = new MovieRepository();
            bool response = movieRepository.UpdateMovie(model);
            return this.Ok(response);
        }
    }
}