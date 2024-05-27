using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface INotaFiscalRepository
    {
        List<NotaFiscal> ObterTodasAsNotas();
        NotaFiscal ObterNotaPorId(int id);
        NotaFiscal CriarNota(NotaFiscal notaFiscal);
        NotaFiscal AtualizarNota(NotaFiscal notaFiscal, int idNota);
        void DeletarNota(int idNota);
    }
}
