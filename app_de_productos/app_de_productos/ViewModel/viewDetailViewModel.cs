using app_de_productos.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vistaAppABMProductos.ViewModel;

public partial class viewDetailViewModel : ObservableObject
{

    [RelayCommand]
    async Task Edit(string s)
    {
        // edita nuestros productos
        await Shell.Current.GoToAsync(nameof(CrearVerProducto));
    }

}
