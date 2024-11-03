using DevHelper.Data.Interface;
using DevHelper.Data.Interfaces;
using DevHelper.Data.Model;
using DevHelper.Data.Repository;
using DevHelper.Data.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var config = builder.Configuration;

builder.Services.AddDbContext<DBdevhelperContext>(options => options.UseSqlServer(config.GetConnectionString("DBdevhelperConnection")));

builder.Services.AddScoped<iProblemaRepository, ProblemaRepository>();
builder.Services.AddScoped<iProblemaRepositoryAsync, ProblemaRepository>();

builder.Services.AddScoped<iUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<iUsuarioRepositoryAsync, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
