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
        string StatusMessage;
        //string creado para ser utilizado como mensaje de información al usuario, se debe crear un label en la vista
        //borrar si es innecesario

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
        private bool ValidarProducto(string nombre, string descripcion, decimal precio, int cantidad, int marca)
        {
            bool validar = false;

            if (!string.IsNullOrWhiteSpace(nombre) || !string.IsNullOrWhiteSpace(descripcion) || precio >= 0 || cantidad > 0 || marca != 0)
            {
                validar = true;
                return validar;
            }
            else
            {
                return validar;
            }
        }

        public async Task AgregarProducto(string nombre,
                                    string descripcion,
                                    decimal precio,
                                    int cantidad,
                                    int marca)
        {
            //marca figura como INT porque asumo que se usará el id, en todo caso corregir
            //cantidad, descripcion, nombre, precio, marca

            //en caso de crear un resultado que informara si la carga fue exitosa
            await SetUpDb();
            int result = 0;

            try
            {
                ValidarProducto(nombre,
                                descripcion,
                                precio,
                                cantidad,
                                marca);

                Producto p = new()
                {
                    //TODO crear registros para insertar

                    //Nombre = nombre,
                    //Descripcion = descripcion,
                    //Cantidad = cantidad,
                    //Precio = precio,
                    //Marca = marca
                };
                result = await _dbConnection.InsertAsync(p);

                StatusMessage = string.Format($"{result} producto(s) agregados (Nombre: {nombre})");
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error al agregar {nombre}, Motivo: {ex.Message}";
            }

        }

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
