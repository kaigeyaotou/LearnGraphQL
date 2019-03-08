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
    public class BookQuery : ObjectGraphType
    {
        private IBookService ibookService;
        public BookQuery(IBookService IBookService)
        {
            Name = "Book";
            ibookService = IBookService;
            Field<ListGraphType<BookType>>("books", resolve: context => ibookService.GetAllAsync());

            Field<BookType>("book", arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }), resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  return ibookService.GetByIdAsync(id);
              });
           
        }
    }
}
