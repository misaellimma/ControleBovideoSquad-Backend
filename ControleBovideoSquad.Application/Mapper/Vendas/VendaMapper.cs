using ControleBovideoSquad.Application.IMapper.Vendas;
using ControleBovideoSquad.CrossCutting.Dto.Vendas;
using ControleBovideoSquad.Domain.Entities.Vendas;
using ControleBovideoSquad.Domain.Repositories.Animais;
using ControleBovideoSquad.Domain.Repositories.Propriedades;
using ControleBovideoSquad.Domain.Repositories.Vendas;

namespace ControleBovideoSquad.Application.Mapper.Vendas
{
    public class VendaMapper : IVendaMapper
    {
        private readonly IFinalidadeDeVendaRepository _finalidadeDeVendaRepository;
        private readonly IEspecieRepository _especieRepository;
        private readonly IPropriedadeRepository _propriedadeRepository;

        public VendaMapper(IFinalidadeDeVendaRepository finalidadeDeVendaRepository, IEspecieRepository especieRepository,
            IPropriedadeRepository propriedadeRepository)
        {
            _finalidadeDeVendaRepository = finalidadeDeVendaRepository;
            _especieRepository = especieRepository;
            _propriedadeRepository = propriedadeRepository;
        }

        public Venda MapearDtoParaEntidade(VendaDto source)
        {
            Console.Write($"flag de venda: {source.DataDeVenda}");
            var finalidadeDeVenda = _finalidadeDeVendaRepository.ObterPorId(source.IdFinalidadeDeVenda);
            var especie = _especieRepository.ObterPorId(source.IdEspecie);
            var propriedadeOrigem = _propriedadeRepository.ObterPorId(source.IdPropriedadeOrigem);
            var propriedadeDestino = _propriedadeRepository.ObterPorId(source.IdPropriedadeDestino);
            return new Venda(0, source.Quantidade, propriedadeOrigem, propriedadeDestino, especie,
                finalidadeDeVenda, source.DataDeVenda);
        }

        public VendaDto MapearEntidadeParaDto(Venda source)
        {
            throw new NotImplementedException();
        }
    }
}