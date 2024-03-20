using Microsoft.AspNetCore.Authentication.Cookies;
using MyApplication.Domain.Algorithm;
using MyApplication.Domain.Enums;
using MyApplication.Domain.Interfaces;
using MyApplication.Domain.Services;
using MyApplication.Infrastructure.Databases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/Error");
}
);

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Dependency Injection

// User
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
//Recipes
builder.Services.AddTransient<RecipeServices>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
//Features
builder.Services.AddTransient<FeaturesServices>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteRepository>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
