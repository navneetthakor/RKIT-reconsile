using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication1.Repositories;

namespace WebApplication1
{
    public static class DIExtensionMethod
    {
        public static void AddProductRepo(this IServiceCollection service)
        {
            ///<summary>
            ///single copy accross requests
            ///Persist until reload /restart of server
            /// </summary>
            //service.AddSingleton<IProductRepo, ProductRepo>();

            ///<summary>
            ///Persist for single request
            /// </summary>
            service.AddScoped<IProductRepo, ProductRepo>();

            ///<summary>
            ///provides new object whenever someone ask
            /// </summary>
            //service.AddTransient<IProductRepo, ProductRepo>();

            //whichever is defined latter will override previous one
            //so use belowed version for each of them 
            // they will do same task as above if there is no DI on given interface
            //otherwise they will just ignore it

            service.TryAddSingleton<IProductRepo, ProductRepo>();
            service.TryAddScoped<IProductRepo, ProductRepo>();
            service.TryAddTransient<IProductRepo, ProductRepo>();
        }
    }
}
