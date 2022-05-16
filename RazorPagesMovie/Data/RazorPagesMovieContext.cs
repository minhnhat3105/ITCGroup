using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
#pragma warning disable CS8618
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
#pragma warning restore CS8618
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }

        public DbSet<RazorPagesMovie.Models.User> User { get; set; }
    }
}
