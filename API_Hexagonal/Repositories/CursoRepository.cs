using API_Hexagonal.Data.Context;
using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;
using API_Hexagonal.Interfaces.IRepositories;

namespace API_Hexagonal.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly Context _context;
        public CursoRepository(Context context)
        {
            this._context = context;
        }

        public Curso GetCurso(Guid Id)
        {
            try
            {
                Curso curso = _context.Cursos.Find(Id);
                return curso;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<CursoResponseDTO> GetCursoAll()
        {
            try
            {
                List<CursoResponseDTO> cursos = _context.Cursos
                    .Select(cur => new CursoResponseDTO
                    {
                        CursoId = cur.Id,
                        Name = cur.Name,
                    })
                    .ToList();

                return cursos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
