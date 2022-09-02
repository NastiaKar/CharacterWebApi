using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG_API.BLL.Profiles;
using RPG_API.BLL.Services;
using RPG_API.BLL.Services.Interfaces;
using RPG_API.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(config =>
{
    config.AddProfiles(new Profile[] { new SkillProfile(), new WeaponProfile()});
});
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();
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