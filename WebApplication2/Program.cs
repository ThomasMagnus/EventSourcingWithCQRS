using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.IServices;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddScoped<IEventReplayService, EventReplayService>();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddDbContext<ApplicationReadContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionRead"));
});

builder.Services.AddDbContext<AuditLogContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionLogs"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=Index}");

app.UseAuthorization();

app.Run();
