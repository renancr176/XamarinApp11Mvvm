using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp11Mvvm.ViewsModels;

namespace XamarinApp11Mvvm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JogoView : ContentPage
    {
        private JogoViewModel _jogoViewModel;

		public JogoView ()
		{
			InitializeComponent ();

            _jogoViewModel = new JogoViewModel();

            BindingContext = _jogoViewModel;
        }
	}
}