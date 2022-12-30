using app_de_productos.Views;
using app_de_productos.ViewModel;
using app_de_productos.Services;

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

        // Services
        builder.Services.AddSingleton<IProductosService, ProductosService>();

        // Views 
        builder.Services.AddSingleton<viewDetails>();
        builder.Services.AddTransient<CrearVerProducto>();


        // ViewModel
        builder.Services.AddSingleton<viewDetailViewModel>();
		builder.Services.AddTransient<CrearVerProductoViewModel>();

        return builder.Build();
	}
}
