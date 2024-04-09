using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Library.Context;
using Server.Library.Model.Entities;
using Server.Library.Model.ViewModel;
using System.Net;

namespace Server.Main.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public MoviesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("get-movies")]
        public async  Task<IActionResult> GetMovie()
        {
            var res = await _dbContext.Movie.ToListAsync();
            return  Ok(res);
        }


        // GET: api/get-movie/5
        [HttpGet("get-movie/{id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] long id)
        {
            var movie = await _dbContext.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        
        [HttpPut("update-movie/{id}")]
        public async Task<IActionResult> PutMovie([FromRoute] long id, MovieViewModel query)
        {
            var movie = await _dbContext.Movie.FindAsync(id);
            if (movie is null)
            {
                return BadRequest();
            }
            //Movie movie=new Movie();
            movie.Id = id;  
            movie.Title = query.Title;
            movie.CreatedAt = DateTime.Now;
            movie.UpdatedAt = DateTime.Now;
            movie.ImageUrl = query.ImageUrl;
            movie.Owner = query.Owner;
            movie.Rating = query.Rating;
            movie.Genre = query.Genre;
            //_dbContext.Update(movie);
            //_dbContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
       
        [HttpPost("post-movie")]
        public async Task<IActionResult> PostMovie([FromBody] MovieViewModel query)
        {
            Movie movie=new Movie();
            movie.Title=query.Title;    
            movie.Genre=query.Genre;
            movie.Rating=query.Rating;
            movie.ReleaseDate=query.ReleaseDate;
            movie.ImageUrl = query.ImageUrl;
            movie.Owner = query.Owner;
            _dbContext.Movie.Add(movie);
            await _dbContext.SaveChangesAsync();

            //return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);.
            return new StatusCodeResult((int)HttpStatusCode.Created);
        }

        // DELETE: api/delete-movie/5
        [HttpDelete("delete-movie/{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute]long id)
        {
            var movie = await _dbContext.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movie.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return new StatusCodeResult((int)HttpStatusCode.NoContent);
        }

        private bool MovieExists(long id)
        {
            return _dbContext.Movie.Any(e => e.Id == id);
        }
    }
}
