using app_de_productos.ViewModel;
namespace app_de_productos.Views;

public partial class viewDetails : ContentPage
{
    public viewDetails(viewDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}