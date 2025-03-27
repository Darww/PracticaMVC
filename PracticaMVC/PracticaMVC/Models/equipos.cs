using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
        [Table("equipos")]  // Mapea a la tabla "equipos" en la base de datos
        public class equipos
        {
            [Key]
            public int id_equipos { get; set; }

            public string nombre { get; set; }
            public string description { get; set; }

            [ForeignKey("tipo_equipo")]  // Relación con tabla tipo_equipo
            [Column("tipo_equipo_id")]
            public int tipo_equipo_id { get; set; }

            [ForeignKey("marcas")]  // Relación con tabla marcas
            [Column("marca_id")]
            public int marca_id { get; set; }
            public string modelo { get; set; }
            public int anio_compra { get; set; }
            public decimal costo { get; set; }
            public int vida_util { get; set; }

            [ForeignKey("estados_equipo")]  // Relación con tabla estados_equipo
            [Column("estado_equipo_id")]
            public int estado_equipo_id { get; set; }
            public int estado { get; set; }


        }
}
