using app_de_productos.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//interfaz de la base de datos

namespace app_de_productos.Services
{
    public interface IProductosService
    {   
        //Conecta para obtener la lista de productos
        Task<List<ProductosModel>> GetProductosList();
        //Conecta la modificacion con la base
        Task<int> UpdateProductos(ProductosModel productosModel);

        //Agrega producto
        Task AgregarProducto(string nombre,
                                    string descripcion,
                                    decimal precio,
                                    int cantidad,
                                    int marca);



    }
}
