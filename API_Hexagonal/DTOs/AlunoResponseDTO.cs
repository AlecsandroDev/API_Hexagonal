namespace API_Hexagonal.DTOs
{
    public class AlunoResponseDTO
    {
        public Guid AlunoId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
    }
}