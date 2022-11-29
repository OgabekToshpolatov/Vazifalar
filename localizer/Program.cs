using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocalization(option => 
{
    option.ResourcesPath = "Resource";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

void Conf(RequestLocalizationOptions optioons)
{
     optioons.DefaultRequestCulture = new RequestCulture(new CultureInfo("Uz"));

     optioons.SupportedCultures = new List<CultureInfo>()
     {
        new CultureInfo("Uz"),
        new CultureInfo("Ru"),
        new CultureInfo("En"),
     };

     optioons.SupportedUICultures = new List<CultureInfo>()
     {
        new CultureInfo("Uz"),
        new CultureInfo("Ru"),
        new CultureInfo("En"),
     };

     optioons.RequestCultureProviders = new List<IRequestCultureProvider>() // Yuay uchun kerak bu.
     {
        new CookieRequestCultureProvider(),
        new QueryStringRequestCultureProvider(),
        new AcceptLanguageHeaderRequestCultureProvider()

     };

};
app.UseRequestLocalization(Conf);

app.UseAuthorization();

app.MapControllers();

app.Run();
