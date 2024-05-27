using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensRequisicaoController : ControllerBase
    {
        private readonly ItensRequisicaoService _itensRequisicaoService;
        public ItensRequisicaoController(ItensRequisicaoService itensRequisicaoService)
        {
            _itensRequisicaoService = itensRequisicaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensRequisicao = _itensRequisicaoService.ObterTodosItensRequisicao();
                return Ok(itensRequisicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/ItensRequisicao/{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var itensRequisicao = _itensRequisicaoService.ObterItensRequisicaoPorId(id);
                if (itensRequisicao == null)
                {
                    return StatusCode(404, "Nenhum resultado para este código");
                }
                return Ok(itensRequisicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ItensRequisicaoPostDTO itensRequisicaoDTO)
        {
            try
            {
                var novoItensRequisicao = _itensRequisicaoService.CriarItensRequisicao(itensRequisicaoDTO);
                return Ok(itensRequisicaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ItensRequisicaoPostDTO itensRequisicaoDTO, int idItensRequisicao)
        {
            try
            {
                var itensRequisicao = _itensRequisicaoService.AtualizarItensRequisicao(itensRequisicaoDTO, idItensRequisicao);
                if (itensRequisicao == null)
                {
                    throw new Exception();
                }
                return Ok(itensRequisicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _itensRequisicaoService.DeletarItensRequisicao(id);
                return Ok("Item deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
