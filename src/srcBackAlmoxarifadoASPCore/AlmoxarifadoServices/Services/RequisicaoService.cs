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
    public class RequisicaoService
    {
        public readonly IRequisicaoRepository _requisicaoRepository;
        public readonly MapperConfiguration _configurationMapper;

        public RequisicaoService(IRequisicaoRepository requisicaoRepository, MapperConfiguration configurationMapper)
        {
            _requisicaoRepository = requisicaoRepository;
            _configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoGetDTO, Requisicao>();
            });
        }
        
        public List<RequisicaoGetDTO> ObterTodasAsRequisicoes()
        {
            var mapper = _configurationMapper.CreateMapper();

            return mapper.Map<List<RequisicaoGetDTO>>(_requisicaoRepository.ObterTodasAsRequisicoes());
        }

        public Requisicao ObterRequisicaoPorId(int id)
        {
            return _requisicaoRepository.ObterRequisicaoPorId(id);
        }

        public RequisicaoGetDTO CriarRequisicao(RequisicaoPostDTO requisicao)
        {
            var requisicaoSalva = _requisicaoRepository.CriarRequisicao(
                new Requisicao
                {
                    ID_CLI = requisicao.ID_CLI,
                    TOTAL_REQ = requisicao.TOTAL_REQ,
                    QTD_ITEN = requisicao.QTD_ITEN,
                    DATA_REQ = requisicao.DATA_REQ,
                    ANO = requisicao.ANO,
                    MES = requisicao.MES,
                    ID_SEC = requisicao.ID_SEC,
                    ID_SET = requisicao.ID_SET,
                    OBSERVACAO = requisicao.OBSERVACAO
                });

            return new RequisicaoGetDTO
            {
                ID_CLI = requisicaoSalva.ID_CLI,
                TOTAL_REQ = requisicaoSalva.TOTAL_REQ,
                QTD_ITEN = requisicaoSalva.QTD_ITEN,
                DATA_REQ = requisicaoSalva.DATA_REQ,
                ANO = requisicaoSalva.ANO,
                MES = requisicaoSalva.MES,
                ID_SEC = requisicaoSalva.ID_SEC,
                ID_SET = requisicaoSalva.ID_SET,
                OBSERVACAO = requisicaoSalva.OBSERVACAO
            };
        }

        public RequisicaoGetDTO AtualizarRequisicao(RequisicaoPostDTO requisicaoDTO, int id)
        {
            var requisicaoSalva = _requisicaoRepository.AtualizarRequisicao(new Requisicao
            {
                ID_CLI = requisicaoDTO.ID_CLI,
                TOTAL_REQ = requisicaoDTO.TOTAL_REQ,
                QTD_ITEN = requisicaoDTO.QTD_ITEN,
                DATA_REQ = requisicaoDTO.DATA_REQ,
                ANO = requisicaoDTO.ANO,
                MES = requisicaoDTO.MES,
                ID_SEC = requisicaoDTO.ID_SEC,
                ID_SET = requisicaoDTO.ID_SET,
                OBSERVACAO = requisicaoDTO.OBSERVACAO
            }, id);

            return new RequisicaoGetDTO
            {
                ID_CLI = requisicaoSalva.ID_CLI,
                TOTAL_REQ = requisicaoSalva.TOTAL_REQ,
                QTD_ITEN = requisicaoSalva.QTD_ITEN,
                DATA_REQ = requisicaoSalva.DATA_REQ,
                ANO = requisicaoSalva.ANO,
                MES = requisicaoSalva.MES,
                ID_SEC = requisicaoSalva.ID_SEC,
                ID_SET = requisicaoSalva.ID_SET,
                OBSERVACAO = requisicaoSalva.OBSERVACAO
            };
        }

        public void DeletarRequisicao(int id)
        {
            _requisicaoRepository.DeletarRequisicao(id);
        }
    }
}
