using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace apiController.Controllers
{
    
    public class apiController : Controller
    {
        private readonly MvcMovieContext _context;

        public apiController(MvcMovieContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DetailsAsJson(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Json(movie); // Convert movie object to JSON
            }

   
    }
}