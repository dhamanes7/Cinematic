using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinematic;
using Cinematic.Models;
using CinematicLibrary.ApiClient;

namespace Cinematic.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> AllMovies;
        private MovieApiClient<Movie> _apiClient;
        private bool isFailed = false;

        public IActionResult MoviesList()
        {

            return View(AllMovies);
        }

        public MoviesController(MovieApiClient<Movie> apiClient)
        {

            _apiClient = apiClient;
            try
            {
                var response = _apiClient.GetMovies();
                AllMovies = response.Result.Take(20).ToList();
            }
            catch (Exception ex)
            {
                isFailed = true;
            }
        }


    }
}
