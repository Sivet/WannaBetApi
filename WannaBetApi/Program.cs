using Microsoft.EntityFrameworkCore;
using WannaBetApi.Data;
using WannaBetApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WannaBetApiContext>(opt => opt.UseSqlServer
    (builder.Configuration.GetConnectionString("WannaBetConnection")));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<ICharacterRepo, /*SqlCharacterRepo*/ MockCharacterRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Put development only stuff here
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
