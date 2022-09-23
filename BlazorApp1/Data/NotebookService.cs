using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class NotebookService
    {
        private readonly DataContext _context;

        public NotebookService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Notebook>> GetNotebooksAsync()
        {
            return await _context.Notebooks.Include(x => x.Character).ToListAsync();
        }
    }
}