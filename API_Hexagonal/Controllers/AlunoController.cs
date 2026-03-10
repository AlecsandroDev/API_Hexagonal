using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;
using API_Hexagonal.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Hexagonal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpGet("GetAluno")]
        public IActionResult GetAluno([FromQuery] Guid Id)
        {
            try
            {
                AlunoResponseDTO alunoResponse = _service.GetAluno(Id);
                return Ok(alunoResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAlunoAll")]
        public IActionResult GetAlunoAll()
        {
            try
            {
                List<AlunoResponseDTO> alunoResponse = _service.GetAlunoAll();
                return Ok(alunoResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("MatricularAluno")]
        public IActionResult MatricularAluno([FromBody] AlunoDTO alunoDTO)
        {
            try
            {
                _service.MatricularAluno(alunoDTO);

                return Ok("Aluno matriculado com Sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditAluno")]
        public IActionResult EditAluno([FromQuery] Guid Id, [FromBody] AlunoDTO alunoDTO)
        {
            try
            {
                _service.EditAluno(Id, alunoDTO);
                return Ok("Aluno atualizado com Sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteAluno")]
        public IActionResult DeleteAluno([FromQuery] Guid Id)
        {
            try
            {
                _service.DeleteAluno(Id);
                return Ok("Aluno deletado do sistema com Sucesso !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}