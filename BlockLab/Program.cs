


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<IdentityContext>(options => options
        .UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection")));
    services.AddDbContext<BlockLabContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BlockLabConnection")));
    services.AddIdentity<User, Role>().AddEntityFrameworkStores<IdentityContext>();
    services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

    services.AddScoped<IResearchInfoService, ResearchInfoService>();
    services.AddScoped<IResearchInfoPagiService, ResearchInfoPagiService>();

    services.AddControllersWithViews().AddRazorRuntimeCompilation();
    services.AddRazorPages().AddRazorRuntimeCompilation();
});
builder.Services.AddServerSideBlazor();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
});

var app = builder.Build();

await IdentitySeedTestData.SeedTestData(app.Services, builder.Configuration);
await BlockLabSeedTestData.SeedTestData(app.Services, builder.Configuration);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithRedirects("~/home/error/{0}");

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("online/{param?}", "/Shared/_Host");

app.Run();
