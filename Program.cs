using Microsoft.EntityFrameworkCore;
using crudpractice.Data;
using crudpractice.Model;

var builder = WebApplication.CreateBuilder(args);
//ADDCONTEXT

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//add mvc 
builder.Services.AddControllersWithViews();

var app = builder.Build();

//MIDDLEWARE USED HO RHA HAI USED //
// THESE ARE MIDDLEWARE PIPIEINE.. THAT ARE USED....//

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();

//default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}"
);

app.Run();
