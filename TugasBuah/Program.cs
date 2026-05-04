using TugasBuah;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

var listBuah = new List<Buah>
{
    new() { Id = 1, Name = "Erleazar Pandita Ramadhan" },
    new() { Id = 2, Name = "Rizkya Ramdan" },
    new() { Id = 3, Name = "Fityah Bayodiansyah Harahap" },
    new() { Id = 4, Name = "Abiyyu Yusak Ilyasa" },
    new() { Id = 5, Name = "Muhammad Dhaifullah Safarullah" }
};

//GET
app.MapGet("/api/buah", () =>
{
    return Results.Ok(listBuah);
})
.WithName("GetAllBuah")
.Produces<List<Buah>>(StatusCodes.Status200OK);

//GET
app.MapGet("/api/buah/{id}", (int id) =>
{
    var buah = listBuah.FirstOrDefault(x => x.Id == id);

    return buah is null
        ? Results.NotFound("Data tidak ditemukan.")
        : Results.Ok(buah);
})
.WithName("GetBuahById")
.Produces<Buah>(StatusCodes.Status200OK)
.Produces<string>(StatusCodes.Status404NotFound);

//POST
app.MapPost("/api/buah", (Buah buah) =>
{
    if (string.IsNullOrWhiteSpace(buah.Name))
    {
        return Results.BadRequest("Parameter 'name' wajib diisi.");
    }

    var newId = listBuah.Count == 0 ? 1 : listBuah.Max(x => x.Id) + 1;
    buah.Id = newId;
    listBuah.Add(buah);

    return Results.Created($"/api/buah/{buah.Id}", buah);
})
.Accepts<Buah>("application/json")
.WithName("CreateBuah")
.Produces<Buah>(StatusCodes.Status201Created)
.Produces<string>(StatusCodes.Status400BadRequest);

//PUT
app.MapPut("/api/buah/{id}", (int id, Buah updatedBuah) =>
{
    if (string.IsNullOrWhiteSpace(updatedBuah.Name))
    {
        return Results.BadRequest("Parameter 'name' wajib diisi.");
    }

    var buah = listBuah.FirstOrDefault(x => x.Id == id);

    if (buah is null)
    {
        return Results.NotFound("Data tidak ditemukan.");
    }

    buah.Name = updatedBuah.Name;

    return Results.Ok(buah);
})
.Accepts<Buah>("application/json")
.WithName("UpdateBuah")
.Produces<Buah>(StatusCodes.Status200OK)
.Produces<string>(StatusCodes.Status400BadRequest)
.Produces<string>(StatusCodes.Status404NotFound);

//DELETE
app.MapDelete("/api/buah/{id}", (int id) =>
{
    var buah = listBuah.FirstOrDefault(x => x.Id == id);

    if (buah is null)
    {
        return Results.NotFound("Data tidak ditemukan.");
    }

    listBuah.Remove(buah);

    return Results.Ok(new { message = $"Data {buah.Name} berhasil dihapus." });
})
.WithName("DeleteBuah")
.Produces(StatusCodes.Status200OK)
.Produces<string>(StatusCodes.Status404NotFound);

app.Run();
