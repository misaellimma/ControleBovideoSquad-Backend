using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.IMapper
{
    public interface IMapper<TSource, TDest>
    {
        TDest MapearDtoParaEntidade(TSource source);

        TSource MapearEntidadeParaDto(TDest source);
    }
}
