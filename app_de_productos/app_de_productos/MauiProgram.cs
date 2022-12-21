using app_de_productos.Services;
using app_de_productos.ViewModels;
using app_de_productos.Views;
using app_de_productos;

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

        //Services
        builder.Services.AddSingleton<IProductosService, ProductosService>();


        // Views registrations
        builder.Services.AddSingleton<VistaListaProductos>();
        builder.Services.AddTransient<VistaCrearEditarProducto>();
        builder.Services.AddTransient<VistaDetalles>();

        // ViewModels Registrations
        builder.Services.AddSingleton<VistaListaProductosViewModels>();
        builder.Services.AddTransient<VistaCrearEditarProductoViewModel>();
        builder.Services.AddTransient<VistaDetallesViewModel>();

        return builder.Build();
    }
}