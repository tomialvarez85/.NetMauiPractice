using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace app_de_productos.ViewModel
{
    public partial class CrearVerProductoViewModel : ObservableObject
    {

        [RelayCommand]
        async void CargarProducto()
        {
            // Cargar o modificar producto a la base de datos

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
