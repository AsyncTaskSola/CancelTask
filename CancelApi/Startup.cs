using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CancelApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region swagger service
            //项目根目录
            var basePath = Directory.GetCurrentDirectory();
            //使用项目内容的XML解析，需要通过项目生成 
            var filePath = Path.Combine(basePath, "CancelApi.xml");
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("CancelNumber", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cancel API",
                    Description = "API for CancelNumber",
                    License = new OpenApiLicense
                    {
                        Name = "Git AsyncTask(Evan)",
                        Url = new Uri("https://github.com/AsyncTaskSola/DownLoadHaoKanVideoApi.git"),
                    },
                    Contact = new OpenApiContact
                    {
                        Name = "Evan",
                        Email = "22955559393@qq.com",
                        Url = new Uri("https://mail.qq.com/"),
                    },
                });

                //加载XML注释文档
                // 第二参数includeControllerXmlComments 为true时控制器显示中文注释
                option.IncludeXmlComments(filePath, true);
                //可添加多份XML翻译档案 ，项目分布类所需要
                //option.IncludeXmlComments(Path.Combine(basePath, "DownLoadHaoKanVideoAPI.xml"), true);
                // include document file
                // option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region Swagger
            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            //Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/CancelNumber/swagger.json", "CancelNumber Docs");

                option.RoutePrefix = string.Empty;
                option.DocumentTitle = "CancelNumber API by Author Evan";
            });
            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
