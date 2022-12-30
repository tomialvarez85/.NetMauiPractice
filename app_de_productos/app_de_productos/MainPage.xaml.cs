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
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ProductosService database = await ProductosService.Instance;
        CollectionView.ItemsSource = await database.GetItemsAsync();
    }


}


