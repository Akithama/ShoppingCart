
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ShoppingCart.Bll
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            //services.AddControllers();

            //// configure strongly typed settings objects
            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            // configure DI for application services
            //services.AddScoped<IUserService, UserService>();


            //services.AddDbContext<ShoppingCartContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("CartDatabase")));            
        }
    }
}
