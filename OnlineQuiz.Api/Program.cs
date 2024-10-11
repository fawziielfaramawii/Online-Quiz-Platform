
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using OnlineQuiz.DAL.Repositoryies.TrackRepository;
using OnlineQuiz.BLL.AutoMapper.TrackMapper;
using OnlineQuiz.BLL.Managers.Track;
using OnlineQuiz.DAL.Repositoryies.AdminRepositroy;
using OnlineQuiz.BLL.AutoMapper.AdminAutoMapper;
using OnlineQuiz.BLL.Managers.Admin;
using OnlineQuiz.BLL.Managers.Instructor;
using OnlineQuiz.DAL.Repositoryies.InstructorRepository;
using OnlineQuiz.BLL.AutoMapper.InstructorMapper;

namespace OnlineQuiz.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //QuicContext
            builder.Services.AddDbContext<QuizContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });

            builder.Services.AddAutoMapper(map => map.AddProfile(new TrackMapper()));

            //GenericRepository
            builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            //TrackAutoMapper
           
            builder.Services.AddScoped<ITrackManager, TrackManager>();


            //Identity
            builder.Services.AddIdentity<Users, Microsoft.AspNetCore.Identity.IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 5;
            })
               .AddEntityFrameworkStores<QuizContext>();



            //admin services
            builder.Services.AddScoped<IAdminRepositroy, AdminRepositroy>();
            builder.Services.AddScoped<IAdminManger, AdminManger>();
            //admin auto mapper
            builder.Services.AddAutoMapper(map => map.AddProfile(new AdminMapper()));

            // instructor mapper
            builder.Services.AddAutoMapper(map => map.AddProfile(new InstructorMapper()));


            // instructor services
            builder.Services.AddScoped<IInstructorManger,InstructorManger>();
            builder.Services.AddScoped<IInstructorRepository,InstructorRepository>();

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
