using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiatDo.Data;
using GiatDo.Data.Infrastructure;
using GiatDo.Data.Repositories;
using GiatDo.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors.Security;

namespace GIatDo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GiatDoDbContext>();

            #region DI solutions
            //add for data
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IAdminService, AdminService>();


            services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddTransient<IServiceTypeService, ServiceTypeService>();

            services.AddTransient<ISlotService, SlotService>();
            services.AddTransient<ISlotRepository, SlotRepository>();

            services.AddTransient<IShipperService, ShipperService>();
            services.AddTransient<IShipperRepository, ShipperRepository>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ISlotService, SlotService>();
            services.AddTransient<ISlotRepository, SlotRepository>();

            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceRepository, ServiceRepository>();

            services.AddTransient<IOrderService, OrderServices>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IOrderSService, OrderSService>();
            services.AddTransient<IOrderServiceRepository, OrderServiceRepository>();

            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            #endregion

            #region Setup1
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            #endregion

            //#region Identity
            //services.AddAuthorization();
            //var authBuilder = services.AddIdentityCore<MyUser>(o =>
            //{
            //    // configure identity options
            //    o.Password.RequireDigit = false;
            //    o.Password.RequireLowercase = false;
            //    o.Password.RequireUppercase = false;
            //    o.Password.RequireNonAlphanumeric = false;
            //    o.Password.RequiredLength = 6;
            //    o.Password.RequiredUniqueChars = 0;

            //    // Lockout settings.
            //    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    o.Lockout.MaxFailedAccessAttempts = 5;
            //    o.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    o.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    o.User.RequireUniqueEmail = false;
            //});
            //authBuilder = new IdentityBuilder(authBuilder.UserType, typeof(IdentityRole), authBuilder.Services);
            //authBuilder.AddEntityFrameworkStores<KTDbContext>().AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.SlidingExpiration = true;
            //});

            //services.AddIdentity<MyUser, IdentityRole>()
            //    .AddEntityFrameworkStores<KTDbContext>()
            //    .AddDefaultTokenProviders();

            //services.AddScoped<IUserClaimsPrincipalFactory<MyUser>, UserClaimsPrincipalFactory<MyUser, IdentityRole>>();

            ////security key
            //string securityKey = "qazedcVFRtgbNHYujmKIolp";

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidIssuer = securityKey,
            //        ValidAudience = securityKey
            //    };
            //});
            //#endregion

            #region Swagger
            services.AddSwagger();
            #endregion

            #region Cors
            services.AddCors(options =>
            options.AddPolicy("AllowAll", builder => builder
                                    .WithOrigins("http://localhost:4300", "http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials()));
            #endregion
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseAuthentication();
            app.UseStaticFiles();

            #region Swagger
            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;

                settings.GeneratorSettings.Title = "GIATDO API";

                settings.GeneratorSettings.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));

                settings.GeneratorSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("Bearer",
                    new SwaggerSecurityScheme
                    {
                        Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "Copy 'Bearer ' + valid JWT token into field",
                        In = SwaggerSecurityApiKeyLocation.Header
                    }));
            });
            #endregion
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
