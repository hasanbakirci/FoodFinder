using System.Text;
using Data;
using Data.Context;
using Data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.Interfaces;
using Services.Mapping;

namespace API
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

            services.AddControllers();

            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<ICommentRepository, EfCommentRepository>();
            services.AddScoped<IFoodRepository, EfFoodRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IUserService, UserService>();
            

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<FoodApplicationDbContext>(option => option.UseNpgsql(connectionString));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin", builder =>
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // JWT Bearer için aşağıdaki kodları kullandık
            var bearer = Configuration.GetSection("Bearer"); // appsettings.json a ulaştı
            var issuer = bearer["Issuer"];
            var audience = bearer["Audience"];
            var securityKey = bearer["SecurityKey"];
            //Jwt nin nasıl üretileceğini ve oynaylanacağının kurallarını yazdık
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(option =>{
                        option.TokenValidationParameters = new TokenValidationParameters{
                            ValidateActor=true,
                            ValidateIssuer=true,
                            ValidateAudience=true,
                            ValidateIssuerSigningKey=true,
                            ValidIssuer = issuer,
                            ValidAudience = audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors("AllowMyOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
