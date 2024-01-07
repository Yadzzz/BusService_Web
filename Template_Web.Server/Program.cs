
using Template_Web.Server.ServicesExtensions;

namespace Template_Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterServices();
            builder.Services.RegisterJwtServices(builder.Configuration);

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    {
            //        builder.WithOrigins("http://localhost:3000")
            //               .AllowAnyMethod()
            //               .AllowAnyHeader();
            //    });
            //});

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });


            builder.ConfigureApplication(builder.Configuration);

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors();
            app.UseCors("AllowAnyOrigin");
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
