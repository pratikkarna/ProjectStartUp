using BLL;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ProjectStartUp.Connection.ConnectionString>();
// ===== Register your custom services for DI =====



// DAO
builder.Services.AddTransient<DAL.TestDAO>();
builder.Services.AddTransient<AccountSubGroupDAO>();
// BLL
builder.Services.AddTransient<BLL.TestBLL>();
builder.Services.AddTransient<AccountSubGroupBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
