using System.Configuration;
using System.Data;
using System.Windows;
using CaixaEletronico.Domain.Repositories;
using CaixaEletronico.Domain.Services;
using CaixaEletronico.Infra.Context;
using CaixaEletronico.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CaixaEletronico.Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public readonly IHost _Host;
    public App()
    {
        _Host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<CaixaEletronicoContext>(options =>
                    options.UseSqlite("Data Source= CaixaEletronico.db"));

                services.AddScoped<IValorMonetarioRepository, ValorMonetarioRepository>();
                services.AddScoped<CaixaEletronicoService>();
                
                services.AddScoped<MainWindow>();
            })
            .Build();
    }


    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        var mainWindow = _Host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
    
    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        
        _Host.Dispose();
    }
}