using BookAPI.Models;

namespace BookAPI.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task Delete(int id);
        Task Update(Book book);
        Task<Book> Create(Book book);

    }
}
