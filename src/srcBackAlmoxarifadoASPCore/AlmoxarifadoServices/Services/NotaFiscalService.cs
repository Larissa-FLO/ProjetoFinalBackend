using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices.Services
{
    public class NotaFiscalService
    {
        public readonly INotaFiscalRepository _notaFiscalRepository;
        public readonly MapperConfiguration _configurationMapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NotaFiscal, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalGetDTO, NotaFiscal>();
            });
        }

        public List<NotaFiscalGetDTO> ObterTodasAsNotas()
        {
            var mapper = _configurationMapper.CreateMapper();

            return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodasAsNotas());
        }

        public NotaFiscal ObterNotaPorId(int id)
        {
            return _notaFiscalRepository.ObterNotaPorId(id);
        }

        public NotaFiscalGetDTO CriarNota(NotaFiscalPostDTO notaFiscal)
        {
            var notaSalva = _notaFiscalRepository.CriarNota(
                new NotaFiscal {
                    ID_FOR = notaFiscal.ID_FOR,
                    ID_SEC = notaFiscal.ID_SEC,
                    NUM_NOTA = notaFiscal.NUM_NOTA,
                    VALOR_NOTA = notaFiscal.VALOR_NOTA,
                    QTD_ITEM = notaFiscal.QTD_ITEM,
                    ICMS = notaFiscal.ICMS,
                    ISS = notaFiscal.ISS,
                    ANO = notaFiscal.ANO,
                    MES = notaFiscal.MES,
                    DATA_NOTA = notaFiscal.DATA_NOTA,
                    ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA,
                    OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA,
                    EMPENHO_NUM = notaFiscal.EMPENHO_NUM
                });

            return new NotaFiscalGetDTO
            {
                ID_FOR = notaSalva.ID_FOR,
                ID_SEC = notaSalva.ID_SEC,
                NUM_NOTA = notaSalva.NUM_NOTA,
                VALOR_NOTA = notaSalva.VALOR_NOTA,
                QTD_ITEM = notaSalva.QTD_ITEM,
                ICMS = notaSalva.ICMS,
                ISS = notaSalva.ISS,
                ANO = notaSalva.ANO,
                MES = notaSalva.MES,
                DATA_NOTA = notaSalva.DATA_NOTA,
                ID_TIPO_NOTA = notaSalva.ID_TIPO_NOTA,
                OBSERVACAO_NOTA = notaSalva.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaSalva.EMPENHO_NUM
            };
        }

        public NotaFiscalGetDTO AtualizarNota(NotaFiscalPostDTO notaFiscalDTO, int idNota)
        {
            var notaSalva = _notaFiscalRepository.AtualizarNota(new NotaFiscal 
            {
                ID_FOR = notaFiscalDTO.ID_FOR,
                ID_SEC = notaFiscalDTO.ID_SEC,
                NUM_NOTA = notaFiscalDTO.NUM_NOTA,
                VALOR_NOTA = notaFiscalDTO.VALOR_NOTA,
                QTD_ITEM = notaFiscalDTO.QTD_ITEM,
                ICMS = notaFiscalDTO.ICMS,
                ISS = notaFiscalDTO.ISS,
                ANO = notaFiscalDTO.ANO,
                MES = notaFiscalDTO.MES,
                DATA_NOTA = notaFiscalDTO.DATA_NOTA,
                ID_TIPO_NOTA = notaFiscalDTO.ID_TIPO_NOTA,
                OBSERVACAO_NOTA = notaFiscalDTO.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscalDTO.EMPENHO_NUM
            },idNota);

            return new NotaFiscalGetDTO
            {
                ID_FOR = notaSalva.ID_FOR,
                ID_SEC = notaSalva.ID_SEC,
                NUM_NOTA = notaSalva.NUM_NOTA,
                VALOR_NOTA = notaSalva.VALOR_NOTA,
                QTD_ITEM = notaSalva.QTD_ITEM,
                ICMS = notaSalva.ICMS,
                ISS = notaSalva.ISS,
                ANO = notaSalva.ANO,
                MES = notaSalva.MES,
                DATA_NOTA = notaSalva.DATA_NOTA,
                ID_TIPO_NOTA = notaSalva.ID_TIPO_NOTA,
                OBSERVACAO_NOTA = notaSalva.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaSalva.EMPENHO_NUM
            };
        }

        public void DeletarNota(int id)
        {
            _notaFiscalRepository.DeletarNota(id);
        }
    }
}
