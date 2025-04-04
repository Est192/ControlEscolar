using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using ControlEscolar.Data;
using ControlEscolar.Model;
using ControlEscolar.Utilities;

namespace ControlEscolar.Controler
{
    class EstudiantesController
    {
        public List<Estudiante> ObtenerEstudiantes(bool soloActivos = true, int tipoFecha = 0,
                                                            DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            try
            {
                //Obtener datos de la capa de acceso de datos
                var estudiantes = estudiantesData.OptenerTodosLosEstudiantes(soloActivos, tipoFecha, fechaInicio, fechaFin);
                _logger.Info("Se obtuvieron {estudiantes.Count} estudiantes");
                return estudiantes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los estudiantes");
                throw; // Propagar la excepción para que sea manejada en la capa superior
            }
            return estudiantes;
        }
    }
}
