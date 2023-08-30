using Business.PrimaryAdapter;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extension
{
    public static class DiExtension
    {
        public static void AddFermeBusiness(this IServiceCollection services)
        {
            services.AddScoped<ITicketManager, TicketManager>();
        }
    }
}
