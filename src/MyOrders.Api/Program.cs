using MediatR;
using Microsoft.EntityFrameworkCore;
using MyOrders.Domain.Commands.v1.Orders.Create;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Infra.Data.Context.v1;
using MyOrders.Infra.Data.Queries.Queries.v1.GetAll;
using MyOrders.Infra.Data.Repositories.v1;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddMediatR(typeof(CreateOrdersCommand));
builder.Services.AddMediatR(typeof(GetAllOrdersQuery));
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextClass>(opt => opt.UseSqlServer(cs)); ;
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
