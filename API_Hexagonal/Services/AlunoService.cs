using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;
using API_Hexagonal.Interfaces.IRepositories;
using API_Hexagonal.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API_Hexagonal.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICursoRepository _cursoRepository;
        public AlunoService(IAlunoRepository alunoRepository, ICursoRepository cursoRepository)
        {
            _alunoRepository = alunoRepository;
            _cursoRepository = cursoRepository;

        }

        private void VerificarAlunoDTO(AlunoDTO alunoDTO) 
        {
            if (alunoDTO.FirstName == null || alunoDTO.FirstName == "")
            {
                throw new Exception("O campo FirstName não pode ser nulo ou vazio.");
            }

            if (alunoDTO.FirstName.Length > 50) 
            {
                throw new Exception("O campo FirstName deve ter no máximo 50 caracteres.");
            }

            if (!alunoDTO.Email.EndsWith("@faculdade.edu")) 
            {
                throw new Exception("O e-mail deve obrigatoriamente terminar com @faculdade.edu.");
            }

            AlunoResponseDTO aluno = _alunoRepository.GetAlunoByEmail(alunoDTO.Email);
            if (aluno != null) 
            {
                throw new Exception("E-mail informado já pertence a outro aluno.");
            }
        }

        public AlunoResponseDTO GetAluno(Guid Id)
        {
            try { 
                if (Id == Guid.Empty)
                {
                    throw new Exception("ID de aluno invalido.");
                }

                AlunoResponseDTO aluno = _alunoRepository.GetAluno(Id);
                return aluno;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AlunoResponseDTO> GetAlunoAll()
        {
            try { 
                List<AlunoResponseDTO> alunos = _alunoRepository.GetAlunoAll();
                return alunos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void MatricularAluno(AlunoDTO alunoDTO)
        {
            try { 
                VerificarAlunoDTO(alunoDTO);

                Curso curso = _cursoRepository.GetCurso(alunoDTO.CursoId);
                if (curso == null)
                {
                    throw new Exception("Curso informado não existe.");
                }

                Aluno aluno = new Aluno();
                aluno.FirstName = alunoDTO.FirstName;
                aluno.Email = alunoDTO.Email;
                aluno.CursoId = alunoDTO.CursoId;

                _alunoRepository.MatricularAluno(aluno);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditAluno(Guid Id, AlunoDTO alunoDTO)
        {
            try {
                if (Id == Guid.Empty)
                {
                    throw new Exception("ID de aluno invalido.");
                }

                AlunoResponseDTO aluno = _alunoRepository.GetAluno(Id);
                if (aluno == null) 
                {
                    throw new Exception("Aluno não foi encontrado no sistema.");
                }

                VerificarAlunoDTO(alunoDTO);
                
                _alunoRepository.EditAluno(Id, alunoDTO);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAluno(Guid Id)
        {
            try {
                if (Id == Guid.Empty)
                {
                    throw new Exception("ID de aluno invalido.");
                }

                AlunoResponseDTO aluno = _alunoRepository.GetAluno(Id);
                if (aluno == null) 
                {
                    throw new Exception("Aluno não foi encontrado no sistema.");
                }

                _alunoRepository.DeleteAluno(Id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
