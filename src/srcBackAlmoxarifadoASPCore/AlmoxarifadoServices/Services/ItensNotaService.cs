using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.Services
{
    public class ItensNotaService
    {
        public readonly IItensNotaRepository _itensNotaRepository;
        public readonly MapperConfiguration _configurationMapper;

        public ItensNotaService(IItensNotaRepository itensNotaRepository)
        {
            _itensNotaRepository = itensNotaRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensNota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaGetDTO, ItensNota>();
            });
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            var mapper = _configurationMapper.CreateMapper();

            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNota());
        }

        public ItensNota ObterItensNotaPorId(int id)
        {
            return _itensNotaRepository.ObterItensNotaPorId(id);
        }

        public ItensNotaGetDTO CriarItensNota(ItensNotaPostDTO itensNota)
        {
            var itensNotaSalvo = _itensNotaRepository.CriarItensNota(
                new ItensNota
                {
                    ID_NOTA = itensNota.ID_NOTA,
                    ID_SEC = itensNota.ID_SEC,
                    QTD_PRO = itensNota.QTD_PRO,
                    PRE_UNIT = itensNota.PRE_UNIT,
                    TOTAL_ITEM = itensNota.TOTAL_ITEM,
                    EST_LIN = itensNota.EST_LIN
                });

            return new ItensNotaGetDTO
            {
                ID_NOTA = itensNotaSalvo.ID_NOTA,
                ID_SEC = itensNotaSalvo.ID_SEC,
                QTD_PRO = itensNotaSalvo.QTD_PRO,
                PRE_UNIT = itensNotaSalvo.PRE_UNIT,
                TOTAL_ITEM = itensNotaSalvo.TOTAL_ITEM,
                EST_LIN = itensNotaSalvo.EST_LIN
            };
        }

        public ItensNotaGetDTO AtualizarItensNota(ItensNotaPostDTO itensNotaDTO, int id)
        {
            var itensNotaSalvo = _itensNotaRepository.AtualizarItensNota(new ItensNota
            {
                ID_NOTA = itensNotaDTO.ID_NOTA,
                ID_SEC = itensNotaDTO.ID_SEC,
                QTD_PRO = itensNotaDTO.QTD_PRO,
                PRE_UNIT = itensNotaDTO.PRE_UNIT,
                TOTAL_ITEM = itensNotaDTO.TOTAL_ITEM,
                EST_LIN = itensNotaDTO.EST_LIN
            }, id);

            return new ItensNotaGetDTO
            {
                ID_NOTA = itensNotaSalvo.ID_NOTA,
                ID_SEC = itensNotaSalvo.ID_SEC,
                QTD_PRO = itensNotaSalvo.QTD_PRO,
                PRE_UNIT = itensNotaSalvo.PRE_UNIT,
                TOTAL_ITEM = itensNotaSalvo.TOTAL_ITEM,
                EST_LIN = itensNotaSalvo.EST_LIN
            };
        }

        public void DeletarItensNota(int id)
        {
            _itensNotaRepository.DeletarItensNota(id);
        }
    }
}
