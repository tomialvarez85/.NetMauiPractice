using app_de_productos.ViewModels;

namespace app_de_productos.Views;

public partial class VistaDetalles : ContentPage
{
    public VistaDetalles(VistaDetallesViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}