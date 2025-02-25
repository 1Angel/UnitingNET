using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Entities;
using UnitingBE.Features.Auth.Register;
using UnitingBE.Features.Comments.CreateComment;
using UnitingBE.Features.Communities.CreateCommunity;
using UnitingBE.Features.posts.CreatePost;
using UnitingBE.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//database
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn"));
});


//identity
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

//current user class
builder.Services.AddScoped<CurrentUser>();

//authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwtSettings:Issuer"],
        ValidAudience = builder.Configuration["jwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtSettings:JwtKey"]))
    };
});

//jwt settings class
builder.Services.AddScoped<JwtService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));

builder.Services.AddAuthorization();

//automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//mediatr
builder.Services.AddMediatR(options=>options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


//fluentvalidation
builder.Services.AddScoped<IValidator<CreateCommunityRequest>, CreateCommunityValidator>();
builder.Services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserValidator>();
builder.Services.AddScoped<IValidator<CreatePostRequest>, CreatePostValidator>();
builder.Services.AddScoped<IValidator<CreateCommentRequest>, CreateCommentValidator>();

//seed admin and roles
SeedRoles.SeedRole(builder.Services.BuildServiceProvider()).Wait();
SeedAdminUser.SeedAmin(builder.Services.BuildServiceProvider()).Wait();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
