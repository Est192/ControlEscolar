using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolar.Utilities;

namespace ControlEscolar.Bussines
{
    class EstudiantesNegocio
    {
        internal static bool EsCorreoValido(string correo)
        {
            return Validaciones.EsCorreoValido(correo);
        }

        internal static bool EsCURPValido(string curp)
        {
            return Validaciones.EsCURPValido(curp);
        }

        internal static bool EsNoControlValido(string noControl)
        {
            string patron = @"^(T|M)-\d{4}-\d{3,5}$";
            return System.Text.RegularExpressions.Regex.IsMatch(noControl, patron);
        }

        /// <summary>
        /// Valida si el numero de control es valido
        /// Ejemplos validos: T-2021-1234, M-2021-1234
        /// Ejemplos no validos: X-2021-1234, T-21-1234, T-2021-12345
        /// 


    }
}
