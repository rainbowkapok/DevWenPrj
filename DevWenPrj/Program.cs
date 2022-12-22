using NLog;
using NLog.Web;
using DevWenPrj.Models;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
try
{
    var builder = WebApplication.CreateBuilder(args);

    

    //�NNLog���U�즹�M�פ�
    builder.Logging.ClearProviders();
    //�]�wlog�������̤p����
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
    // ����]�w���~�����~����
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    //���T�w�b�����ɡA��nlog����
    LogManager.Shutdown();
}