using Microsoft.EntityFrameworkCore;
using RestFullApiFirstProject.Models;

namespace RestFullApiFirstProject.Data
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }

    }
}
