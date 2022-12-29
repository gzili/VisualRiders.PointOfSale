using Microsoft.EntityFrameworkCore;
using VisualRiders.PointOfSale.Project;
using VisualRiders.PointOfSale.Project.Filters;
using VisualRiders.PointOfSale.Project.Repositories;
using VisualRiders.PointOfSale.Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});
builder.Services.AddDateOnlyTimeOnlyStringConverters();
builder.Services.AddDbContext<PointOfSaleContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});

// Repositories
builder.Services.AddScoped<BusinessEntitiesRepository>();
builder.Services.AddScoped<CategoriesRepository>();
builder.Services.AddScoped<DiscountsRepository>();
builder.Services.AddScoped<DiscountItemsRepository>();
builder.Services.AddScoped<LoyaltiesRepository>();
builder.Services.AddScoped<ClientLoyaltiesRepository>();
builder.Services.AddScoped<ClientsRepository>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<ServicesRepository>();
builder.Services.AddScoped<ShiftsRepository>();
builder.Services.AddScoped<StaffMembersRepository>();
builder.Services.AddScoped<TaxesRepository>();


// Services
builder.Services.AddScoped<BusinessEntitiesService>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<DiscountsService>();
builder.Services.AddScoped<DiscountItemsService>();
builder.Services.AddScoped<LoyaltiesService>();
builder.Services.AddScoped<ClientLoyaltiesService>();
builder.Services.AddScoped<ClientsService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<ServicesService>();
builder.Services.AddScoped<ShiftsService>();
builder.Services.AddScoped<StaffMembersService>();
builder.Services.AddScoped<TaxesService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.UseDateOnlyTimeOnlyStringConverters());

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