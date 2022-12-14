using app_de_productos.ViewModel;
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
        ProductosDatabase database = await ProductosDatabase.Instance;
        CollectionView.ItemsSource = await database.GetItemsAsync();
    }


}


