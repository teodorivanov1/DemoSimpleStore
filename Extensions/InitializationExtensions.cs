using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.Enums;
using SimpleStoreWeb.Data.Repositories;
using SimpleStoreWeb.Data.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStoreWeb.Extensions
{
    public static class InitializationExtensions
    {
        private const string Admin = "admin";
        private const string UsersPassword = "123";

        public static IHost MigratePending<TContext>(this IHost host) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>() ?? throw new NullReferenceException(nameof(services));

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            return host;
        }


        public static bool NoSeed(this IHost host)
        {
            bool result = false;
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole<int>>>() ?? throw new NullReferenceException(nameof(services));

                result = !roleManager.Roles.Any();
            }
            return result;
        }

        /// <summary>
        /// Initialize application roles for identity provider. 
        /// See ApplicationRoles enum.
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static async Task<IHost> AddPredefinedRoles(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var roleManager = services.GetService<RoleManager<IdentityRole<int>>>() ?? throw new NullReferenceException(nameof(services));
                foreach (var role in Enum.GetNames(typeof(ApplicationRoles)))
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole<int>(role));
                    }
                }
            }
            return host;
        }

        /// <summary>
        /// Seeds users
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static async Task<IHost> AddPredefinedUsers(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetService<UserManager<ApplicationUser>>() ?? throw new NullReferenceException(nameof(services));
                var candidates = new List<ApplicationUser>()
                {
                    new ApplicationUser(){ UserName = Admin },
                    new ApplicationUser(){ UserName = "user" },
                    new ApplicationUser(){ UserName = "user2" }
                };

                for (int i = 0; i < candidates.Count; i++)
                {
                    if (i >= 1)
                    {
                        await userManager.CreateAsync(candidates[i], UsersPassword);
                        await userManager.AddToRoleAsync(candidates[i], ApplicationRoles.User.ToString());
                    }
                    else
                    {
                        await userManager.CreateAsync(candidates[i], Admin);
                        await userManager.AddToRoleAsync(candidates[i], ApplicationRoles.Administrator.ToString());
                    }
                }
            }
            return host;
        }

        public static async Task<IHost> AddProducts(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var repo = services.GetService<IRepository<Product>>() ?? throw new NullReferenceException(nameof(services));
                List<Product> products = new ();
                products = products.CreateSeed();

                foreach (var product in products)
                {
                    await repo.InsertAsync(product);
                    await repo.SaveAsync();
                }
            }
            return host;
        }

        /// <summary>
        /// Seeds initial categories
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static async Task<IHost> AddPredefinedCategoies(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var repository = services.GetService<IRepository<Category>>() ?? throw new NullReferenceException(nameof(services));
                #pragma warning disable format
                var categories = new List<Category>()
                {
                    new Category(){ Name = "Rock" },
                    new Category(){ Name = "Jazz" },
                    new Category(){ Name = "Blues"}
                };
                #pragma warning restore format
                categories.ForEach(async category => await repository.InsertAsync(category));

                await repository.SaveAsync();
            }
            return host;
        }

        /// <summary>
        /// Set waek passwords for test purpose. Do not use on prod.
        /// </summary>
        /// <param name="_"></param>
        /// <returns>PasswordOptions</returns>
        /// 
        #pragma warning disable format
        public static PasswordOptions UseWeakPasswords(this PasswordOptions passwordOptions)
        {
            
            passwordOptions.RequiredLength          = 1;
            passwordOptions.RequireNonAlphanumeric  = false;
            passwordOptions.RequireUppercase        = false;
            passwordOptions.RequireLowercase        = false;
            passwordOptions.RequireDigit            = false;
            return passwordOptions;
        }
        #pragma warning restore format

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Category>), typeof(CategoryRepository));
            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(IRepository<Order>), typeof(OrderRepository));
            services.AddScoped(typeof(IRepository<OrderItem>), typeof(OrderItemRepository));
            return services;
        }
    }
}
