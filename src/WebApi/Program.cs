using Application;
using Infrastructure;
using WebApi.Configurations;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddJsonConfiguration();
builder.Services.AddSwagger();
builder.Services.AddCorsPolicy();

builder.Services.RegisterApplicationUseCases();
builder.Services.RegisterApplicationExternalDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomMiddlewares();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
