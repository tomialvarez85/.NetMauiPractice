using vistaAppABMProductos.ViewModel;

namespace app_de_productos.Views;

public partial class viewDetails : ContentPage
{
    public viewDetails(viewDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}