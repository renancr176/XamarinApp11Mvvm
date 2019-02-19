using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;
using XamarinApp11Mvvm.Annotations;
using XamarinApp11Mvvm.Enums;
using XamarinApp11Mvvm.Models;
using XamarinApp11Mvvm.Repositories;
using XamarinApp11Mvvm.Views;

namespace XamarinApp11Mvvm.ViewsModels
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        private CancellationTokenSource _countdownThreadSourceToken;
        private CancellationToken _countdownThreadToken;
        private ISimpleAudioPlayer _successPlayer;
        private ISimpleAudioPlayer _timeoutPlayer;
        private int _rodadaAtual = 0;
        private List<PalavraModel> _palavrasUtilizadas;

        public JogoModel Jogo { get; private set; }
        public Command MostrarCommand { get; private set; }
        public Command IniciarCommand { get; private set; }
        public Command AcertouCommand { get; private set; }
        public Command ErrouCommand { get; private set; }

        public NivelEnum NivelDificuldade { get; private set; }
        private bool _conteudoExibido;
        public bool ConteudoExibido
        {
            get { return _conteudoExibido; }
            private set
            {
                _conteudoExibido = value;
                OnPropertyChanged("ConteudoExibido");
                OnPropertyChanged("Palavra"); 
            }
        }
        private bool _btnMotrarExibido;
        public bool BtnMostrarExibido
        {
            get { return _btnMotrarExibido;}
            private set
            {
                _btnMotrarExibido = value;
                OnPropertyChanged("BtnMostrarExibido");
                OnPropertyChanged("LblSignificadoExibido"); 
            }
        }
        public bool LblSignificadoExibido
        {
            get
            {
                return !_btnMotrarExibido;
            }
        }
        private bool _conteudoJogoValendo;
        public bool ConteudoJogoValendo
        {
            get { return _conteudoJogoValendo; }
            private set
            {
                _conteudoJogoValendo = value;
                OnPropertyChanged("ConteudoJogoValendo"); 
            }
        }
        public int NumeroGrupo { get; set; }
        private string _nomeGrupo;
        public string NomeGrupo
        {
            get { return _nomeGrupo; }
            set
            {
                _nomeGrupo = value;
                OnPropertyChanged("NomeGrupo");
            }
        }
        private short _tempoPalavra;
        public short TempoPalavra
        {
            get { return _tempoPalavra; }
            private set
            {
                _tempoPalavra = value;
                OnPropertyChanged("TempoPalavra");
            }
        }
        private PalavraModel _palavra;
        public PalavraModel Palavra
        {
            get
            {
                if (!_conteudoExibido && !_conteudoJogoValendo)
                {
                    return new PalavraModel(_palavra.Id, new String('*', _palavra.Palavra.Length), "", NivelDificuldade);
                }
                return _palavra;
            }
            private set
            {
                _palavra = value;
                OnPropertyChanged("Palavra");
            }
        }

        public JogoViewModel()
        {
            _palavrasUtilizadas = new List<PalavraModel>();
            BtnMostrarExibido = true;
            ConteudoExibido = false;
            ConteudoJogoValendo = false;
            Jogo = JogoRepository.Jogo;
            SetNivelDificuldade();
            MostrarCommand = new Command(Mostrar);
            IniciarCommand = new Command(Iniciar);
            AcertouCommand = new Command(Acertou);
            ErrouCommand = new Command(Errou);

            
            _successPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            _successPlayer.Volume = 100;
            _successPlayer.Load(GetStreamFromFile("success.mp3"));

            _timeoutPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            _timeoutPlayer.Volume = 100;
            _timeoutPlayer.Load(GetStreamFromFile("timeout.mp3"));

            TrocaGrupo();
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("XamarinApp11Mvvm.Assets." + filename);

            return stream;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Mostrar()
        {
            BtnMostrarExibido = false;
            ConteudoExibido = true;
        }

        private void Iniciar()
        {
            ConteudoExibido = false;
            ConteudoJogoValendo = true;
            StartCountdown();
        }

        private void Acertou()
        {
            _countdownThreadSourceToken.Cancel();
            Jogo.Grupos.FirstOrDefault(g => g.Id == NumeroGrupo).Pontuacao += NivelDificuldade.Pontos;
            Task.Run(() =>
            {
                _successPlayer.Play();
                Task.Delay(5000).Wait();
                TrocaGrupo();
            });
        }

        private void Errou()
        {
            _countdownThreadSourceToken.Cancel();
            _timeoutPlayer.Play();
            Task.Run(() =>
            {
                _timeoutPlayer.Play();
                Task.Delay(4000).Wait();
                TrocaGrupo();
            });
        }

        private void StartCountdown()
        {
            _countdownThreadSourceToken = new CancellationTokenSource();
            _countdownThreadToken = _countdownThreadSourceToken.Token;
            Task.Factory.StartNew(() =>
            {
                while (TempoPalavra > 0 && !_countdownThreadToken.IsCancellationRequested)
                {
                    Task.Delay(1000).Wait();
                    TempoPalavra--;
                }

                if (TempoPalavra == 0)
                {
                    _timeoutPlayer.Play();
                    Task.Delay(4000).Wait();
                    TrocaGrupo();
                }
            }, _countdownThreadToken);
        }

        private void TrocaGrupo()
        {
            BtnMostrarExibido = true;
            ConteudoJogoValendo = false;

            if (NumeroGrupo == 0 || NumeroGrupo == 2)
            {
                _rodadaAtual++;
            }

            if (_rodadaAtual > Jogo.Rodadas)
            {
                if (!_countdownThreadSourceToken.IsCancellationRequested) { 
                    _countdownThreadSourceToken.Cancel();
                }
                JogoRepository.Jogo = Jogo;
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.Current.MainPage = new ResultadoView();
                });
            }

            if (NumeroGrupo != 0 && NumeroGrupo == 2)
            {
                SetNivelDificuldade();
            }

            NumeroGrupo = ((NumeroGrupo == 0 || NumeroGrupo == 2) ? 1 : 2);
            NomeGrupo = $"Grupo: {Jogo.GetGrupo(NumeroGrupo).Nome}";
            TempoPalavra = Jogo.TempoPalavra;
            Random rnd = new Random();
            var palavrasNaoUtilizadas = DicionarioRepository.Dicionario
                .Where(dp =>
                    dp.NivelDificuldade == NivelDificuldade 
                &&  !_palavrasUtilizadas.Exists(pu => pu.Id == dp.Id)
                )
                .ToList();

            var indiceAleatorio = rnd.Next(palavrasNaoUtilizadas.Count);
            var palavra = palavrasNaoUtilizadas[indiceAleatorio];

            Palavra = palavra;
            _palavrasUtilizadas.Add(palavra);
        }

        private void SetNivelDificuldade()
        {
            NivelDificuldade = Jogo.Nivel;

            if (Jogo.Nivel == NivelEnum.Aleatorio)
            {
                Random rnd = new Random();
                var niveis = NivelEnum.GetAll<NivelEnum>().Where(n => n.Id > 1).ToList();
                var randIndexNivel = rnd.Next(niveis.Count);
                NivelDificuldade = niveis[randIndexNivel];
            }
        }
    }

    public class PontuacaoPalavraConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Palavra - Pontuação {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
