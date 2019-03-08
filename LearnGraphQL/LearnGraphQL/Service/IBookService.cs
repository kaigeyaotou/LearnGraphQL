using LearnGraphQL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQL.Service
{
    public interface IBookService
    {
        Task<Book> GetByIdAsync(int Id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetByAuthorIdAsync(int authorId);
        Task<Book> AddAsync(Book book);
    }
}
