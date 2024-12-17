using CommunityToolkit.Mvvm.ComponentModel;


namespace Dagbok_JoelMarkgren.ViewModels
{
		public partial class BaseViewModel : ObservableObject
		{
			[ObservableProperty]
			private string? title;
		}
	
}
