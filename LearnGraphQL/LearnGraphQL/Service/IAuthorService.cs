using LearnGraphQL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQL.Service
{
    public interface IAuthorService
    {
        Task<Author> GetByIdAsync(int Id);
        Task<IEnumerable<Author>> GetAllAsync();

    }
}
