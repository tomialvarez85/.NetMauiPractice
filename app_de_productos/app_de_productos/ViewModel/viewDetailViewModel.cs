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

namespace app_de_productos.ViewModel
{

    [QueryProperty(nameof(ProductosDetail), "ProductosDetail")]
    public partial class viewDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Productos _productosDetail = new Productos();

        private readonly IProductosService _productosService;

        public AddUpdateProductosDetailViewModel(IProductosService productosService)
        {
            _productosService = productosService;

        }

        [RelayCommand]
        public async void AddUpdateProductos()
        {
            int response = -1;
            if (ProductosDetail.Id > 0)
            {
                response = await _productosService.UpdateProductos(ProductosDetail);
            }
            else
            {
                response = await _productosService.Addproducto(new Models.Productos
                {
                    Nombre = ProductosDetail.Nombre,
                    Descripcion = ProductosDetail.Descripcion,
                    Precio = ProductosDetail.Precio,
                });
            }
        }

        [RelayCommand]
        async Task Edit(string s)
        {
            // edita nuestros productos
            await Shell.Current.GoToAsync(nameof(CrearVerProducto));
        }

    }
}
