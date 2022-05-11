using BookAPI.Models;
using BookAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly BookContext _context;
        public BookRepository(BookContext bookContext)
        {
            _context = bookContext;
        }
        
        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
             await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            var book = await _context.Books.FindAsync(id) ?? null;
            return book;
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
