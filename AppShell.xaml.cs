namespace Dagbok_JoelMarkgren
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
			Routing.RegisterRoute(nameof(SelectedWeekPage), typeof(SelectedWeekPage));

		}
    }
}
