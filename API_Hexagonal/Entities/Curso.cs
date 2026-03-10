namespace API_Hexagonal.Entities
{
    public class Curso : EntitiyBase
    {
        public string Name { get; set; }
        public virtual List<Aluno> Alunos { get; set; } = new();
    }
}
