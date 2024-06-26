
using CurriculumVitae.common.Services;
using CurriculumVitae.Data;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVitae.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.            
            Console.WriteLine("Starting API");
            string connectionString = builder.Configuration?.GetConnectionString("Default")!;
            Console.WriteLine($"Connectionstring : {connectionString}");
            builder.Services.AddDbContext<CVDbContext>(options =>                
                options.UseSqlite(builder.Configuration?.GetConnectionString("Default")));

            builder.Services.AddScoped<ICurriculumVitaeServices,CurriculumVitaeServices>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
