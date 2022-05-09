using BoookStore.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBookAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<int> AddBookByAsync(BookModel BookModel);
        Task UpdateBookByAsync(int BookId, BookModel BookModel);
        Task DeleteBookByAsync(int BookId);
    }
}
