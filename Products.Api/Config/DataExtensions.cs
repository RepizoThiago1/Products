using Microsoft.EntityFrameworkCore;
using Products.Data.Context;
using Products.Data.Repositories;
using Products.Data.Repositories.@base;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Repository.@base;
using Products.Domain.Interfaces.Services;
using Products.Domain.Interfaces.Services.Config;
using Products.Service.Config;
using Products.Service.Workflow;
using Products.Service.WorkFlow;

namespace Products.Api.Config
{
    public static class DataExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region Repostories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); //montar repo das classes via composição (caso necessario) 
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>(); // so existe a service, utiliza repo do USER para funcionalidades
            #endregion

            return services;
        }
    }
}
