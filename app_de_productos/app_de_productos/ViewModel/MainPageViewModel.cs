using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using app_de_productos.Views;

namespace app_de_productos.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        async void IrADetallesProductoCommand()
        {
            await Shell.Current.GoToAsync($"//{nameof(viewDetails)}");
        }
        [RelayCommand]
        async void AñadirCommand()
        {
            await Shell.Current.GoToAsync($"//{nameof(CrearVerProducto)}");
        }
    }
}
