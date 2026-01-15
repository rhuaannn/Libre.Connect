using Libre.Connect.Application.DI;
using Libre.Connect.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen();
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

