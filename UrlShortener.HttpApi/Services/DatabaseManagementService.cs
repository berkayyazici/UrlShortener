using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.EntityFrameworkCore;

namespace UrlShortener.HttpApi.Services
{
    public class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<EfContext>().Database.Migrate();
            }
        }
    }
}
