using Management.Repository.Models;
using Management.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TokenAuth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IdentitiyService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
    sqloptions => { sqloptions.MigrationsAssembly("Management.Repository"); });

});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddAuthentication(options =>
{
    //add scheme information this is default scheme
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    var signatureKey = builder.Configuration.GetSection("TokenOptions")["SignatureKey"]!;

    options.TokenValidationParameters = new TokenValidationParameters
    {
       
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidateAudience = false,
        ValidateIssuer=false,

        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey))
   
    };


}) ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //for control token
app.UseAuthorization(); //tokens permission

app.MapControllers();

app.Run();
