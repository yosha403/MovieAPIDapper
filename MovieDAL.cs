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

        public Movie GetRandomMovie()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();

                //This creates a random number based on the count of our movie list.
                //This random number then becomes the index by which we get a random movie.
                Random rnd = new Random();
                int randomNum = rnd.Next(0, movies.Count);
                connect.Close();

                return movies[randomNum];
            }
        }

        public Movie GetRandomByGenre(string genre)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where genre = '{genre}'";
                try
                {
                    connect.Open();
                    List<Movie> movies = connect.Query<Movie>(sql).ToList();
                    Random rnd = new Random();
                    int randomNum = rnd.Next(0, movies.Count);
                    connect.Close();
                    return movies[randomNum];
                }
                catch (InvalidOperationException)
                {
                    Movie error = new Movie();
                    error.Title = $"No movie found of the genre '{genre}.'";
                    return error;
                }
            }
        }
    }
}
