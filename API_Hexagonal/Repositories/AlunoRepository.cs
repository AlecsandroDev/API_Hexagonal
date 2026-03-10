using API_Hexagonal.Data.Context;
using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;
using API_Hexagonal.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace API_Hexagonal.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly Context _context;
        public AlunoRepository(Context context)
        {
            this._context = context;
        }

        public AlunoResponseDTO GetAlunoByEmail(string email)
        {
            try
            {
                var aluno = _context.Alunos
                    .Include(a => a.Curso)
                    .Where(a => a.Email == email)
                    .Select(a => new AlunoResponseDTO
                    {
                        AlunoId = a.Id,
                        FirstName = a.FirstName,
                        Email = a.Email,
                        Curso = a.Curso.Name
                    })
                    .FirstOrDefault();

                return aluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AlunoResponseDTO GetAluno(Guid id)
        {
            try
            {
                var aluno = _context.Alunos
                    .Include(a => a.Curso)
                    .Where(a => a.Id == id)
                    .Select(a => new AlunoResponseDTO
                    {
                        AlunoId = a.Id,
                        FirstName = a.FirstName,
                        Email = a.Email,
                        Curso = a.Curso.Name
                    })
                    .FirstOrDefault();

                return aluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<AlunoResponseDTO> GetAlunoAll()
        {
            try
            {
                var alunos = _context.Alunos
                    .Include(a => a.Curso)
                    .Select(a => new AlunoResponseDTO
                    {
                        AlunoId = a.Id,
                        FirstName = a.FirstName,
                        Email = a.Email,
                        Curso = a.Curso.Name
                    })
                    .ToList();

                return alunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void MatricularAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditAluno(Guid Id, AlunoDTO alunoDTO)
        {
            try
            {
                Aluno alunoFind = _context.Alunos.Find(Id);
                
                alunoFind.FirstName = alunoDTO.FirstName;
                alunoFind.Email = alunoDTO.Email;

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAluno(Guid Id)
        {
            try
            {
                Aluno aluno =  _context.Alunos.Find(Id);
                _context.Alunos.Remove(aluno);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
