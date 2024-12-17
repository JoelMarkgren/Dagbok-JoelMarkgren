using Dagbok_JoelMarkgren.Services;
using Dagbok_JoelMarkgren.ViewModels;
using Microsoft.Extensions.Logging;

namespace Dagbok_JoelMarkgren
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<WeekViewModel>();
            builder.Services.AddTransient<WeekPageViewModel>();
            builder.Services.AddTransient<SelectedWeekPage>();
            builder.Services.AddSingleton<WeekUpdateService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
