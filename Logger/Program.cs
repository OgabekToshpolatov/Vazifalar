using logger.Data;
using logger.Entities;
using logger.Logger;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddProvider(new LoggerProvider());

var logger = new LoggerConfiguration()
    .WriteTo.File(
        path: "Log.txt",
        fileSizeLimitBytes: 20,
        rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .WriteTo.TeleSink("5253246383:AAEAV5JYLkaElN4jzQ1OJb2a27ABQHa2kq4", "5592363193")
    .CreateLogger();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
{
   options.UseSqlite("Data Source=db.db");
});

builder.Services.AddIdentity<User, Role>(options =>
    {
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
