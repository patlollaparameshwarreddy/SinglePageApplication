using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SinglePageApp.Models;

namespace SinglePageApp.Repository
{
    public class MovieRepository
    {

        public async Task<IList<MovieModel>> GetAllMovies()
        {

            using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("getMovies", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                connection.Close();
                return moveDetails.AsList();
            }
        }

        public async Task<IList<PersonTypeModel>> GetActors()
        {
            using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
            {
                var actorDetails = await connection.QueryAsync<PersonTypeModel>("getActers", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                connection.Close();
                return actorDetails.AsList();
            }
        }

        public async Task<IList<PersonTypeModel>> GetDirectors()
        {
            using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
            {
                var directorDetails = await connection.QueryAsync<PersonTypeModel>("getDirectors", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                connection.Close();
                return directorDetails.AsList();
            }
        }

        public async Task<IList<PersonTypeModel>> GetProducer()
        {
            using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
            {
                var producerDetails = await connection.QueryAsync<PersonTypeModel>("getProducers", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                connection.Close();
                return producerDetails.AsList();
            }
        }

        public async Task<IList<MovieModel>> GetMovieById(int id)
        {
            using (var connection = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=MovieInfo;Integrated Security=True"))
            {
                var moveDetails = await connection.QueryAsync<MovieModel>("getMovies", id, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                connection.Close();
                return moveDetails.AsList();
            }
        }
    }
}
