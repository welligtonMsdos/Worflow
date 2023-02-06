using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Worflow.Dados.EFCore;
using Worflow.Dados.Interfaces;
using Worflow.Repository;
using Worflow.Services;

namespace WorflowSystem
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
            services.AddTransient<IClienteDao, ClienteDao>();
            services.AddTransient<IEnderecoDao, EnderecoDao>();
            services.AddTransient<ILeadDao, LeadDao>();
            services.AddTransient<IPerfilDao, PerfilDao>();
            services.AddTransient<IProdutoDao, ProdutoDao>();
            services.AddTransient<ISegmentoDao, SegmentoDao>();
            services.AddTransient<IStatusDao, StatusDao>();
            services.AddTransient<IUsuarioDao, UsuarioDao>();
         
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPerfilService, PerfilService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<ISegmentoService, SegmentoService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IClienteService, ClienteService>();

            services.AddDbContext<AppDbContext>();
            services.AddControllersWithViews()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Lead}/{action=ListarLead}");
            });
        }
    }
}
