using Libre.Connect.Application.DI;
using Libre.Connect.Filter;
using Libre.Connect.Infra.DependencyInjection;
using Libre.Connect.Middleware;
using Libre.Connect.Redis.DI;
using Libre.Connect.Redis.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new TrimStringFilter.TrimStringsActionFilter());
}); 
builder.Services.AddSwaggerGen();
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddRedisInfra(builder.Configuration);
builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection("CacheSettings"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalMiddlewareExceptions>();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

