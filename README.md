# Kdniao.Core
Kdniao.Core 是基于.NET Core，根据快递鸟官方API文档开发的跨平台SDK集。
### 支持平台
- .Net core 3.1 (待完成)

## 二.ASP.NET Core 使用

### 1.安装程序包
```
TODO
```

### 2.添加配置

````csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddKdniao(options =>
    {
        options.EBusinessID = "1111";    // 电商ID
        options.AppKey = "11111111111";    // 电商加密私钥，快递鸟提供，注意保管，不要泄漏
        options.IsSandBox = true;   // 是否为沙箱环境 默认为false
    });
}
````
* 多账户配置
````csharp
public class MyOptionsA : KdniaoOptions {}
public class MyOptionsB : KdniaoOptions {}
````
依赖注入
````csharp
public void ConfigureServices(IServiceCollection services)
{
    services.Configure<MyOptionsA>(Configuration.GetSection("MyOptionsA"));
    services.Configure<MyOptionsB>(Configuration.GetSection("MyOptionsB"));
    services.AddKdniao();
}
````
使用
````csharp
private readonly IOptions<MyOptionsA> _options;

await _kdniaoClient.ExecuteAsync(model,_options);
````
### 3.在Controller中使用

````csharp
//通过di注入
private readonly IKdniaoClient _kdniaoClient;

public KdApiSearchController(IKdniaoClient kdniaoClient)
{
	_kdniaoClient = kdniaoClient;
}

await _kdniaoClient.ExecuteAsync(model);
````

## TODO

## BUG 反馈 TODO 