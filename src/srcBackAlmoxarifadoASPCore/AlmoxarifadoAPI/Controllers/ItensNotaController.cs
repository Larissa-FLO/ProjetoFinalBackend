using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensNotaController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;
        public ItensNotaController(ItensNotaService itensNotaService)
        {
            _itensNotaService = itensNotaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensNota = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/ItensNota/{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var itensNota = _itensNotaService.ObterItensNotaPorId(id);
                if (itensNota == null)
                {
                    return StatusCode(404, "Nenhum resultado para este código");
                }
                return Ok(itensNota);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ItensNotaPostDTO itensNotaDTO)
        {
            try
            {
                var novoItensNota = _itensNotaService.CriarItensNota(itensNotaDTO);
                return Ok(itensNotaDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ItensNotaPostDTO notaFiscalDTO, int idItensNota)
        {
            try
            {
                var itensNota = _itensNotaService.AtualizarItensNota(notaFiscalDTO, idItensNota);
                if (itensNota == null)
                {
                    throw new Exception();
                }
                return Ok(itensNota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete]
        public IActionResult Delete(int idItensNota)
        {
            try
            {
                _itensNotaService.DeletarItensNota(idItensNota);
                return Ok("Item deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
