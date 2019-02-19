using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp11Mvvm.Enums;
using XamarinApp11Mvvm.Models;
using XamarinApp11Mvvm.Repositories;
using XamarinApp11Mvvm.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinApp11Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InicioView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            DicionarioRepository.Dicionario = new List<PalavraModel>();

            #region Fácil

            DicionarioRepository.Dicionario.Add(new PalavraModel("Amor", "Sentimento de afeto que faz com que uma pessoa queira estar com outra, protegendo, cuidando e conservando sua companhia.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Acender", "Queimar; colocar fogo em; fazer arder causando chama: acendeu a vela; o isqueiro acendeu a vela; a churrasqueira não se acende sozinha.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Bravo", "Que afronta o perigo: homem bravo.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Base", "Sustentação; aquilo que se utiliza como suporte: a base da construção.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Ciúme", "Despeito por ver alguém possuir um bem que é alvo do seu desejo; inveja.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Confiança", "Sentimento de quem confia, de quem acredita na sinceridade de algo ou de alguém.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Disposição", "Condição física ou espiritual: tinha boa disposição para o trabalho.", NivelEnum.Facil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Diferença", "Qualidade do que é diferente; dessemelhança.", NivelEnum.Facil));

            #endregion

            #region Médio

            DicionarioRepository.Dicionario.Add(new PalavraModel("Astúcia", "Qualidade de quem age de modo a buscar benefícios e vantagens às custas de outras pessoas; ardil.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Aleatório", "Não estabelecido por regras certas, fixas: escolha feita de maneira aleatória.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Bênção", "Ação de benzer, de abençoar, de invocar a graça divina sobre: o padre fazia a bênção do pão e do vinho; o sacerdote deu sua bênção aos fiéis.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Bizarro", "Característica do que é estranho, grotesco ou incomum.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Compreender", "Capacidade de entender o significado de algo; entendimento.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Cozer", "Cozinhar; preparar os alimentos por meio do fogo: cozinhou massa para o jantar; cozinhou o chocolate numa frigideira; cozinhava com louvor.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Dicionário", "Compilação que contém as palavras de uma língua, apresentando seu significado, utilização, etimologia, sinônimos, antônimos ou com a tradução para outra língua.", NivelEnum.Medio));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Determinação", "Firmeza; persistência para conseguir o que se deseja.", NivelEnum.Medio));

            #endregion

            #region Difícil

            DicionarioRepository.Dicionario.Add(new PalavraModel("Alcateia", "Bando ou conjunto de lobos; Bando de animais ferozes e selvagens.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Ardiloso", "Que se utiliza de ardis, de esperteza, de manha para conseguir o que pretende.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Biombo", "Tabique móvel, formado de caixilhos ligados por dobradiças, que serve para esconder qualquer coisa, ou separar um recanto num aposento, ou que se usa como simples adorno.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Brega", "Que denota falta de gosto; que se apresenta de maneira desapropriada tendo em conta a opinião de quem critica: música brega; vestido brega.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Complexidade", "Característica do que é complexo, de difícil compreensão ou entendimento: a complexidade da teoria.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Constrangimento", "Circunstância vergonhosa; situação de completo embaraço; vexame.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Deboche", "Ação ou efeito de debochar, de zombar, de algo ou de alguém.", NivelEnum.Dificil));
            DicionarioRepository.Dicionario.Add(new PalavraModel("Deslumbrante", "Que causa fascínio; que é encantador; fascinante.", NivelEnum.Dificil));

            #endregion
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
