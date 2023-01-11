using Gws.Common.Services;
using Gws.Member.Api.Zkm;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
var startup = new StartUp(builder.Configuration);


startup.ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// var provider = builder.Services.BuildServiceProvider();
// var configuration = provider.GetService<SysService>();


var app = builder.Build();
//기존 npgsql sp call을 사용하기 위한 설정 
AppContext.SetSwitch("Npgsql.EnableStoredProcedureCompatMode", true);

app.UseFileServer();
app.UseRouting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
// app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// nginx 에서 사용시에 https 리디렉션을 제거 해야한다.
app.UseHttpsRedirection();

app.UseStaticFiles();

// app.UseAuthorization();

app.MapControllers();

app.Run();
