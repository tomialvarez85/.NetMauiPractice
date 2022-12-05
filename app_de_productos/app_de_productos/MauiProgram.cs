using app_de_productos.Views;
using vistaAppABMProductos.ViewModel;

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

        return builder.Build();
	}
}
