using CustomerCareModule.BAL;
using CustomerCareModule.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("CustomerCareDB")
    ));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerCareService, CustomerCareService>();
builder.Services.AddSession();    //in the controller
builder.Services.AddHttpContextAccessor();  //from non-controller class

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();  // middleware

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
