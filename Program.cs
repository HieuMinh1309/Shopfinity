using Microsoft.EntityFrameworkCore;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Areas.Admin.Services;
using SSE_Project.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICrudProduct, ProductRepository>();
builder.Services.AddScoped<ICrudCategory, CategoryRepository>();
builder.Services.AddScoped<ICrudUnit, UnitRepository>();
builder.Services.AddScoped<ICrudBrand, BrandRepository>();
builder.Services.AddScoped<ICrudConversion, ConversionRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Category}/{action=ShowListCategories}"
);


app.Run();
