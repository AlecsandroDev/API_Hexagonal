using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;

namespace API_Hexagonal.Interfaces.IServices
{
    public interface IAlunoService
    {
        public AlunoResponseDTO GetAluno(Guid Id);
        public List<AlunoResponseDTO> GetAlunoAll();
        public void MatricularAluno(AlunoDTO alunoDTO);
        public void EditAluno(Guid Id, AlunoDTO alunoDTO);
        public void DeleteAluno(Guid Id);
    }
}
