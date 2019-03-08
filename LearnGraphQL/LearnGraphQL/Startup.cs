using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using LearnGraphQL.Model;
using LearnGraphQL.Schema;
using LearnGraphQL.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LearnGraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();

            services.AddSingleton<BookType>();
            services.AddSingleton<AuthorType>();
            services.AddSingleton<BookQuery>();
            services.AddSingleton<BookSchema>();
            services.AddSingleton<BookMutation>();
            services.AddSingleton<BookInputType>();



            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));


            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
    .AddWebSockets() // Add required services for web socket support
    .AddDataLoader(); // Add required services for DataLoader support
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();

            // use websocket middleware for ChatSchema at path /graphql
            app.UseGraphQLWebSockets<BookSchema>("/graphql");

            // use HTTP middleware for ChatSchema at path /graphql
            app.UseGraphQL<BookSchema>("/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());


        }
    }
}
