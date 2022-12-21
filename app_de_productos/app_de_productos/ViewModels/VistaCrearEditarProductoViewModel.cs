using app_de_productos.Models;
using app_de_productos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_de_productos.ViewModels
{
    [QueryProperty("Boton", "Boton")]
    [QueryProperty("Titulo", "Titulo")]
    [QueryProperty("Producto", "Producto")]
    public partial class VistaCrearEditarProductoViewModel : ObservableObject
    {

        [ObservableProperty]
        private Productos _producto = new Productos();

        [ObservableProperty]
        private string _boton;

        [ObservableProperty]
        private string _titulo;

        private readonly IProductosService _productosService;

        public VistaCrearEditarProductoViewModel(IProductosService productosService)
        {
            _productosService = productosService;
        }


        [RelayCommand]
        public async void AgregarEditarProducto()
        {

            int response = -1;

            if (Producto.Id > 0)
            {
                response = await _productosService.UpdateProductos(Producto);
            }
            else
            {
                response = await _productosService.Addproducto(new Productos
                {
                    Nombre = Producto.Nombre,
                    Marca = Producto.Marca,
                    Descripcion = Producto.Descripcion,
                    Precio = Producto.Precio,
                    Cantidad = Producto.Cantidad,
                });
            }


            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Producto guardado", "El Producto se guardó con éxito", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Algo ocurrió y no se pudo Guardar el producto", "OK");

            }

            await Shell.Current.GoToAsync("//VistaListaProductos");
        }
    }
}