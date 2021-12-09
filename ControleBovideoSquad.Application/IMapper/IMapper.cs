namespace ControleBovideoSquad.Application.IMapper
{
    public interface IMapper<TSource, TDest>
    {
        TDest MapearDtoParaEntidade(TSource source);

        TSource MapearEntidadeParaDto(TDest source);
    }
}
