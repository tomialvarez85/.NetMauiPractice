using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_de_productos.Models
{
    [Table("marca")]
    public class Marca
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [MaxLength(50), Unique]
        public string Nombre { get; set; }


        public override string ToString()
        {
            return Nombre;
        }
    }
}