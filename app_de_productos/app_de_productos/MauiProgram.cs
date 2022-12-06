using app_de_productos.Services;
using app_de_productos.ViewModels;
using app_de_productos.Views;

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


        //Views Registration
        builder.Services.AddSingleton<ProductosListPage>();
        builder.Services.AddTransient<AddUpdateProductosDetail>();


        //View Models
        builder.Services.AddSingleton<ProductosListPageViewModel>();
        builder.Services.AddTransient<AddUpdateProductosDetailViewModel>();


        return builder.Build();
	}
}
