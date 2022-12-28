using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFullApiFirstProject.Data;
using RestFullApiFirstProject.Models;

namespace RestFullApiFirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public GenresController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _dbContext.Genres.OrderBy(p => p.Name).ToListAsync();

            return Ok(item);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            var item = await _dbContext.Genres.FindAsync(id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(GenreDto dto)
        {
            Genre genre = new Genre { Name = dto.Name };
            await _dbContext.Genres.AddAsync(genre);
            _dbContext.SaveChanges();
            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateasync(int id, [FromBody] GenreDto dto)
        {
            var genre = await _dbContext.Genres.SingleOrDefaultAsync(p => p.Id == id);
            if (genre == null)
                return NotFound($"No Genre Found with id {id}");
            genre.Name = dto.Name;
            _dbContext.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = await _dbContext.Genres.SingleOrDefaultAsync(p=>p.Id==id);
            if(genre == null)
                return NotFound($"NotFound genre Not found{id}");
            _dbContext.Remove(genre);
            _dbContext.SaveChanges();
            return Ok(genre);
        }
    }
}
