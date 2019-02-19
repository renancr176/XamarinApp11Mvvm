using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp11Mvvm.ViewsModels;

namespace XamarinApp11Mvvm.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultadoView : ContentPage
	{
		public ResultadoView ()
		{
			InitializeComponent ();

            BindingContext = new ResultadoViewModel();
        }
	}
}