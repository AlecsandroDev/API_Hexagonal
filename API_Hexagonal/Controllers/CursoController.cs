using API_Hexagonal.DTOs;
using API_Hexagonal.Entities;
using API_Hexagonal.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Hexagonal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        public CursoController(ICursoService service)
        {
            _service = service;
        }

        [HttpGet("GetCursoAll")]
        public IActionResult GetCursoAll()
        {
            try
            {
                List<CursoResponseDTO> cursosResponse = _service.GetCursoAll();
                return Ok(cursosResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}