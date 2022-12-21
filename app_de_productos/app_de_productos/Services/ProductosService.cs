using app_de_productos.Models;
using app_de_productos.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_de_productos.Services
{
    public class ProductosService : IProductosService
    {
        //Conexion con la DB

        private SQLiteAsyncConnection _dbConnection;

        public ProductosService()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Productos.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Productos>();
            }
        }



        //Obtiene una lista con los productos
        public async Task<List<Productos>> GetProductosList()
        {
            var productosList = await _dbConnection.Table<Productos>().ToListAsync();
            return productosList;
        }

        // Añade un nuevo producto
        public Task<int> Addproducto(Productos producto)
        {
            return _dbConnection.InsertAsync(producto);
        }


        //Actualiza/modifica los productos
        public Task<int> UpdateProductos(Productos producto)
        {
            return _dbConnection.UpdateAsync(producto);
        }


        // Elimina un producto
        public Task<int> DeleteProductos(Productos producto)
        {
            return _dbConnection.DeleteAsync(producto);
        }
    }
}