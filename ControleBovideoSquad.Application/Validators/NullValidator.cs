using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.Application.Validators
{
    public class NullValidator<T> : IValidator<T>
    {
        public NullValidator(){
            errors = new List<string>();
        }

        public List<string> errors { get; }

        public List<string> IsValid(T value)
        {
            foreach (var item in value.GetType().GetProperties()){
                               
                if (item.GetValue(value).ToString() == null || 
                    item.GetValue(value).ToString() == ""
                    )
                {                
                    errors.Add($"{item.Name} não pode ser Nulo");
                }
            }

            return errors;
        }
    }
}
