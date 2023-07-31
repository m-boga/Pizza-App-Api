using PizzaApp.Data;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("PizzaAppDb");
builder.Services.AddDbContext<PizzaAppContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRestaurantBranchRepository, RestaurantBranchRepository>();

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
