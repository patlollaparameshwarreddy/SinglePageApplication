//-----------------------------------------------------------------------
// <copyright file="MovieRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace SinglePageApp.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using SinglePageApp.Models;

    /// <summary>
    /// this is the repository class 
    /// </summary>
    public class MovieRepository
    {
        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>all movies list</returns>
        /// <exception cref="Exception">system exception</exception>
        public async Task<IList<MovieModel>> GetAllMovies()
        {
            try
            {
                ////creating connection
                using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
                {
                    ////getting all movies
                    var moveDetails = await connection.QueryAsync<MovieModel>("getMovies", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    connection.Close();
                    return moveDetails.AsList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }          
        }

        /// <summary>
        /// Gets the actors.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the type of person</returns>
        /// <exception cref="Exception">system exception</exception>
        public async Task<IList<PersonTypeModel>> GetActors(string type)
        {
            try
            {
                //// creating connection
                using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
                {
                    ////getting details by id
                    var moveDetails = await connection.QueryAsync<PersonTypeModel>("Person", new { type = type }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    connection.Close();
                    return moveDetails.AsList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets the movie by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the movie by id</returns>
        /// <exception cref="Exception">system exception</exception>
        public async Task<IList<MovieModel>> GetMovieById(int id)
        {
            try
            {
                //// creating connection
                using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
                {
                    ////getting details by id
                    var moveDetails = await connection.QueryAsync<MovieModel>("getMovies", id, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                    connection.Close();
                    return moveDetails.AsList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Inserts the movie.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the boolean</returns>
        /// <exception cref="Exception">system exception</exception>
        public bool InserteMovie(MovieModel model)
        {
            try
            {
                //// creating connection
                using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
                {
                    ////this is used for insertion operation
                    int rowsAffected = connection.Execute("AddMovie", new { model.MovieName, model.Actor, model.Director, model.Producer, model.DOR }, commandType: CommandType.StoredProcedure);
                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteById(int id)
        {
            try
            {
                //// creating connection
                using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
                {
                    //// passing id to DB to delete. store procedure approach is used
                    var respone =  connection.Execute("deleteMovie", new { id = id }, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        /// <summary>
        /// Updates the movie.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the boolean</returns>
        public bool UpdateMovie(MovieModel model)
        {
            try
            {
                ////this is used for connection with db server
                using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
                {
                    ////this is used for updating the details
                    int rowsAffected = connection.Execute("EditMove", new {model.Id, model.MovieName, model.Actor, model.Director, model.Producer, model.DOR}, commandType: CommandType.StoredProcedure);
                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}