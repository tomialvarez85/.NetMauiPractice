using app_de_productos.Models;
using app_de_productos.Services;
using app_de_productos.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_de_productos.ViewModels
{
    [QueryProperty("Producto", "Producto")]
    public partial class VistaDetallesViewModel : ObservableObject
    {
        [ObservableProperty]
        private Productos _producto;

        private readonly IProductosService _productosService;

        public VistaDetallesViewModel(IProductosService productosService)
        {
            _productosService = productosService;
        }


        [RelayCommand]
        public async void IrAEditarProducto()
        {
            var navParametro = new Dictionary<string, object>()
            {
                {"Producto", Producto}
            };

            string boton = "Guardar";
            string titulo = "Editar producto";

            await Shell.Current.GoToAsync($"{nameof(VistaCrearEditarProducto)}?Boton={boton}&Titulo={titulo}", true, navParametro);
        }

        [RelayCommand]
        public async void EliminarProducto()
        {
            var response = await _productosService.DeleteProductos(Producto);

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Producto eliminado", "El Producto se Eliminó con éxito", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Algo ocurrió y no se pudo eliminar el producto", "OK");
            }

            await Shell.Current.GoToAsync("//VistaListaProductos");
        }

    }
}