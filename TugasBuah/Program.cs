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
        Name = "Erleazar Pandita Ramadhan"
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
};

app.MapGet("/api/Buah", () =>
    {
        return listBuah;
    })
    .WithName("/api/Buah");


app.Run();