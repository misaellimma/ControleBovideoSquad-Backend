using ControleBovideoSquad.Application.IMapper;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.Domain.Entities;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Mapper.Vendas
{
    public class VendaMapper : IMapper<VendaDto, Venda>
    {
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;
        private readonly IRebanhoRepository _rebanhoRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;

        public VendaMapper(IFinalidadeDeVendaRepository finalidadeDeVendaRepository, IRebanhoRepository rebanhoRepository,
            IPropriedadeRepository propriedadeRepository)
        {
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
            _rebanhoRepository = rebanhoRepository;
            _propriedadeRepository = propriedadeRepository;
        }

        public Venda MapearDtoParaEntidade(VendaDto source)
        {
            var finalidadeDeVenda = _finalidadeDeVendaRepository.ObterPorId(source.IdFinalidadeDeVenda);
            var rebanho = _rebanhoRepository.ObterRebanhosPorId(source.IdRebanho);
            var propriedadeOrigem = _propriedadeRepository.ObterPorId(source.IdPropriedadeOrigem);
            var propriedadeDestino = _propriedadeRepository.ObterPorId(source.IdPropriedadeDestino);
            return new Venda(source.IdVenda, source.Quantidade, propriedadeOrigem,propriedadeDestino , rebanho,
                finalidadeDeVenda, source.DataDeVenda);
        }

        public VendaDto MapearEntidadeParaDto(Venda source)
        {
            throw new NotImplementedException();
        }
    }
}