using Algo.Services.OrderServices.Interfaces;
using Algo.Services.OrderServices;
using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.DataAccess.DAO;
using Algo.Services.StockServices.Interfaces;
using Algo.Services.StockServices;
using AlgoShop.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);
string CONNECTION_STRING_NAME = "SqlConnection";
// Add services to the container.

var dbConnectionString = builder.Configuration.GetConnectionString(CONNECTION_STRING_NAME).ToString();
builder.Services.AddDbContext<AlgoShopContext>(options => options.UseSqlServer(dbConnectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Comment out the SqlData client
//AlgoShop.DataAccess.SqlDataAccess.SetConnectionString(builder.Configuration.GetConnectionString(CONNECTION_STRING_NAME).ToString());



builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IStockService, StockService>();

//Add the Data access layer
builder.Services.AddScoped<IOrderDAO, OrderDAO>();
builder.Services.AddScoped<IStockDAO, StockDAO>();

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
