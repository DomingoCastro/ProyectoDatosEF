using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDatosEF.Models
{
    [Table("PLANTILLA")]
    public class Plantilla
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int HospitalCod { get; set; }
        [Column("SALA_COD")]
        public int SalaCod { get; set; }
        [Column("EMPLEADO_NO")]
        public int EmpleadoCod { get; set; }
        [Column("APELLIDO")]
        public string Apellido { get; set; }
        [Column("FUNCION")]
        public string Funcion { get; set; }
        [Column("T")]
        public string T { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
