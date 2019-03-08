using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnGraphQL.DBModel;
using LearnGraphQL.TempDate;

namespace LearnGraphQL.Service
{
    public class BookService : IBookService
    {
        public Task<Book> AddAsync(Book book)
        {
            Data data = new Data();
            Book entity = new Book()
            {
                AuthorId = 1,
                CreatedAt = DateTime.Now,
                Deleted = false,
                Id = book.Id,
                Name = book.Name,
                Price = book.Price
            };
            data.InsertBook(book);

            return Task.FromResult(book);
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            Data data = new Data();
            return Task.FromResult(data.GetBooks());
        }

        public Task<IEnumerable<Book>> GetByAuthorIdAsync(int authorId)
        {
            Data data = new Data();
            return Task.FromResult(data.GetBooks().Where(a => a.AuthorId == authorId));
        }

        public Task<Book> GetByIdAsync(int Id)
        {
            Data data = new Data();
            return Task.FromResult(data.GetBooks().FirstOrDefault(a => a.Id == Id && a.Deleted == false));
        }


    }
}
