using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;

namespace API_Hexagonal.Interfaces.IRepositories
{
    public interface IAlunoRepository
    {
        public AlunoResponseDTO GetAluno(Guid Id);
        public AlunoResponseDTO GetAlunoByEmail(string Email);
        public List<AlunoResponseDTO> GetAlunoAll();
        public void MatricularAluno(Aluno aluno);
        public void EditAluno(Guid Id, AlunoDTO alunoDTO);
        public void DeleteAluno(Guid Id);
    }
}
