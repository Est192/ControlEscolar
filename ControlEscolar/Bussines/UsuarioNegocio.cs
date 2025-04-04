using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolar.Utilities;

namespace ControlEscolar.Bussines
{
    internal class UsuarioNegocio
    {
        public static bool EsFormatoValido(string correo)
        {
            return Validaciones.EsCorreoValido(correo); // llamar a utilities
        }
    }
}
