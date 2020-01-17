using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kdniao.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Example.Aspnetcore
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

            services.AddKdniao(options =>
            {
                options.EBusinessID = "test1596820";
                options.AppKey = "e4d81345-4b85-4cf7-81d7-6a0ab8f0fa19";
                options.IsSandBox = true;
            });

            #region Swagger
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kdniao.Core 测试 API ",
                    Version = "v1",
                    TermsOfService = new Uri("https://github.com/wannvmi/Kdniao.Core"),
                    Description = "Kdniao.Core 是基于.NET Core，根据快递鸟官方API文档开发的跨平台SDK集。",
                    Contact = new OpenApiContact
                    {
                        Name = "wannvmi",
                        Url = new Uri("https://github.com/wannvmi/"),
                        Email = "996198546@qq.com"
                    },
                    License = new OpenApiLicense
                    {

                    }
                });

                // 设置SWAGER JSON和UI的注释路径。
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

                options.DescribeAllParametersInCamelCase();

                // enable swagger Annotations
                options.EnableAnnotations();
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "全部 API");
                options.RoutePrefix = "";//路径配置，设置为空，表示直接访问该文件，
                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，
                //这个时候去launchSettings.json中把"launchUrl": "swagger/index.html"去掉， 然后直接访问localhost:8001/index.html即可
            });
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
