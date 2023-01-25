using Microsoft.EntityFrameworkCore;
using ProyectoDatosEF.Data;
using ProyectoDatosEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration.GetConnectionString("hospitallocal");
//RESOLVEMOS LA DEPENDENCIA DE REPOSITORY
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddTransient<RepositoryDoctor>();
builder.Services.AddTransient<RepositoryPlantilla>();
builder.Services.AddTransient<RepositoryEmpleados>();
//LAS CLASES CONTEXT DE ACCESO A DATOS UTILIZAN
//UN METODO ESPECIAL LLAMADO AddDbContext
builder.Services.AddDbContext<HospitalContext>
    (options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Empleados}/{action=Index}/{id?}");

app.Run();
