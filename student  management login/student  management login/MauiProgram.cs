using Microsoft.Extensions.Logging;

namespace student__management_login
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

#if DEBUG
    		builder.Logging.AddDebug();
           builder.Services.AddSingleton<view.studenrview>();
            builder.Services.AddSingleton<view.studentmarkview>();
#endif

            return builder.Build();
        }
    }
}
