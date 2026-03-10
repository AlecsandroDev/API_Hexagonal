using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;
using API_Hexagonal.Interfaces.IRepositories;
using API_Hexagonal.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API_Hexagonal.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public List<CursoResponseDTO> GetCursoAll()
        {
            try { 
                List<CursoResponseDTO> cursos = _cursoRepository.GetCursoAll();
                return cursos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
