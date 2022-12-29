using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace app_de_productos.ViewModel
{
    public partial class CrearVerProductoViewModel : ObservableObject
    {
        [ObservableProperty]
        string nombre;

        [ObservableProperty]
        string marca;

        [ObservableProperty]
        string precio;

        [ObservableProperty]
        string descripcion;

        [ObservableProperty]
        string imagen;


        [RelayCommand]
        async void CargarProducto()
        {
            // Cargar producto a la base de datos con las propiedades de arriba.

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
