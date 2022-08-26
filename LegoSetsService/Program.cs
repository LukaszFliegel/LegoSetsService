using LegoSetsService.Configuration;
using LegoSetsService.Dal;
using LegoSetsService.Dal.Interfaces;
using LegoSetsService.Dal.Providers;
using LegoSetsService.Services;
using LegoSetsService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ExternalSitesUrls>(builder.Configuration.GetSection("ExternalSitesUrls"));

builder.Services.AddSingleton<IDbConnectionProvider, DbConnectionProvider>();
builder.Services.AddTransient<ISetsRepository, SetsRepository>();
builder.Services.AddTransient<ISetsServices, SetsServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
