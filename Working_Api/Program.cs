
using Microsoft.EntityFrameworkCore;
using Working_Api.DAL.Data;
using Working_Api.DAL.Interfaces;
using Working_Api.DAL.Repositories;
using Working_Api.Domain.Entities;
using Working_Api.Services.Implementation;
using Working_Api.Services.Interface;

namespace Working_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IBaseRepository<Service>, ServicesRepository>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IBaseRepository<Post>, PostRepository>();
            builder.Services.AddTransient<IPostService, PostService>();
            builder.Services.AddScoped<IBaseRepository<Worker>,  WorkerRepository>();
            builder.Services.AddScoped<IWorkerService, WorkerService>();
            builder.Services.AddScoped<IBaseRepository<Project> , ProjectRepository>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IManagerFile, ManagerFile>();
            builder.Services.AddDbContext<ApplicationDbContext>(option =>

            option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))

            );
            var app = builder.Build();


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
