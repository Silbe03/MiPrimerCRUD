namespace MiPrimerCRUD.Models
{
    public class Asignatura
    {
        public long Id { get; set; }

        public string? Nombre { get; set; }


        public long? CursilloId { get; set; }

        public Curso? Cursillo { get; set; }





    }
}
