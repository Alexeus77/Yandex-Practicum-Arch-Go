var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Health Checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map Health Checks endpoint
app.MapHealthChecks("/health");

app.MapGet("/temperature/{id:int}", (int id) =>
{
    var response = new TemperatureResponse
    {
        Value = Random.Shared.NextDouble() * 100 - 50,
        Timestamp = DateTime.UtcNow,
        Location = $"{id}",
        Status = "Active",
        SensorID = $"{id}",
        SensorType = "Термодатчик",
    };
    return response;
})
.WithDescription("Получение рандомной температуры в диапазоне +-50C").WithOpenApi();

await app.RunAsync();
