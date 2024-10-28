//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//namespace Advertisement
//{
//    public class Startup
//    {
//        public IConfiguration Configuration { get; }

//        public Startup(IConfiguration configuration) => Configuration = configuration;

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();

//            // Configure JWT Authentication
//            var jwtSettings = Configuration.GetSection("JwtSettings");
//            var secretKey = jwtSettings["SecretKey"];
//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                    .AddJwtBearer(options =>
//                    {
//                        options.TokenValidationParameters = new TokenValidationParameters
//                        {
//                            ValidateIssuer = true,
//                            ValidateAudience = true,
//                            ValidateLifetime = true,
//                            ValidateIssuerSigningKey = true,
//                            ValidIssuer = jwtSettings["Issuer"],
//                            ValidAudience = jwtSettings["Audience"],
//                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
//                        };
//                    });

//            services.AddAuthorization();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseRouting();
//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints => endpoints.MapControllers());
//        }
//    }

//}
