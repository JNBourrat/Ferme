using Business.SecondaryAdapter;
using Microsoft.Extensions.DependencyInjection;
using Repository.Profile;

namespace Repository.Extension
{
    public static class DiExtension
    {
        public static void AddFermeWeb(this IServiceCollection services)
        {
            services.AddAutoMapperWeb();
            services.AddScoped<ITicketRepository, TicketRepository>();
        }

        private static void AddAutoMapperWeb(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                var assembly = typeof(IMarkerMapper).Assembly;
                var mappers = assembly.DefinedTypes
                                      .Where(x => x.Namespace?.Equals(typeof(IMarkerMapper).Namespace, StringComparison.OrdinalIgnoreCase) ?? false);

                cfg.AddMaps(mappers);
            });
        }

    }
}
