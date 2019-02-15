using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp11Mvvm.ViewsModels;

namespace XamarinApp11Mvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioView : ContentPage
    {
        private InicioViewModel _inicrioViewModel;
        public InicioView()
        {
            InitializeComponent();

            _inicrioViewModel = new InicioViewModel();

            BindingContext = _inicrioViewModel;

            Task.Run(() =>
            {
                while (_inicrioViewModel.RunTaks)
                {
                    if (_inicrioViewModel.Notificacoes.Any())
                    {
                        var notificacoes = string.Join("\n", _inicrioViewModel.Notificacoes.Select(notificacao => notificacao+"\n"));
                        _inicrioViewModel.Notificacoes.Clear();
                        DisplayAlert("Notificações", notificacoes, "Ok");
                    }
                }

                Task.Delay(1000);
            });
        }
    }
}