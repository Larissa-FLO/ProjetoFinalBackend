using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ContextSQL _context;

        public NotaFiscalRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<NotaFiscal> ObterTodasAsNotas()
        {
            return _context.Nota_Fiscal
                .Select(nf => new NotaFiscal
                {
                    ID_NOTA = nf.ID_NOTA,
                    ID_FOR = nf.ID_FOR,
                    ID_SEC = nf.ID_SEC,
                    NUM_NOTA = nf.NUM_NOTA,
                    VALOR_NOTA = nf.VALOR_NOTA,
                    QTD_ITEM = nf.QTD_ITEM,
                    ICMS = nf.ICMS,
                    ISS = nf.ISS,
                    ANO = nf.ANO,
                    MES = nf.MES,
                    DATA_NOTA = nf.DATA_NOTA,
                    ID_TIPO_NOTA = nf.ID_TIPO_NOTA,
                    OBSERVACAO_NOTA = nf.OBSERVACAO_NOTA,
                    EMPENHO_NUM = nf.EMPENHO_NUM
                }).ToList();
        }

        public NotaFiscal ObterNotaPorId(int id)
        {
            return _context.Nota_Fiscal
                .Select(nf => new NotaFiscal
                {
                    ID_NOTA = nf.ID_NOTA,
                    ID_FOR = nf.ID_FOR,
                    ID_SEC = nf.ID_SEC,
                    NUM_NOTA = nf.NUM_NOTA,
                    VALOR_NOTA = nf.VALOR_NOTA,
                    QTD_ITEM = nf.QTD_ITEM,
                    ICMS = nf.ICMS,
                    ISS = nf.ISS,
                    ANO = nf.ANO,
                    MES = nf.MES,
                    DATA_NOTA = nf.DATA_NOTA,
                    ID_TIPO_NOTA = nf.ID_TIPO_NOTA,
                    OBSERVACAO_NOTA = nf.OBSERVACAO_NOTA,
                    EMPENHO_NUM = nf.EMPENHO_NUM
                }).ToList().First(x => x?.ID_NOTA == id);
        }

        public NotaFiscal CriarNota(NotaFiscal notaFiscal)
        {
            _context.Nota_Fiscal.Add(notaFiscal);
            _context.SaveChanges();

            return notaFiscal;
        }

        public NotaFiscal AtualizarNota(NotaFiscal notaFiscal, int idNota)
        {
            var notaAntiga = _context.Nota_Fiscal.Find(idNota);
            if (notaAntiga == null)
            {
                throw new Exception();
            }

            notaAntiga.ID_FOR = notaFiscal.ID_FOR;
            notaAntiga.ID_SEC = notaFiscal.ID_SEC;
            notaAntiga.NUM_NOTA = notaFiscal.NUM_NOTA;
            notaAntiga.VALOR_NOTA = notaFiscal.VALOR_NOTA;
            notaAntiga.QTD_ITEM = notaFiscal.QTD_ITEM;
            notaAntiga.ICMS = notaFiscal.ICMS;
            notaAntiga.ISS = notaFiscal.ISS;
            notaAntiga.ANO = notaFiscal.ANO;
            notaAntiga.MES = notaFiscal.MES;
            notaAntiga.DATA_NOTA = notaFiscal.DATA_NOTA;
            notaAntiga.ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA;
            notaAntiga.OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA;
            notaAntiga.EMPENHO_NUM = notaFiscal.EMPENHO_NUM;

            _context.SaveChanges();
            return notaFiscal;
        }

        public void DeletarNota(int idNota)
        {
            var notaFiscal = _context.Nota_Fiscal.Find(idNota);
            if (notaFiscal == null)
            {
                throw new Exception();
            }
            _context.Nota_Fiscal.Remove(notaFiscal);
            _context.SaveChanges();
        }
    }
}
