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

List<Buah> listBuah = new List<Buah>
{
    new Buah
    {
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
    }
};

app.MapGet("/api/Buah", () =>
    {
        return listBuah;
    })
    .WithName("/api/Buah");


app.MapPut("/api/Buah/{id}", (int id, Buah updatedBuah) =>
{
    var buah = listBuah.FirstOrDefault(x => x.Id == id);

    if (buah == null)
        return Results.NotFound("Data tidak ditemukan");

    buah.Name = updatedBuah.Name;

    return Results.Ok(buah);
});


app.Run();