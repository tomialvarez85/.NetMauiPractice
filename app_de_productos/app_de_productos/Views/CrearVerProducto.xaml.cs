using app_de_productos.ViewModel;

namespace app_de_productos.Views;

public partial class CrearVerProducto : ContentPage
{
	public CrearVerProducto(CrearVerProductoViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}