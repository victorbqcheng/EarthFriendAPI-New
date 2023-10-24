using EarthFriendAPI;
using EarthFriendAPI.Models;
using EarthFriendAPI.Services;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BC = BCrypt.Net.BCrypt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<EarthFriendDatabaseSettings>(builder.Configuration.GetSection("EarthFriendDatabase"));
builder.Services.AddSingleton<MongodbService>();
builder.Services.AddSingleton<PostsService>();
builder.Services.AddSingleton<NewsService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapPost("/api/login", onLogin);

app.Run();


static IResult onLogin(string username, string password) 
{
    const string un = "test";
    const string pwHash = "$2a$11$UoY/X9vGZQoJEHVaAF0ZXOQ6OEnnDbUq254Ftqkg.GMo9toBcA97S";
    if (username == un && BC.Verify(password, pwHash))
    {
        var claims = new[] {
             new Claim("name",username)
            };
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConfig.secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var jwttoken = new JwtSecurityToken(null, null, claims, DateTime.Now, null, credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(jwttoken);
        LoginResult result = new LoginResult
        {
            name = username,
            token = token
        };
        //return JsonSerializer.Serialize(result);
        return TypedResults.Ok(result);
    }

    return TypedResults.Unauthorized();
}