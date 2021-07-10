

using LINQ.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Http;

namespace LINQ.WebAPI.IntegrationTest
{
    public class BaseIntegrationTest
    {
        protected readonly HttpClient client;
        public BaseIntegrationTest()
        {
            WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                    builder.ConfigureServices(services =>
                    {
                        ServiceDescriptor descriptor = services.FirstOrDefault(descr => descr.ServiceType == typeof(LINQDbContext));
                        services.Remove(descriptor);
                        services.AddDbContext<LINQDbContext>(options => options.UseInMemoryDatabase("Integration test database"));
                     }));
            client = factory.CreateClient();
        }
    }
}
