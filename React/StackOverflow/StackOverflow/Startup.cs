using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bussines;
using Bussines.Domains;
using Bussines.Domains.Interfaces;
using Data;
using Data.Repository;
using Data.Repository.Interfaces;
using EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StackOverflow
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
      services.AddDbContext<IStackOverflowDBContext, StackOverflowDBContext>(builder =>
        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddCors(options =>
      {
        options.AddPolicy("AllowAllHeaders",
              builder =>
              {
                builder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
              });
      });

      services.AddTransient<IQuestionRepository, QuestionRepository>();
      services.AddTransient<IAnswerRepository, AnswerRepository>();

      services.AddTransient<IQuestionDomain, QuestionDomain>();
      services.AddTransient<IAnswerDomain, AnswerDomain>();

      var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new Mapping()));
      services.AddSingleton(mapConfig.CreateMapper());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors("AllowAllHeaders");
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
