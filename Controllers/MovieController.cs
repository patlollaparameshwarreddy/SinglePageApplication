using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinglePageApp.Models;
using SinglePageApp.Repository;

namespace SinglePageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [Route("AllMovies")]
        public IList<MovieModel> GetMovies()
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<MovieModel> movies = movieRepository.GetAllMovies().Result;
            return movies;
        }

        [Route("Actors")]
        public IList<PersonTypeModel> GetActors()
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<PersonTypeModel> Actors = movieRepository.GetActors().Result;
            return Actors;
        }

        [Route("Directors")]
        public IList<PersonTypeModel> GetDirectors()
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<PersonTypeModel> Directors = movieRepository.GetDirectors().Result;
            return Directors;
        }

        [Route("Producers")]
        public IList<PersonTypeModel> GetProducer()
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<PersonTypeModel> Producer = movieRepository.GetProducer().Result;
            return Producer;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IList<MovieModel> GetMovies(int id)
        {
            MovieRepository movieRepository = new MovieRepository();
            IList<MovieModel> movies = movieRepository.GetMovieById(id).Result;
            return movies;
        }

        //// POST api/values
        //[HttpPost]
        //public void Post(MovieModel model)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@MovieName", model.MovieName);
        //    param.Add("@Actor", model.Actor);
        //    param.Add("@Director", model.Director);
        //    param.Add("@Producer", model.Producer);
        //    param.Add("@DOR", model.DOR);
        //    MovieRepository movieRepository = new MovieRepository();
        //    movieRepository.AddMovies("AddMovie", param);
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public bool Delete(int id)
        {
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.DeleteById(id);
            return true;

        }
    }
}