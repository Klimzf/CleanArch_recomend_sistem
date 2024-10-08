using CleanArch_recomend_sistem.application;
using CleanArch_recomend_sistem.Core;
using CleanArch_recomend_sistem.Infrastructure.Db;
using CleanArch_recomend_sistem_api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var entityTypes = typeof(IEntity).Assembly
                                 .GetTypes()
                                 .Where(x => typeof(IEntity).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

var serviceTypes = typeof(IService).Assembly
                                  .GetTypes()
                                  .Where(x => typeof(IService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
foreach (var entityType in entityTypes)
    builder.Services.AddSingleton(typeof(IRepository<>).MakeGenericType(entityType), typeof(BasicRepository<>).MakeGenericType(entityType));

foreach (var serviceType in serviceTypes)
    builder.Services.AddSingleton(serviceType);

// Add services to the container.
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

app.UseHttpsRedirection();

app.MapProjectEndpoints();

app.Run();
