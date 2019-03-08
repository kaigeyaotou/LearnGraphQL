using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnGraphQL.DBModel;
using LearnGraphQL.TempDate;

namespace LearnGraphQL.Service
{
    public class AuthorService : IAuthorService
    {
        public Task<IEnumerable<Author>> GetAllAsync()
        {
            Data data = new Data();
            return Task.FromResult(data.GetAuthors());
        }

        public Task<Author> GetByIdAsync(int Id)
        {
            Data data = new Data();
            return Task.FromResult(data.GetAuthors().FirstOrDefault(a => a.Id == Id && a.Deleted == false));
        }
    }
}
