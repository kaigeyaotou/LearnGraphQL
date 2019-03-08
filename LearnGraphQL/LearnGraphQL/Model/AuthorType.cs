using GraphQL.Types;
using LearnGraphQL.DBModel;
using LearnGraphQL.Service;

namespace LearnGraphQL.Model
{
    public class AuthorType : ObjectGraphType<Author>
    {
        private IBookService ibookService;
        public AuthorType(IBookService IBookService)
        {
            ibookService = IBookService;
            Name = "Author";
            Description = "author query";
            Field(a => a.Id).Description("id");
            Field(a => a.Name).Description("author's name");
            Field(a => a.Age).Description("author's age");
            Field<ListGraphType<BookType>>("books", resolve: context =>
           {
               return ibookService.GetByAuthorIdAsync(context.Source.Id);
           });
        }
    }
}
