using app_de_productos.Models;
using app_de_productos.Services;
using app_de_productos.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_de_productos.ViewModels
{
    public partial class VistaListaProductosViewModels : ObservableObject
    {
        public ObservableCollection<Productos> Productos { get; set; } = new ObservableCollection<Productos>();

        private readonly IProductosService _productosService;

        public VistaListaProductosViewModels(IProductosService productosService)
        {
            _productosService = productosService;
        }


        [RelayCommand]
        public async void ListarProductos()
        {
            var listaProductos = await _productosService.GetProductosList();

            Productos.Clear();
            if (listaProductos?.Count > 0)
            {
                foreach (var producto in listaProductos)
                {
                    Productos.Add(producto);
                }
            }
        }


        [RelayCommand]
        public async void IrACrearProducto()
        {
            string boton = "Añadir";
            string titulo = "Añadir nuevo producto";

            await Shell.Current.GoToAsync($"{nameof(VistaCrearEditarProducto)}?Boton={boton}&Titulo={titulo}");
        }


        [RelayCommand]
        public async void IrADetallesProducto(Productos producto)
        {
            var navParametro = new Dictionary<string, object>
            {
                {"Producto", producto }
            };


            await Shell.Current.GoToAsync(nameof(VistaDetalles), true, navParametro);
        }

    }
}