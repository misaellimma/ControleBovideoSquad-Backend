﻿using ControleBovideoSquad.Application.IMapper.Vendas;
using ControleBovideoSquad.Application.IServices.Vendas;
using ControleBovideoSquad.CrossCutting;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.CrossCutting.Util;
using ControleBovideoSquad.Domain.Entities.Propriedades;
using ControleBovideoSquad.Domain.Entities.Animais;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IEspecieRepository _especieRepository;
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;
        private readonly IVendaMapper _vendaMapper;

        public VendaService(IVendaRepository vendaRepository, IEspecieRepository especieRepository,
            IFinalidadeDeVendaRepository finalidadeDeVendaRepository, IPropriedadeRepository propriedadeRepository,
            IVendaMapper vendaMapper, IRebanhoRepository rebanhoRepository)
        {
            _vendaRepository = vendaRepository;
            _rebanhoRepository = rebanhoRepository;
            _especieRepository = especieRepository;
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
            _propriedadeRepository = propriedadeRepository;
            _vendaMapper = vendaMapper;
        }

        public Venda ObterVendaPorId(int id)
        {
            return _vendaRepository.ObterVendaPorId(id);
        }

        public List<Venda> ObterVendaPorProdutor(string cpf)
        {
            return _vendaRepository.ObterVendaPorProdutor(cpf);
        }

        public List<Venda> ObterVendas()
        {
            return _vendaRepository.ObterVendas();
        }

        public Result<Venda> SalvarVenda(VendaDto vendaDto)
        {
            var response = ValidarVenda(vendaDto);

            if (response.Any())
                return Result<Venda>.Error(EStatusCode.BAD_REQUEST, response);

            Venda venda = _vendaMapper.MapearDtoParaEntidade(vendaDto);
            // Adicionar no rebanho da propriedade de destino e tirar do rebanho da propriedade de origem;
            Rebanho rebanhoNaOrigem = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeOrigem.InscricaoEstadual, venda.Especie.IdEspecie);
            rebanhoNaOrigem.DebitarNoRebanho(vendaDto.Quantidade, vendaDto.Quantidade);
            _rebanhoRepository.Salvar(rebanhoNaOrigem);

            Rebanho rebanhoNoDestino = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeDestino.InscricaoEstadual, 
                venda.Especie.IdEspecie);

            if (rebanhoNoDestino == null)
                _rebanhoRepository.Salvar(new Rebanho(0, vendaDto.Quantidade, vendaDto.Quantidade, vendaDto.Quantidade
                    , venda.Especie, venda.PropriedadeDestino));
            else 
                rebanhoNoDestino.AdicionarNoRebanho(vendaDto.Quantidade, vendaDto.Quantidade);
                _rebanhoRepository.Salvar(rebanhoNoDestino);
        
            _vendaRepository.Save(venda);

            return Result<Venda>.Success(venda);
        }

        public string CancelarVenda(int id)
        {
            Venda venda = _vendaRepository.ObterVendaPorId(id);

            if (venda == null)
                return "venda nao encontrada";
            if (venda.Ativo == false)
                return "essa venda ja esta inativa";
            
            venda.CancelarVenda();
            // Creditar de volta na propriedade de origem
            Rebanho rebanhoNaOrigem = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeOrigem.InscricaoEstadual, venda.Especie.IdEspecie);
            rebanhoNaOrigem.AdicionarNoRebanho(venda.Quantidade, venda.Quantidade);
            _rebanhoRepository.Salvar(rebanhoNaOrigem);
            // Debitar da propriedade de destino
            Rebanho rebanhoNoDestino = _rebanhoRepository.ObterPorPropriedadeEEspecie(venda.PropriedadeDestino.InscricaoEstadual, venda.Especie.IdEspecie);
            rebanhoNoDestino.DebitarNoRebanho(venda.Quantidade, venda.Quantidade);
            _rebanhoRepository.Salvar(rebanhoNaOrigem);

            _vendaRepository.Save(venda);
            return "venda cancelada";
        }

        public List<string> ValidarVenda(VendaDto vendaDto)
        {
            List<string> errors = new List<string>();
            Propriedade propriedadeOrigem = _propriedadeRepository.ObterPorId(vendaDto.IdPropriedadeOrigem);
            Propriedade propriedadeDestino = _propriedadeRepository.ObterPorId(vendaDto.IdPropriedadeDestino);
            Rebanho rebanho = _rebanhoRepository.ObterPorPropriedadeEEspecie(propriedadeOrigem.InscricaoEstadual, vendaDto.IdEspecie);
            FinalidadeDeVenda finalidade = _finalidadeDeVendaRepository.ObterPorId(vendaDto.IdFinalidadeDeVenda);
            // verificar se existe propriedade origem e destino
            // verificar na propriedade origem se tem rebanho vacinado disponivel

            if (finalidade == null)
                errors.Add("Finalidade de venda nao encontrada");

            if(propriedadeOrigem == null)
                errors.Add("Propriedade de origem nao encontrada");

            if(propriedadeDestino == null)
                errors.Add("Propriedade de destino nao encontrada");

            if (rebanho == null) {
                errors.Add("Rebanho nao encontrado");
            }
            else {
                Console.Write(rebanho.QuantidadeTotal);
                if (rebanho.QuantidadeVacinadaAftosa < vendaDto.Quantidade || rebanho.QuantidadeVacinadaBrucelose < vendaDto.Quantidade)
                    errors.Add("Numero insuficiente de rebanhos vacinados");
            }

            return errors;
        }
    }
}
