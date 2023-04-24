using Microsoft.EntityFrameworkCore;
using Products.Data.Context;
using Products.Data.Repositories;
using Products.Data.Repositories.@base;
using Products.Domain.Interfaces.Repository;
using Products.Domain.Interfaces.Repository.@base;
using Products.Domain.Interfaces.Services;
using Products.Domain.Interfaces.Services.Config;
using Products.Service.Config;
using Products.Service.Entities;
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
            services.AddScoped<ISalesOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IProductReferencesRepository, ProductReferencesRepository>();
            services.AddScoped<IProductQATestsRepository, ProductQATestsRepository>();
            #endregion

            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISalesOrderService, SalesOrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>(); // so existe a service, utiliza repo do USER para funcionalidades
            services.AddScoped<IProductReferencesService, ProductReferencesService>();
            services.AddScoped<IProductQATestsService, ProductQATestsService>();
            #endregion 

            return services;
        }
    }
}
