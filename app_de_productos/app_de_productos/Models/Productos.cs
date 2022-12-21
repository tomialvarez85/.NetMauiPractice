using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_de_productos.Models
{
    [Table("producto")]
    public class Productos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), Unique]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        public string Marca { get; set; }

    }
}