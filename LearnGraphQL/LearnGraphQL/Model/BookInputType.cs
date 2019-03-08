using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQL.Model
{
    public class BookInputType : InputObjectGraphType<BookType>
    {
        public BookInputType()
        {
            Name = "bookInput";
            Description = "book input attibutes";

            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<DecimalGraphType>("price");

        }
    }
}
