using Dagbok_JoelMarkgren.ViewModels;

namespace Dagbok_JoelMarkgren
{
    public partial class MainPage : ContentPage
    {
		private readonly MainViewModel vm;

		public MainPage(MainViewModel vm)
        {
			InitializeComponent();
			BindingContext = vm;
			this.vm = vm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//vm.Refresh();
		}
	}

}
