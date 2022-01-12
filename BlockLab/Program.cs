
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.AddDbContext<BlockLabContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BlockLabConnection")));

    services.AddScoped<IResearchInfoService, ResearchInfoService>();
    services.AddScoped<IResearchInfoPagiService, ResearchInfoPagiService>();

    services.AddControllersWithViews().AddRazorRuntimeCompilation();
    services.AddRazorPages().AddRazorRuntimeCompilation();
});
builder.Services.AddServerSideBlazor();

var app = builder.Build();

BlockLabSeedTestData.SeedTestData(app.Services, builder.Configuration);

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

app.UseStatusCodePagesWithRedirects("~/home/error/{0}");

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("online/{param?}", "/Shared/_Host");

app.Run();
