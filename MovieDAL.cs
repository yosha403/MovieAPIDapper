using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
{
    public class MovieDAL
    {
        public List<Movie> GetAllMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
              
                    List<Movie> movies = connect.Query<Movie>(sql).ToList();
                    connect.Close();
                    return movies;               
            }
        }
        public Movie GetMovieByGenre(string genre)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"select * from movies where genre='{genre}'";
                try
                {
                    connect.Open();
                    Movie m = connect.Query<Movie>(sql).ToList().First();
                    connect.Close();
                    return m;
                }
                catch (InvalidOperationException)
                {
                    Movie error = new Movie();
                    error.Title = "No movie found in genre " + genre;
                    return error;
                }
            }
        }
    }
}
