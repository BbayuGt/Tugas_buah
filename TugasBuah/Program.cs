using TugasBuah;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/api/Buah", (Buah buah) =>
{
    if (string.IsNullOrWhiteSpace(buah.Name))
    {
        return Results.BadRequest("Parameter 'name' wajib ada.");
    }

    return Results.Ok(buah);
})
.Accepts<Buah>("application/json")
.Produces<Buah>(StatusCodes.Status200OK)
.Produces<string>(StatusCodes.Status400BadRequest)
.WithName("PostBuah");

app.Run();
