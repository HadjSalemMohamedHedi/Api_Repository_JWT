using AutoMapper;
using BoookStore.API.Data;
using BoookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoookStore.API.Repository

{
    public class BookRepository:IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
    {
        _context = context;
          _mapper = mapper;
        }

    public BookStoreContext Context { get; }

    public async Task<List<BookModel>> GetAllBookAsync()
    {
            /* var records =await _context.Books.Select(x => new BookModel()
             {
                 Id = x.Id,
                 Title=x.Title,
                 Desription=x.Desription
             }).ToListAsync();

             return records;*/

            var record = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(record);
    }


        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
           /* var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Desription = x.Desription
            }).FirstOrDefaultAsync();

            return records;*/

            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);

        }
        public async Task<int> AddBookByAsync(BookModel BookModel)
        {
            var book = new Books()
            {
                Title = BookModel.Title,
                Desription = BookModel.Desription
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
            
        }

        public async Task UpdateBookByAsync(int BookId,BookModel BookModel)
        {
            /*var book = await _context.Books.FindAsync(BookId);
            if(book != null)
            {
                book.Title = BookModel.Title;
                book.Desription = BookModel.Desription;
                await _context.SaveChangesAsync();
            }*/

           var book = new Books()
            {
                Id = BookModel.Id,
                Title = BookModel.Title,
                Desription = BookModel.Desription
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

        }


        public async Task DeleteBookByAsync(int BookId)
        {
            var book = new Books() { Id = BookId };
             _context.Books.Remove(book);
             await _context.SaveChangesAsync();         
            
        }




    }
}
