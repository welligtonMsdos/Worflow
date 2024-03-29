﻿using Worflow.Dados.EFCore;
using Worflow.Dados.Interfaces;
using Worflow.Repository;
using Worflow.Services;

namespace WFAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();

        services.AddTransient<IAgendaRepository, AgendaEF>();
        services.AddTransient<IAgendaService, AgendaService>();

        services.AddTransient<IClienteRepository, ClienteEF>();
        services.AddTransient<IClienteService, ClienteService>();

        services.AddTransient<ICotacaoRepository, CotacaoEF>();
        services.AddTransient<ICotacaoService, CotacaoService>();

        services.AddTransient<IEnderecoRepository, EnderecoEF>();
        services.AddTransient<IEnderecoService, EnderecoService>();

        services.AddTransient<ILeadRepository, LeadEF>();
        services.AddTransient<ILeadService, LeadService>();

        services.AddTransient<IPerfilRepository, PerfilEF>();
        services.AddTransient<IPerfilService, PerfilService>();

        services.AddTransient<IUsuarioRepository, UsuarioEF>();
        services.AddTransient<IUsuarioService, UsuarioService>();

        services.AddTransient<IStatusRepository, StatusEF>();
        services.AddTransient<IStatusService, StatusService>();
     
        services.AddTransient<ISeguradoraRepository, SeguradoraEF>();
        services.AddTransient<ISeguradoraService, SeguradoraService>();       

        return services;
    }
}
