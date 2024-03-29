using PowerOfHabit.Infra.IoC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//using IgnoreCycles to avoid cycles in JSON properties
builder.Services.AddControllers().AddJsonOptions(options =>
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//extension method created in Infra.IoC
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddInfrastructureJWT(builder.Configuration);

builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
