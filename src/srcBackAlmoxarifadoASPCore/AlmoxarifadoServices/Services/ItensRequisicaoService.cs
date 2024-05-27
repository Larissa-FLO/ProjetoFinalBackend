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
    public class ItensRequisicaoService
    {
        public readonly IItensRequisicaoRepository _itensRequisicaoRepository;
        public readonly MapperConfiguration _configurationMapper;

        public ItensRequisicaoService(IItensRequisicaoRepository itensRequisicao)
        {
            _itensRequisicaoRepository = itensRequisicao;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensRequisicao, ItensRequisicaoGetDTO>();
                cfg.CreateMap<ItensRequisicaoGetDTO, ItensRequisicao>();
            });
        }

        public List<ItensRequisicaoGetDTO> ObterTodosItensRequisicao()
        {
            var mapper = _configurationMapper.CreateMapper();

            return mapper.Map<List<ItensRequisicaoGetDTO>>(_itensRequisicaoRepository.ObterTodosItensRequisicao());
        }

        public ItensRequisicao ObterItensRequisicaoPorId(int id)
        {
            return _itensRequisicaoRepository.ObterItensrequisicaoPorId(id);
        }

        public ItensRequisicaoGetDTO CriarItensRequisicao(ItensRequisicaoPostDTO itensRequisicao)
        {
            var itensRequisicaoSalvo = _itensRequisicaoRepository.CriarItensRequisicao(
                new ItensRequisicao
                {
                    ID_PRO = itensRequisicao.ID_PRO,
                    ID_REQ = itensRequisicao.ID_REQ,
                    ID_SEC = itensRequisicao.ID_SEC,
                    QTD_PRO = itensRequisicao.QTD_PRO,
                    PRE_UNIT = itensRequisicao.PRE_UNIT,
                    TOTAL_ITEM = itensRequisicao.PRE_UNIT,
                    TOTAL_REAL = itensRequisicao.TOTAL_REAL
                });

            return new ItensRequisicaoGetDTO
            {
                ID_PRO = itensRequisicaoSalvo.ID_PRO,
                ID_REQ = itensRequisicaoSalvo.ID_REQ,
                ID_SEC = itensRequisicaoSalvo.ID_SEC,
                QTD_PRO = itensRequisicaoSalvo.QTD_PRO,
                PRE_UNIT = itensRequisicaoSalvo.PRE_UNIT,
                TOTAL_ITEM = itensRequisicaoSalvo.PRE_UNIT,
                TOTAL_REAL = itensRequisicaoSalvo.TOTAL_REAL
            };
        }

        public ItensRequisicaoGetDTO AtualizarItensRequisicao(ItensRequisicaoPostDTO itensDTO, int id)
        {
            var itensRequisicaoSalvo = _itensRequisicaoRepository.AtualizarItensRequisicao(new ItensRequisicao
            {
                ID_PRO = itensDTO.ID_PRO,
                ID_REQ = itensDTO.ID_REQ,
                ID_SEC = itensDTO.ID_SEC,
                QTD_PRO = itensDTO.QTD_PRO,
                PRE_UNIT = itensDTO.PRE_UNIT,
                TOTAL_ITEM = itensDTO.PRE_UNIT,
                TOTAL_REAL = itensDTO.TOTAL_REAL
            }, id);

            return new ItensRequisicaoGetDTO
            {
                ID_PRO = itensRequisicaoSalvo.ID_PRO,
                ID_REQ = itensRequisicaoSalvo.ID_REQ,
                ID_SEC = itensRequisicaoSalvo.ID_SEC,
                QTD_PRO = itensRequisicaoSalvo.QTD_PRO,
                PRE_UNIT = itensRequisicaoSalvo.PRE_UNIT,
                TOTAL_ITEM = itensRequisicaoSalvo.PRE_UNIT,
                TOTAL_REAL = itensRequisicaoSalvo.TOTAL_REAL
            };
        }

        public void DeletarItensRequisicao(int id)
        {
            _itensRequisicaoRepository.DeletarItensRequisicao(id);
        }
    }
}
