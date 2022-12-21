using app_de_productos.ViewModels;

namespace app_de_productos.Views;

public partial class VistaListaProductos : ContentPage
{
    private VistaListaProductosViewModels _vm;

    public VistaListaProductos(VistaListaProductosViewModels vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.ListarProductosCommand.Execute(null);
    }
}