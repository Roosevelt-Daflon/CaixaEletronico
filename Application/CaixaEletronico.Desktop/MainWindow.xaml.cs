using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CaixaEletronico.Domain.Services;

namespace CaixaEletronico.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    
    private readonly CaixaEletronicoService _caixaEletronicoService;
    private Button _SacarButton;
    private TextBox _ValorSaqueTextBox;
    private StackPanel _OpcoesSaqueStackPanel;
    public MainWindow(CaixaEletronicoService caixaEletronicoService)
    {
        _caixaEletronicoService = caixaEletronicoService;
        InitializeComponent();
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        _SacarButton = (FindName("btnSacar") as Button)!;
        _ValorSaqueTextBox = (FindName("txtDinheiro") as TextBox)!;
        _OpcoesSaqueStackPanel = (FindName("SpOpcoesSaque") as StackPanel)!;
        _SacarButton.Click += CalcularSaque;
    }
    
    private void CalcularSaque(object sender, RoutedEventArgs e)
    {
        try
        {
            _OpcoesSaqueStackPanel.Children.Clear();
            
            var valor = decimal.Parse(_ValorSaqueTextBox.Text);
            var opcoesSaque = _caixaEletronicoService.CalcularSaque(valor);
            var sb = new StringBuilder();
            foreach (var opcao in opcoesSaque)
            {
                var stringOpcao = opcao.Aggregate("", (current, item) => current + $"{item.Item1} nota(s) de {item.Item2.valor.Amount} {item.Item2.TipoMoeda} - ").TrimEnd(' ', '-');
                var btn = CreateButton(stringOpcao, (o, args) =>
                {
                    MessageBox.Show(stringOpcao);
                });

                _OpcoesSaqueStackPanel.Children.Add(btn);
            }
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    private Button CreateButton(string content, RoutedEventHandler click)
    {
        var button = new Button
        {
            Content = content,
            Margin = new Thickness(5),
            Padding = new Thickness(10),
            FontSize = 12,
            FontWeight = FontWeights.Bold,
            Background = Brushes.LightGray,
            Foreground = Brushes.Black,
            ToolTip = content
        };
        button.Click += click;
        return button;
    }
}