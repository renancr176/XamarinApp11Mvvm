using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinApp11Mvvm.Annotations;
using XamarinApp11Mvvm.Repositories;
using XamarinApp11Mvvm.Views;

namespace XamarinApp11Mvvm.ViewsModels
{
    public class ResultadoViewModel : INotifyPropertyChanged
    {
        public Command JogarOtraVezCommand { get; private set; }

        public Color _corG1;
        public Color CorG1
        {
            get { return _corG1; }
            private set
            {
                _corG1 = value;
                OnPropertyChanged("CorG1");
            }
        }
        private string _lblGrupo1;
        public string LblGrupo1
        {
            get { return _lblGrupo1; }
            private set
            {
                _lblGrupo1 = value;
                OnPropertyChanged("LblGrupo1");
            }
        }
        private string _lblRsultadoG1;
        public string LblRsultadoG1
        {
            get { return _lblRsultadoG1; }
            private set
            {
                _lblRsultadoG1 = value;
                OnPropertyChanged("LblRsultadoG1");
            }
        }
        private string _lblPontuacaoGrupo1;
        public string LblPontuacaoGrupo1
        {
            get { return _lblPontuacaoGrupo1; }
            private set
            {
                _lblPontuacaoGrupo1 = value;
                OnPropertyChanged("LblPontuacaoGrupo1");
            }
        }
        public Color _corG2;
        public Color CorG2
        {
            get { return _corG2; }
            private set
            {
                _corG2 = value;
                OnPropertyChanged("CorG2");
            }
        }
        private string _lblGrupo2;
        public string LblGrupo2
        {
            get { return _lblGrupo2; }
            private set
            {
                _lblGrupo2 = value;
                OnPropertyChanged("LblGrupo2");
            }
        }
        private string _lblRsultadoG2;
        public string LblRsultadoG2
        {
            get { return _lblRsultadoG2; }
            private set
            {
                _lblRsultadoG2 = value;
                OnPropertyChanged("LblRsultadoG2");
            }
        }
        private string _lblPontuacaoGrupo2;
        public string LblPontuacaoGrupo2
        {
            get { return _lblPontuacaoGrupo2; }
            private set
            {
                _lblPontuacaoGrupo2 = value;
                OnPropertyChanged("LblPontuacaoGrupo2");
            }
        }

        public ResultadoViewModel()
        {
            var jogo = JogoRepository.Jogo;
            LblGrupo1 = jogo.GetGrupo(1).Nome;
            LblPontuacaoGrupo1 = jogo.GetGrupo(1).Pontuacao.ToString();
            LblGrupo2 = jogo.GetGrupo(2).Nome;
            LblPontuacaoGrupo2 = jogo.GetGrupo(2).Pontuacao.ToString();

            if (jogo.GetGrupo(1).Pontuacao == jogo.GetGrupo(2).Pontuacao)
            {
                CorG1 = CorG2 = (Color) App.Current.Resources["Warning"];
                LblRsultadoG1 = LblRsultadoG2 = "Empate";
            }
            else if (jogo.GetGrupo(1).Pontuacao > jogo.GetGrupo(2).Pontuacao)
            {
                CorG1 = (Color) App.Current.Resources["Success"];
                CorG2 = (Color) App.Current.Resources["Danger"];
                LblRsultadoG1 = "Ganhador";
                LblRsultadoG2 = "Perdedor";
            }
            else
            {
                CorG1 = (Color) App.Current.Resources["Danger"];
                CorG2 = (Color) App.Current.Resources["Success"];
                LblRsultadoG1 = "Perdedor";
                LblRsultadoG2 = "Ganhador";
            }

            JogarOtraVezCommand = new Command(JogarOtraVez);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void JogarOtraVez()
        {
            App.Current.MainPage = new InicioView();
        }
    }
}
