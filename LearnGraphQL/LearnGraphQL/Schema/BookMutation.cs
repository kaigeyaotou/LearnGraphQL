using GraphQL.Types;
using LearnGraphQL.DBModel;
using LearnGraphQL.Model;
using LearnGraphQL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQL.Schema
{
    public class BookMutation : ObjectGraphType
    {
        private IBookService ibookService;
        public BookMutation(IBookService IBookService)
        {
            ibookService = IBookService;
            Name = "bookmutation";
            Description = "update a book";
            Field<BookType>("addbook", arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
               resolve: context =>
               {
                   var book = context.GetArgument<Book>("book");
                   return this.ibookService.AddAsync(book);
               });
        }
    }
}
