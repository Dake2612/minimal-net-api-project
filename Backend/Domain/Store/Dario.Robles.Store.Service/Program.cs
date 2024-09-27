using Dario.Robles.Store.Service.Application.Extensions;
using Dario.Robles.Store.Service.Infraestructure.Extensions;
using Dario.Robles.Store.Service.Infraestructure.http.Extensions;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("StoreConnectionString");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(opt => opt.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterEndpoints();
app.UseSeedData();
app.UseAllowAllCORS();
app.Run();

