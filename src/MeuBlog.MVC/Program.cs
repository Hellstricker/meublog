using MeuBlog.Mvc.Configurations;
using MeuBlog.Shared.CommonConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddSharedsConfiguration()
    .AddContextConfiguration()
    .AddIdentityConfiguration();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
