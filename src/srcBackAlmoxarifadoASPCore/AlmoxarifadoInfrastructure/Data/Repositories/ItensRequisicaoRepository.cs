using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensRequisicaoRepository : IItensRequisicaoRepository
    {
        private readonly ContextSQL _context;

        public ItensRequisicaoRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<ItensRequisicao> ObterTodosItensRequisicao()
        {
            return _context.Itens_Req
                .Select(i => new ItensRequisicao
                {
                    NUM_ITEM = i.NUM_ITEM,
                    ID_PRO = i.ID_PRO,
                    ID_REQ = i.ID_REQ,
                    ID_SEC = i.ID_SEC,
                    QTD_PRO = i.QTD_PRO,
                    PRE_UNIT = i.PRE_UNIT,
                    TOTAL_ITEM = i.TOTAL_ITEM,
                    TOTAL_REAL = i.TOTAL_REAL
                }).ToList();
        }

        public ItensRequisicao ObterItensrequisicaoPorId(int id)
        {
            return _context.Itens_Req
                .Select(i => new ItensRequisicao
                {
                    NUM_ITEM = i.NUM_ITEM,
                    ID_PRO = i.ID_PRO,
                    ID_REQ = i.ID_REQ,
                    ID_SEC = i.ID_SEC,
                    QTD_PRO = i.QTD_PRO,
                    PRE_UNIT = i.PRE_UNIT,
                    TOTAL_ITEM = i.TOTAL_ITEM,
                    TOTAL_REAL = i.TOTAL_REAL
                }).ToList().First(x => x?.NUM_ITEM == id);
        }

        public ItensRequisicao CriarItensRequisicao(ItensRequisicao itensRequisicao)
        {
            _context.Itens_Req.Add(itensRequisicao);
            _context.SaveChanges();

            return itensRequisicao;
        }

        public ItensRequisicao AtualizarItensRequisicao(ItensRequisicao itensRequisicao, int id)
        {
            var itensRequisicaoAntigo = _context.Itens_Req.Find(id);
            if (itensRequisicaoAntigo == null)
            {
                throw new Exception();
            }

            itensRequisicaoAntigo.ID_PRO = itensRequisicao.ID_PRO;
            itensRequisicaoAntigo.ID_REQ = itensRequisicao.ID_REQ;
            itensRequisicaoAntigo.ID_SEC = itensRequisicao.ID_SEC;
            itensRequisicaoAntigo.QTD_PRO = itensRequisicao.QTD_PRO;
            itensRequisicaoAntigo.PRE_UNIT = itensRequisicao.PRE_UNIT;
            itensRequisicaoAntigo.TOTAL_ITEM = itensRequisicao.TOTAL_ITEM;
            itensRequisicaoAntigo.TOTAL_REAL = itensRequisicao.TOTAL_REAL;

            _context.SaveChanges();
            return itensRequisicao;
        }

        public void DeletarItensRequisicao(int id)
        {
            var itensRequisicao = _context.Itens_Req.Find(id);
            if (itensRequisicao == null)
            {
                throw new Exception();
            }
            _context.Itens_Req.Remove(itensRequisicao);
            _context.SaveChanges();
        }
    }
}
