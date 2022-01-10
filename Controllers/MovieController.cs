using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieDAL mDAL = new MovieDAL();

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return mDAL.GetAllMovies();
        }

        [HttpGet("GetMovie/{genre}")]
        public Movie GetMovie(string genre)
        {
            Movie m = mDAL.GetMovieByGenre(genre);
            return m;
        }

        [HttpGet("random")]
        public Movie GetRandomMovie()
        {
            return mDAL.GetRandomMovie();
        }


        [HttpGet("{genre}/random")]
        public Movie GetRandomByGenre(string genre)
        {
            return mDAL.GetRandomByGenre(genre);
        }
    }   
}
