using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinApp11Mvvm.Annotations;
using XamarinApp11Mvvm.Enums;
using XamarinApp11Mvvm.Models;
using XamarinApp11Mvvm.Repositories;
using XamarinApp11Mvvm.Views;

namespace XamarinApp11Mvvm.ViewsModels
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public bool RunTaks { get; private set; }
        public List<NivelEnum> NivelEnums { get; private set; }
        public JogoModel Jogo { get; set; }
        public Command IniciarCommand { get; set; }
        public List<string> Notificacoes { get; set; }

        public InicioViewModel()
        {
            RunTaks = true;
            NivelEnums = NivelEnum.GetAll<NivelEnum>().ToList();
            Jogo = new JogoModel();
            IniciarCommand = new Command(IniciarJogo);
            Notificacoes = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IniciarJogo()
        {
            if (JogoIsValid())
            {
                RunTaks = false;
                JogoRepository.Jogo = Jogo;
                App.Current.MainPage = new JogoView();
            }
        }

        private bool JogoIsValid()
        {
            if (Jogo.Grupos.Any(g => g.Nome == null || g.Nome == ""))
            {
                Notificacoes.Add("O nome do grupo deve ser informado.");
            }

            if (Jogo.Nivel == null)
            {
                Notificacoes.Add("O nível deve ser informado.");
            }

            if (Jogo.Rodadas <= 0)
            {
                Notificacoes.Add("O número de rodadas deve ser maior que zero.");
            }

            if (Jogo.Rodadas % 2 != 0)
            {
                Notificacoes.Add("O número de rodadas deve ser par.");
            }

            if (Jogo.TempoPalavra <= 30)
            {
                Notificacoes.Add("O tempo de resposta deve ser de no minimo 30 segundos.");
            }

            return !Notificacoes.Any();
        }
    }
}
