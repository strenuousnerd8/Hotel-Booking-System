using Admin.Models;
using Admin.RabbitMQ;
using Admin.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AdminStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(AdminStoreDatabaseSettings)));

builder.Services.AddSingleton<IAdminStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AdminStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("AdminStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
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

// app.MapGet("/", () => RabbitC.Consumer());

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
