using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDatosEF.Models
{
    [Table("EMP")]
    public class Empleados
    {
        [Key]
        [Column("EMP_NO")]
        public int empid { get; set; }
        [Column("APELLIDO")]
        public string Nombre { get;set; }
        [Column("OFICIO")]
        public string Oficio { get; set; }
        [Column("FECHA_ALT")]
        public DateTime Fecha { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }









    }
}
