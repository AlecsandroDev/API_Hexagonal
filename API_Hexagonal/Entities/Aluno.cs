namespace API_Hexagonal.Entities
{
    public class Aluno : EntitiyBase
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
