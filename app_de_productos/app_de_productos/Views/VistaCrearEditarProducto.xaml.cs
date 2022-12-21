using app_de_productos.ViewModels;


namespace app_de_productos.Views;

public partial class VistaCrearEditarProducto : ContentPage
{
    public VistaCrearEditarProducto(VistaCrearEditarProductoViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}