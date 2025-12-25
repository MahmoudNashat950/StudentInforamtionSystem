using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.UniversityModels;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// 1. Register ApplicationDbContext (Identity)
// --------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// --------------------
// 2. Register UniversityContext (DB First)
// --------------------
builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityContext")));

// --------------------
// 3. Add Razor Pages and Controllers
// --------------------
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// --------------------
// 4. Email sender (optional)
// --------------------
//builder.Services.AddSingleton<IEmailSender, FakeEmailSender>();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/"; // redirect to home
});



// --------------------
// 5. Logging
// --------------------
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

// Seed roles and example assignment
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesAsync(services);
}

async Task SeedRolesAsync(IServiceProvider services)
{
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetService<UserManager<ApplicationUser>>();

    // Add roles you need here
    var roles = new[] { "Instructor" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(role));
            if (!result.Succeeded)
            {
                // Optionally log result.Errors
            }
        }
    }

    // Optional: assign an existing user to the Instructor role by email.
    // Replace the email with a real user that exists in your database.
    if (userManager is not null)
    {
        var instructorEmail = "instructor@example.com";
        var user = await userManager.FindByEmailAsync(instructorEmail);
        if (user is not null && !await userManager.IsInRoleAsync(user, "Instructor"))
        {
            await userManager.AddToRoleAsync(user, "Instructor");
        }
    }
}

// --------------------
// 6. Middleware configuration
// --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
