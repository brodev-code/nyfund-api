using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NyFund.Common.Mapper.IoC;
using NyFund.Core.Framework.IoC;
using NyFund.Core.Framework.Settings;
using NyFund.Core.Repository.IoC;
using NyFund.Core.Service.IoC;
using NyFund.Data.DataAccessLayer.IoC;
using NyFund.Data.Entity.Database;
using System.Text;

namespace NyFund.Api.Panel
{
    public class Startup
    {
        private readonly string cors = "myCors";

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);
            services.AddSettingsContainer(Configuration);
            services.AddDatabaseContext<NyFundDbContext>("NyFundDbSettings", Configuration);
            services.AddRedis();
            services.AddScopedRepository();
            services.AddScopedService();
            services.AddScopedMapper();
            /*services.AddScopedValidation();
            services.AddScopedJob();
            services.AddScopedEmailSender();
            services.AddScopedNvi();
            services.AddScopedCentralBankCurrency();
            services.AddScopedHttpClientFactoryContainer();
            services.AddScopedMapper();
            services.AddScopedFcmNotification();*/

            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();

            services.AddResponseCaching();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<RecyclableMemoryStreamManager, RecyclableMemoryStreamManager>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(options =>
            {
                //options.Filters.Add<AuthCustomerToken>();
            });

            services.AddCors(opt => opt.AddPolicy(cors, c =>
            {
                c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            services.AddSession();
            services.AddMemoryCache();

            var tokenSettings = AppSettingsHelper.TokenSettings;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(tokenSettings.SecurityKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    NameClaimType = "name"
                };
            });

            services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NyFund Panel API",
                    Description = "Service for Backend",
                    Version = "v1.0",
                    TermsOfService = new System.Uri("http://nyfund.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Software Support",
                        Email = "softwaresupport@nyfund.com"
                    }
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddDistributedMemoryCache();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NyFund Panel API v1"));

            app.UseRouting();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(cors);
            app.UseSession();

            //app.UseCustomerActivityLogMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
