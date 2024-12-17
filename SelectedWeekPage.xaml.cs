using Dagbok_JoelMarkgren.Services;
using Dagbok_JoelMarkgren.ViewModels;

namespace Dagbok_JoelMarkgren;

public partial class SelectedWeekPage : ContentPage
{
	public SelectedWeekPage(WeekPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}