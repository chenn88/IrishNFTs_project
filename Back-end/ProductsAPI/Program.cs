using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using ProductsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductDbContext>(opt =>

{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductDbConnection"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProductDbContext>();

    // Wait for database to be available and apply pending migrations
    await WaitForDatabaseToBeAvailableAsync(context);

    if (!context.Products.Any())
    {
        ProductDbSeeder.Seed(context);
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task WaitForDatabaseToBeAvailableAsync(ProductDbContext context)
{
    int retries = 5;
    var delayBetweenRetries = TimeSpan.FromSeconds(5);

    for (int i = 0; i < retries; i++)
    {
        try
        {
            // Apply pending migrations
            context.Database.Migrate();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to apply migrations. Attempt {i + 1} of {retries}. Retrying in {delayBetweenRetries.TotalSeconds} seconds...");
            if (i == retries - 1)
            {
                Console.WriteLine($"Failed to apply migrations after {retries} attempts. Aborting...");
                throw;
            }

            await Task.Delay(delayBetweenRetries);
        }
    }
}