using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Kdniao.Core;
using Kdniao.Core.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
            services.AddQueuePolicy(options =>
            {
                //最大并发请求数
                options.MaxConcurrentRequests = 50;
                //请求队列长度限制
                options.RequestQueueLimit = 10;
            });

            services.AddKdniao(options =>
            {
                options.EBusinessID = "test1596820";    // 电商ID
                options.AppKey = "e4d81345-4b85-4cf7-81d7-6a0ab8f0fa19";    // 电商加密私钥，快递鸟提供，注意保管，不要泄漏
                options.IsSandBox = true;   // 是否为沙箱环境
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    //设置时间格式
                    options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter("yyyy-MM-dd HH:mm:ss"));
                    //设置bool获取格式
                    options.JsonSerializerOptions.Converters.Add(new BoolJsonConverter());
                    //保持属性名称不变
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    //不使用驼峰样式的key
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                    //获取或设置要在转义字符串时使用的编码器
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                });

            services.AddLogging(options =>
            {
                options.AddConsole();
            });

            //地址栏全部小写 兼容linux 
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
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
                    Description = "Kdniao.Core 是基于.NET Core，根据快递鸟官方API文档开发的跨平台SDK集。官方文档地址：http://www.kdniao.com/api-all",
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

            //添加并发限制中间件
            app.UseConcurrencyLimiter();

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
