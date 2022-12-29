using app_de_productos.Views;
using app_de_productos.ViewModels;
using app_de_productos.ViewModel;

namespace app_de_productos;

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

        builder.Services.AddSingleton<viewDetails>();
        builder.Services.AddSingleton<viewDetailViewModel>();

		builder.Services.AddTransient<CrearVerProducto>();
		builder.Services.AddTransient<CrearVerProductoViewModel>();

        return builder.Build();
	}
}
