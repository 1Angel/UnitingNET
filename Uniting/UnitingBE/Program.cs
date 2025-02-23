using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnitingBE.Database;
using UnitingBE.Entities;
using UnitingBE.Features.Auth.Register;
using UnitingBE.Features.Communities.CreateCommunity;
using UnitingBE.Features.posts.CreatePost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//database
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn"));
});


//identity
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

//automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//mediatr
builder.Services.AddMediatR(options=>options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


//fluentvalidation
builder.Services.AddScoped<IValidator<CreateCommunityRequest>, CreateCommunityValidator>();
builder.Services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserValidator>();
builder.Services.AddScoped <IValidator<CreatePostRequest>, CreatePostValidator>();


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

app.Run();
