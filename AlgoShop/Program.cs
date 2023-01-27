using Algo.Services.Interfaces;
using Algo.Services;
using AlgoShop.DataAccess.DAO.Interface;
using AlgoShop.DataAccess.DAO;

var builder = WebApplication.CreateBuilder(args);
string CONNECTION_STRING_NAME = "SqlConnection";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.ConfigureServices(
//    services =>
//        services.AddHostedService<Worker>()
//            .AddScoped<IMessageWriter, MessageWriter>());


AlgoShop.DataAccess.SqlDataAccess.SetConnectionString(builder.Configuration.GetConnectionString(CONNECTION_STRING_NAME).ToString());


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

//Add the service layer


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
