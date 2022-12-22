using NLog;
using NLog.Web;
using DevWenPrj.Models;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);

    

    //將NLog註冊到此專案內
    builder.Logging.ClearProviders();
    //設定log紀錄的最小等級
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();
    //builder.Services.AddControllers();
   
    builder.Services.AddControllersWithViews();
    builder.Services.AddTransient<WenDbContext>();
    builder.Services.AddAuthentication();
    builder.Services.AddSession();

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
    app.UseSession();

    app.UseStaticFiles();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    // 捕獲設定錯誤的錯誤紀錄
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    //須確定在關閉時，把nlog關閉
    LogManager.Shutdown();
}