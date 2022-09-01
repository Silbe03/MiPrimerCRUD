using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimerCRUD.Models
{

    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

    
        public string? Lugar { get; set; }

        [Display(Name = "Fecha de Inicio")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Estado Activo")]
        public bool Activo { get; set; }


        public virtual ICollection<Asignatura>? Asignaturas { get; set; }
    }

    internal class KeyAttribute : Attribute
    {
    }
}
