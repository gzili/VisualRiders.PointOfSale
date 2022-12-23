using Microsoft.EntityFrameworkCore;
using VisualRiders.PointOfSale.Project;
using VisualRiders.PointOfSale.Project.Repositories;
using VisualRiders.PointOfSale.Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddDbContext<PointOfSaleContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

// Repositories
builder.Services.AddScoped<BusinessEntitiesRepository>();
builder.Services.AddScoped<TaxesRepository>();
builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddScoped<ProductsRepository>();

// Services
builder.Services.AddScoped<BusinessEntitiesService>();
builder.Services.AddScoped<TaxesService>();
builder.Services.AddScoped<ProductsService>();

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