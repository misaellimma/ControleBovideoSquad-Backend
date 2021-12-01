using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting
{
    public enum EStatusCode
    {
        OK = 200,
        BAD_REQUEST = 400,
        NOT_FOUND = 404,
        NO_CONTENT = 204,
        INTERNAL_SERVER_ERROR = 500
    }
}
