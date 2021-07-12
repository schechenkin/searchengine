using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SearchEngine.Core.Common;
using SearchEngine.Core.Server.Indexes;

namespace SearchEngine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(Assembly.GetAssembly(typeof(Startup)))
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
            
            services.Configure<SearchOptions>(Configuration.GetSection("Search"));
            
            services.AddSingleton<RamSegment>(sp =>
            {
                var searchOptions = sp.GetRequiredService<IOptions<SearchOptions>>().Value;
                var dummyConfig = searchOptions.Indexes.First();
                IndexConfig indexConfig = new IndexConfig("dummy", IndexType.Dummy, dummyConfig.Path, null, null,
                    searchOptions.Stopwords, searchOptions.Wordforms);
                return new RamSegment(indexConfig);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Search Engine");
                });
            });
            //TODO store in DI
            //IndexStorage indexStorage = new IndexStorage(ReadConfig());
        }

        private SearchConfig ReadConfig()
        {
            throw new System.NotImplementedException();
        }
    }
}
