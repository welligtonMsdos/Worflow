using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Worflow.Core.StatusState;
using Worflow.Dados.Dapper;
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
            services.AddTransient<IClienteRepository, ClienteEF>();
            services.AddTransient<IEnderecoRepository, EnderecoEF>();
            services.AddTransient<ILeadRepository, LeadEF>();
            services.AddTransient<IPerfilRepository, PerfilEF>();
            services.AddTransient<IProdutoRepository, ProdutoEF>();
            services.AddTransient<ISegmentoRepository, SegmentoEF>();
            services.AddTransient<IStatusRepository, StatusEF>();
            services.AddTransient<IUsuarioRepository, UsuarioEF>();
            services.AddTransient<IAgendaRepository, AgendaEF>();
            services.AddTransient<ICotacaoRepository, CotacaoEF>();
            services.AddTransient<ISeguradoraRepository, SeguradoraEF>();                      
            //services.AddTransient<ILeadDao, LeadDapper>();
            //services.AddTransient<IUsuarioDao, UsuarioDapper>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPerfilService, PerfilService>();
            services.AddTransient<IEnderecoService, EnderecoService>();
            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<ISegmentoService, SegmentoService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IAgendaService, AgendaService>();
            services.AddTransient<ICotacaoService, CotacaoService>();
            services.AddTransient<ISeguradoraService, SeguradoraService>();

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
