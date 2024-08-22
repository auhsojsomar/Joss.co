using Joss.co.Common.Extension;
using Joss.co.Common.Settings;
using Joss.co.Data.Entites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Controllers
builder.Services.AddControllers();

// Add Configuration
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddMongoDbConnection()
                .AddMongoDbCollections<Products>("products");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
