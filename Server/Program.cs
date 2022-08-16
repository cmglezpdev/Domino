using Server.Data;
using Server.Data.Classes;
using Server.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IManager, Manager>();

string MyCors = "MyCors";
builder.Services.AddCors(options => {
    options.AddPolicy(
        name: MyCors,
        build => {
            build.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyHeader().AllowAnyMethod();
        }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
