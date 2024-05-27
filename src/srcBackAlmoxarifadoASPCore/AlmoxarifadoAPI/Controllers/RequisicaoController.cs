using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : ControllerBase
    {
        private readonly RequisicaoService _requisicaoService;

        public RequisicaoController(RequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var requisicao = _requisicaoService.ObterTodasAsRequisicoes();
                return Ok(requisicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/Requisicao/{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                var requisicao = _requisicaoService.ObterRequisicaoPorId(id);    
                if (requisicao == null)
                {
                    return StatusCode(404, "Nenhum resultado para este código");
                }
                return Ok(requisicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(RequisicaoPostDTO requisicaoDTO)
        {
            try
            {
                var novaRequisicao = _requisicaoService.CriarRequisicao(requisicaoDTO);
                return Ok(novaRequisicao);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(RequisicaoPostDTO requisicaoDTO, int idRequisicao)
        {
            try
            {
                var requisicao = _requisicaoService.AtualizarRequisicao(requisicaoDTO, idRequisicao);
                if (requisicao == null)
                {
                    throw new Exception();
                }
                return Ok(requisicao);
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
                _requisicaoService.DeletarRequisicao(id);
                return Ok("Item deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
