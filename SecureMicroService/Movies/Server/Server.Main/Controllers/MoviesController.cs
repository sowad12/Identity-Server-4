using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Library.Context;
using Server.Library.Model.Entities;

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
        [HttpGet("get-movie")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {

            return await _dbContext.Movie.ToListAsync();
        }


        // GET: api/GetMovieById/5
        [HttpGet("get-movie-by-id/{id}")]
        public async Task<ActionResult<Movie>> GetMovieById([FromRoute] int id)
        {
            var movie = await _dbContext.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        
        [HttpPut("update-movie/{id}")]
        public async Task<IActionResult> PutMovie([FromRoute] int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(movie).State = EntityState.Modified;

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
        public async Task<ActionResult<Movie>> PostMovie([FromBody]Movie movie)
        {
            _dbContext.Movie.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/delete-movie/5
        [HttpDelete("delete-movie/{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie([FromRoute]int id)
        {
            var movie = await _dbContext.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movie.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _dbContext.Movie.Any(e => e.Id == id);
        }
    }
}
