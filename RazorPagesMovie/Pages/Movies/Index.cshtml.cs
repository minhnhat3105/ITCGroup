using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RazorPagesMovie.Pages.Movies
{
#pragma warning disable CS8618
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var genreQuery = from m in _context.Movie
                             orderby m.Genre
                             select m.Genre;

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString)) movies = movies.Where(m => m.Title.Contains(SearchString));

            if (!string.IsNullOrEmpty(MovieGenre)) movies = movies.Where(m => m.Genre.Equals(MovieGenre));

            Movie = await movies.ToListAsync();

            //
            //if (_context.Movie != null)
            //{
            //    Movie = await _context.Movie.ToListAsync();
            //}
        }
    }
#pragma warning restore CS8618
#pragma warning restore CS8604
}
