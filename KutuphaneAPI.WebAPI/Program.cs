using KutuphaneAPI.Application.Services;
using KutuphaneAPI.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// Swagger servislerini ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Di�er servis kay�tlar�...
builder.Services.AddDbContext<KutuphaneDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KutuphaneDb")));
builder.Services.AddScoped<IKitapService, KitapService>();
builder.Services.AddScoped<IOduncService, OduncService>();
builder.Services.AddScoped<ILoglamaService, LoglamaService>();


// **AddCors buraya ta��nd�**
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger'� her ortamda a� ve ana sayfa olarak ayarla
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kutuphane API v1");
    c.RoutePrefix = "swagger";  // Swagger UI art�k /swagger yolunda olacak
});


app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
