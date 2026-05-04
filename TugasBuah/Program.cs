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

        Id = 1, Name = "Erleazar Pandita Ramadhan"
    },
    new Buah
    {
        Id = 2, Name = "Rizkya Ramdan"
    },
    new Buah
    {
        Id = 3, Name = "Fityah Bayodiansyah Harahap"
    },
    new Buah
    {
        Id = 4, Name = "Abiyyu Yusak Ilyasa"
    },
    new Buah
    {
        Id = 5, Name = "Muhammad Dhaifullah Safarullah"

       
    },
    new Buah
    {
        Name = "Rizkya Ramdan"
    },
    new Buah
    {
        Name = "Fityah Bayodiansyah Harahap"
    },
    new Buah
    {
        Name = "Abiyyu Yusak Ilyasa"
    },
    new Buah
    {
        Name = "Muhammad Dhaifullah Safarullah"

    }

    return Results.Ok(buah);
})
.Accepts<Buah>("application/json")
.Produces<Buah>(StatusCodes.Status200OK)
.Produces<string>(StatusCodes.Status400BadRequest)
.WithName("PostBuah");

app.Run();

app.MapPut("/api/Buah/{id}", (int id, Buah updatedBuah) =>
{
    var buah = listBuah.FirstOrDefault(x => x.Id == id);

    if (buah == null)
        return Results.NotFound("Data tidak ditemukan");

    buah.Name = updatedBuah.Name;

    return Results.Ok(buah);
});



app.Run();
