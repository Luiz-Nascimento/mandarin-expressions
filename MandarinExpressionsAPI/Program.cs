using Microsoft.EntityFrameworkCore;
using MandarinExpressionsAPI.Infra;
using MandarinExpressionsAPI.Middlewares;
using MandarinExpressionsAPI.Repositories;
using MandarinExpressionsAPI.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IExpressionRepository, ExpressionRepository>();
builder.Services.AddScoped<IExpressionService, ExpressionService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();