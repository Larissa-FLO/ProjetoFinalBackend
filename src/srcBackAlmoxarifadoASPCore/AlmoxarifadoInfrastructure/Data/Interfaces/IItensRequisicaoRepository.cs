using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensRequisicaoRepository
    {
        List<ItensRequisicao> ObterTodosItensRequisicao();
        ItensRequisicao ObterItensrequisicaoPorId(int id);
        ItensRequisicao CriarItensRequisicao(ItensRequisicao itensRequisicao);
        ItensRequisicao AtualizarItensRequisicao(ItensRequisicao itensRequisicao, int id);
        void DeletarItensRequisicao(int id);
    }
}
