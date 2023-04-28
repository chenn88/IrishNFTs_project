using Microsoft.EntityFrameworkCore;
using OrdersAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add ing services to the container.

builder.Services.AddControllers();

//Adding db context

builder.Services.AddDbContext<OrderDbContext>(opt =>

{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OrderDbConnection"));
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OrderDbContext>();

    // Wait for database to be available and apply pending migrations
    await WaitForDatabaseToBeAvailableAsync(context);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


//method to await database TCP connection Availability

async Task WaitForDatabaseToBeAvailableAsync(OrderDbContext context)
{
    int retries = 6;
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
            Console.WriteLine($"Failed to apply migrations. Attempt {i + 1} of {retries}. Retrying in {delayBetweenRetries.TotalSeconds} seconds... Error: {ex.Message}");
            if (i == retries - 1)
            {
                Console.WriteLine($"Failed to apply migrations after {retries} attempts. Aborting...");
                throw;
            }

            await Task.Delay(delayBetweenRetries);
        }
    }
}