using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LearnGraphQL.Schema
{
    public class BookSchema : GraphQL.Types.Schema
    {
        public BookSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            DependencyResolver = dependencyResolver;
            Query = dependencyResolver.Resolve<BookQuery>();
            Mutation = dependencyResolver.Resolve<BookMutation>();
        }
    }
}
