using Blazored.SessionStorage;
using HangKenhFE.Data;
using HangKenhFE.IServices;
using HangKenhFE.Models;
using HangKenhFE.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ViewsFE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<APP_DATA_DATN>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();
builder.Services.AddSingleton<WeatherForecastService>();
// Thêm CORS nếu cần
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => 
        {
            policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // thời gian timeout của session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add DbContext
builder.Services.AddDbContext<APP_DATA_DATN>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient<IAddressServices, AddressService>();
builder.Services.AddScoped<IAddressServices, AddressService>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartDetailsService, CartDetailsService>();
//builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostTagService, PostTagService>();
builder.Services.AddScoped<ITagsServices, TagsServices>();
//builder.Services.AddScoped<IPostMetaService, PostMetaService>();
builder.Services.AddScoped<IDiscountServices, DiscountServices>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IUserVoucherService, UserVoucherService>();
builder.Services.AddScoped<FilesIServices, FilesServices>();
builder.Services.AddScoped<IDesignerServices, DesignerServices>();
builder.Services.AddScoped<IOptionsServices, OptionServices>();
builder.Services.AddScoped<IPostSer, PostServices>();
builder.Services.AddScoped<IColorServices, ColorServices>();
builder.Services.AddScoped<ISizeServices, SizeServices>();
builder.Services.AddScoped<IMaterialServices, MaterialServices>();
builder.Services.AddScoped<IStyleServices, StyleServices>();
builder.Services.AddScoped<ITextile_technologyServices, Textile_technologyServices>();
builder.Services.AddScoped<ILoginService, LoginServices>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<IProductAttributeServies, ProductAttributeServices>();
builder.Services.AddScoped<IProductVariantServices, ProductVariantServices>();
builder.Services.AddScoped<OrderDetailsIServices, OrderDetailsServices>();
builder.Services.AddScoped<IOrderIServices, OrderServices>();
builder.Services.AddScoped<IOrderTrackingServices, OrderTrackingService>();
builder.Services.AddScoped<IBannerServices, BannerServices>();
builder.Services.AddScoped<IDiscountServices, DiscountServices>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor(options => options.DetailedErrors = true);
builder.Services.AddScoped<IContacServices, ContacServices>();
builder.Services.AddScoped<IQaService, QaService>();


builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IWishlistServices, WishlistServices>();
builder.Services.AddScoped<IProduct_variants_wishlist_Services, Product_variants_wishlist_Services>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var httpClient = scope.ServiceProvider.GetRequiredService<HttpClient>();
    var response = await httpClient.GetAsync("https://localhost:7011/api/Accsess/GetAll");
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAllOrigins");  // Enable the CORS policy here

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

