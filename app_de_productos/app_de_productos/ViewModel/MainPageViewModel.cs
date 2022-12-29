using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace app_de_productos.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {

        [RelayCommand]
        async void AñadirCommand()
        {
            await Shell.Current.GoToAsync($"//{nameof(CrearVerProducto)}");
        }
    }
}
