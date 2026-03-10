using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;

namespace API_Hexagonal.Interfaces.IRepositories
{
    public interface ICursoRepository
    {
        public Curso GetCurso(Guid Id);
        public List<CursoResponseDTO> GetCursoAll();
    }
}
