using BiletyLotnicze;
using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ErrorHandling>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightsContext>();
builder.Services.AddScoped<AirportService>();
builder.Services.AddScoped<FlightService>();
builder.Services.AddScoped<PlaneService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "BiletyLotnicze.local",
        ValidAudience = "BiletyLotnicze.local",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsA32ByteLongSecureKeyForJWTAuth"))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("BiletyLotnicze", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .Build();
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandling>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BiletyLotnicze");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
