using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Validators
{
    public interface IValidator<T>
    {
        public List<string> IsValid(T value);
        public List<string> errors {get;}
    }
}
