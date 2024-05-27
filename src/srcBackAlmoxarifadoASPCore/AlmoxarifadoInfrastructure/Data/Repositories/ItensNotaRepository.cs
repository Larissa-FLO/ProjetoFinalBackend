using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly ContextSQL _context;

        public ItensNotaRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<ItensNota> ObterTodosItensNota()
        {
            return _context.Itens_Nota
                .Select(i => new ItensNota
                {
                    ITEM_NUM = i.ITEM_NUM,
                    ID_PRO = i.ID_PRO,
                    ID_NOTA = i.ID_NOTA,
                    ID_SEC = i.ID_SEC,
                    QTD_PRO = i.QTD_PRO,
                    PRE_UNIT = i.PRE_UNIT,
                    TOTAL_ITEM = i.TOTAL_ITEM,
                    EST_LIN = i.EST_LIN
                }).ToList();
        }

        public ItensNota ObterItensNotaPorId(int id)
        {
            return _context.Itens_Nota
                .Select (i => new ItensNota
                {
                    ITEM_NUM = i.ITEM_NUM,
                    ID_PRO = i.ID_PRO,
                    ID_NOTA = i.ID_NOTA,
                    ID_SEC = i.ID_SEC,
                    QTD_PRO = i.QTD_PRO,
                    PRE_UNIT = i.PRE_UNIT,
                    TOTAL_ITEM = i.TOTAL_ITEM,
                    EST_LIN = i.EST_LIN
                }).ToList().First(x => x?.ITEM_NUM == id);
        }

        public ItensNota CriarItensNota(ItensNota itensNota)
        {
            _context.Itens_Nota.Add(itensNota);
            _context.SaveChanges();

            return itensNota;
        }

        public ItensNota AtualizarItensNota(ItensNota itensNota, int id)
        {
            var itensNotaAntigo = _context.Itens_Nota.Find(id);
            if (itensNotaAntigo == null)
            {
                throw new Exception();
            }

            itensNotaAntigo.ID_PRO = itensNota.ID_PRO;
            itensNotaAntigo.ID_NOTA = itensNota.ID_NOTA;
            itensNotaAntigo.ID_SEC = itensNota.ID_SEC;
            itensNotaAntigo.QTD_PRO = itensNota.QTD_PRO;
            itensNotaAntigo.PRE_UNIT = itensNota.PRE_UNIT;
            itensNotaAntigo.TOTAL_ITEM = itensNota.TOTAL_ITEM;
            itensNotaAntigo.EST_LIN = itensNota.EST_LIN;

            _context.SaveChanges();
            return itensNota;
        }

        public void DeletarItensNota(int id)
        {
            var itensNota = _context.Itens_Nota.Find(id);
            if(itensNota == null)
            {
                throw new Exception();
            }
            _context.Itens_Nota.Remove(itensNota);
            _context.SaveChanges();
        }
    }
}
