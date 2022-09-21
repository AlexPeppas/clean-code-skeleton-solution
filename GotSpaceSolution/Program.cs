using GotSpace.Infrastructure;
using GotSpaceSolution.Common;
using GotSpaceSolution.Core;
using GotSpaceSolution.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepositoryProvider, RepositoryProvider>();
builder.Services.AddSingleton<IBookingService, BookingService>();
builder.Services.AddSingleton<IRideService, RideService>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
