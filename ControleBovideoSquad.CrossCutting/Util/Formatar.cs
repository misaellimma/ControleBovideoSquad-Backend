using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Util
{
    public static class Formatar
    {
        public static string FormatarString(string str)
        {
            str = str.Trim();
            return str.Replace(".", "").Replace("-", "");
        }
    }
}
