using GraphQL.Types;
using LearnGraphQL.DBModel;
using LearnGraphQL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQL.Model
{
    public class BookType : ObjectGraphType<Book>
    {
        private IAuthorService iauthorService;
        public BookType(IAuthorService IAuthorService)
        {
            iauthorService = IAuthorService;
            Name = "Book";
            Description = "query book";
            Field(a => a.Id).Description("id");
            Field(a => a.Name).Description("book's name");
            Field(a => a.Price).Description("book's price");
            Field<AuthorType>("author", resolve: context =>
            {
                return iauthorService.GetByIdAsync(context.Source.AuthorId);
            });
        }
    }
}
