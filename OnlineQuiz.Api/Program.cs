
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineQuiz.DAL.Data.DBHelper;
using OnlineQuiz.DAL.Data.Models;
using OnlineQuiz.DAL.Repositoryies.Base;
using OnlineQuiz.DAL.Repositoryies.TrackRepository;
using OnlineQuiz.BLL.AutoMapper.TrackMapper;
using OnlineQuiz.BLL.Managers.Track;
using OnlineQuiz.BLL.Managers.Base;
using OnlineQuiz.DAL.Repositoryies.QuizRepository;
using OnlineQuiz.BLL.Managers.Quiz;
using OnlineQuiz.BLL.AutoMapper.QuizMapper;
using OnlineQuiz.BLL.Managers;
using OnlineQuiz.BLL.Managers.QuestionManager;
using OnlineQuiz.BLL.Managers.Options;
using OnlineQuiz.DAL.Repositoryies.QuestionRepository;
using OnlineQuiz.DAL.Repositoryies.OptionRepository;
using OnlineQuiz.BLL.AutoMapper.QuestionMapper;
using OnlineQuiz.BLL.AutoMapper.OptionMapper;

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
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuizMapper()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuestionMapper()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new OptionMapper()));

            //GenericRepository && GenericManager
            builder.Services.AddScoped(typeof(IRepository<,>),typeof(Repository<,>));
            builder.Services.AddScoped(typeof(IManager<,>), typeof(Manager<,>));

            //Repositories
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<IQuizRepository, QuizRepository>();
            builder.Services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            builder.Services.AddScoped<IOptionsRepository, OptionsRepository>();
            //Managers
            builder.Services.AddScoped<IQuizManager, QuizManager>();
            builder.Services.AddScoped<IQuestionManager, QuestionManager>();
            builder.Services.AddScoped<IOptionManager, OptionManager>();
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
