using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_de_productos.Models;
using SQLite;



namespace app_de_productos
{
    class RepositorioProductos
    {
        private SQLiteConnection cnn;
        string _dbPath;

        string StatusMessage;
        //string creado para ser utilizado como mensaje de información al usuario, se debe crear un label en la vista
        //borrar si es innecesario

        public RepositorioProductos(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (cnn is not null)
                return;

            cnn = new(_dbPath);
            cnn.CreateTable<Marcas>();
            cnn.CreateTable<Producto>();
        }

        private bool ValidarProducto(string nombre, string descripcion, decimal precio, int cantidad, int marca)
        {
            bool validar = false;

            if (!string.IsNullOrWhiteSpace(nombre) || !string.IsNullOrWhiteSpace(descripcion) || precio >= 0 || cantidad>0 || marca != 0)
            {
                validar = true;
                return validar;
            }
            else
            {
                return validar;
            }
        }

        public void AgregarProducto(string nombre,
                                    string descripcion,
                                    decimal precio,
                                    int cantidad,
                                    int marca)
        {
            //marca figura como INT porque asumo que se usará el id, en todo caso corregir
            //cantidad, descripcion, nombre, precio, marca

            //en caso de crear un resultado que informara si la carga fue exitosa
            Init();
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
                    //TODO crear registros para insertar, descomentar una vez creadas

                    //Nombre = nombre,
                    //Descripcion = descripcion,
                    //Cantidad = cantidad,
                    //Precio = precio,
                    //Marca = marca
                };
                result = cnn.Insert(p);

                StatusMessage = string.Format($"{result} producto(s) agregados (Nombre: {nombre})");
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error al agregar {nombre}, Motivo: {ex.Message}";
            }

        }
    }
}
