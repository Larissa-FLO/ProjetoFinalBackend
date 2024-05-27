using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly NotaFiscalService _notaFiscalService;
        public NotaFiscalController(NotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var notas = _notaFiscalService.ObterTodasAsNotas();
                return Ok(notas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/NotaFiscal/{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var nota = _notaFiscalService.ObterNotaPorId(id);
                if (nota == null)
                {
                    return StatusCode(404, "Nenhum resultado para este código");
                }
                return Ok(nota);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(NotaFiscalPostDTO notaFiscalDTO)
        {
            try
            {
                var novaNota = _notaFiscalService.CriarNota(notaFiscalDTO);
                return Ok(notaFiscalDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(NotaFiscalPostDTO notaFiscalDTO,int idNota)
        {
            try
            {
                var nota = _notaFiscalService.AtualizarNota(notaFiscalDTO, idNota);
                if (nota == null)
                {
                    throw new Exception();
                }
                return Ok(nota);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int idNota)
        {
            try
            {
                _notaFiscalService.DeletarNota(idNota);
                return Ok("Item deletado com sucesso");
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }
    }
}
