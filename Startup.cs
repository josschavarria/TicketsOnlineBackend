using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicketsOnlineBackend.Context;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            { Title = "Api TicketsOnline", Version = "v1" });
        });

        services.AddControllers();

        services.AddControllersWithViews();

        services.Configure<TokenSettingsDTO>(Configuration.GetSection("ApplicationSettings"));

        services.AddCors();
        services.AddDbContext<MyContext>(
        options => options.UseSqlServer(Configuration.GetConnectionString("MyContextConnection")));
        services.AddDbContext<AutenticacionContext>(
           options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
        services.AddDefaultIdentity<UsuarioAutenticacion>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AutenticacionContext>();


        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
        });

        /*services
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddControllers();


        //Repository
        services.AddTransient<IRepository<CategoryModel>, Repository<CategoryModel>>();
        */

        services.AddScoped<CapacidadServices>();
        services.AddControllers();

        services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        //AutoMapper
        services.AddAutoMapper(typeof(WebApplicationBuilder));

       

        //JWT Auth
        //var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

        //services.AddAuthentication(x =>
        //{
        //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(x => {
        //    x.RequireHttpsMetadata = false;
        //    x.SaveToken = false;
        //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuer = false,
        //        ValidateAudience = false,
        //        ClockSkew = System.TimeSpan.Zero
        //    };
        //});
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });


        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api TicketsOnline");
        });

        app.UseSwagger();

      

    }
}