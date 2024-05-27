using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        private readonly ContextSQL _context;

        public RequisicaoRepository(ContextSQL context) 
        { 
            _context = context;
        }

        public List<Requisicao> ObterTodasAsRequisicoes()
        {
            return _context.Requisicao
                .Select(r => new Requisicao
                {
                    ID_REQ = r.ID_REQ,
                    ID_CLI = r.ID_CLI,
                    TOTAL_REQ = r.TOTAL_REQ,
                    QTD_ITEN = r.QTD_ITEN,
                    DATA_REQ = r.DATA_REQ,
                    ANO = r.ANO,
                    MES = r.MES,    
                    ID_SEC = r.ID_SEC,
                    ID_SET = r.ID_SET,
                    OBSERVACAO = r.OBSERVACAO
                }).ToList();
        }

        public Requisicao ObterRequisicaoPorId(int id)
        {
            return _context.Requisicao
                .Select (r => new Requisicao
                {
                    ID_REQ = r.ID_REQ,
                    ID_CLI = r.ID_CLI,
                    TOTAL_REQ = r.TOTAL_REQ,
                    QTD_ITEN = r.QTD_ITEN,
                    DATA_REQ = r.DATA_REQ,
                    ANO = r.ANO,
                    MES = r.MES,
                    ID_SEC = r.ID_SEC,
                    ID_SET = r.ID_SET,
                    OBSERVACAO = r.OBSERVACAO
                }).ToList().First(x => x?.ID_REQ == id);
        }

        public Requisicao CriarRequisicao(Requisicao requisicao)
        {
            _context.Requisicao.Add(requisicao);
            _context.SaveChanges();

            return requisicao;  
        }

        public Requisicao AtualizarRequisicao(Requisicao requisicao, int id)
        {
            var requisicaoAntiga = _context.Requisicao.Find(id);
            if (requisicaoAntiga == null)
            {
                throw new Exception();
            }

            requisicaoAntiga.ID_CLI = requisicao.ID_CLI;
            requisicaoAntiga.TOTAL_REQ = requisicao.TOTAL_REQ;
            requisicaoAntiga.QTD_ITEN = requisicao.QTD_ITEN;
            requisicaoAntiga.DATA_REQ = requisicao.DATA_REQ;
            requisicaoAntiga.ANO = requisicao.ANO;
            requisicaoAntiga.MES = requisicao.MES;
            requisicaoAntiga.ID_SEC = requisicao.ID_SEC;
            requisicaoAntiga.ID_SET = requisicao.ID_SET;
            requisicaoAntiga.OBSERVACAO = requisicao.OBSERVACAO;

            _context.SaveChanges();
            return requisicao;
        }

        public void DeletarRequisicao(int id)
        {
            var requisicao = _context.Itens_Nota.Find(id);
            if (requisicao == null)
            {
                throw new Exception();
            }
            _context.Itens_Nota.Remove(requisicao);
            _context.SaveChanges();
        }
    }
}
