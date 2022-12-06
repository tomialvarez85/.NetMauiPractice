using app_de_productos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Clase de la base de datos

namespace app_de_productos.Services
{
    public class ProductosService : IProductosService

    {
        //Conexion con la DB

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Productos.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ProductosModel>();
            }
        }



        //Añade productos


        //Elimina productos



        //Obtiene una lista con los productos
        public async Task<List<ProductosModel>> GetProductosList()
        {
            await SetUpDb();
            var productosList = await _dbConnection.Table<ProductosModel>().ToListAsync();
            return productosList;
        }

        //Actualiza/modifica los productos
        public async Task<int> UpdateProductos(ProductosModel productosModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(productosModel);
        }
    }
}
