using app_de_productos.Views;

namespace app_de_productos;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(VistaCrearEditarProducto), typeof(VistaCrearEditarProducto));
        Routing.RegisterRoute(nameof(VistaDetalles), typeof(VistaDetalles));
    }
}