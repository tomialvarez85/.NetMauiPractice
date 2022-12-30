using app_de_productos.ViewModel;
using app_de_productos.Services;
namespace app_de_productos;


public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
}


