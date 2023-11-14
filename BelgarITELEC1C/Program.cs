using BelgarITELEC1C.Data;
using BelgarITELEC1C.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IMyFakeDataService, MyFakeDataService>(); // this is dummy data service

//Db Context
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//Ensure database is created
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




