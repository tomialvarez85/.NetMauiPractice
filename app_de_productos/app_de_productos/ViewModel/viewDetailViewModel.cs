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

namespace vistaAppABMProductos.ViewModel
{

    [QueryProperty(nameof(ProductosDetail), "ProductosDetail")]
    public partial class viewDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private ProductosModel _productosDetail = new ProductosModel();

        private readonly IProductosService _productosService;
        public AddUpdateProductosDetailViewModel(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [ICommand]
        public async void AddUpdateProductos()
        {
            int response = -1;
            if (ProductosDetail.id_productos > 0)
            {
                response = await _productosService.UpdateProductos(ProductosDetail);
            }
            else
            {
                response = await _productosService.AddProductos(new Models.ProductosModel
                {
                    nombre = ProductosDetail.nombre,
                    descripcion = ProductosDetail.descripcion,
                    precio = ProductosDetail.precio,
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
