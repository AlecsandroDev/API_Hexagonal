using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;

namespace API_Hexagonal.Interfaces.IServices
{
    public interface ICursoService
    {
        public List<CursoResponseDTO> GetCursoAll();
    }
}
