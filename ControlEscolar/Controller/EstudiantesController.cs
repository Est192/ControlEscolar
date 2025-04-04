using Mposed;
using MposedTypes;
using MLog;
using ControlEscolar.Utilities;
using ControlEscolar.Model;
using ControlEscolar.Data;

namespace ControlEscolar.Controller
{
    public class EstudiantesController
    {
        private static readonly Logger _Logger = LoggingManager.GetLogger("ControlEscolar.Controller.EstudiantesController");
        private readonly EstudiantesDataAccess _estudiantesData;
        private readonly PersonasDataAccess _personasData;

        public EstudiantesController()
        {
            _estudiantesData = new EstudiantesDataAccess();
            _personasData = new PersonasDataAccess();
        }

        public (int id, string mensaje) RegistrarEstudiante(Estudiante estudiante)
        {
            try
            {
                if (_estudiantesData.ExisteMatricula(estudiante.Matricula))
                {
                    _Logger.Warn($"Intento de registrar estudiante con matrícula duplicada: {estudiante.Matricula}");
                    return (-2, $"La matrícula {estudiante.Matricula} ya está registrada en el sistema");
                }

                if (_personasData.ExisteCurp(estudiante.DatosPersonales.Curp))
                {
                    _Logger.Warn($"Intento de registrar estudiante con CURP duplicado: {estudiante.DatosPersonales.Curp}");
                    return (-3, $"El CURP {estudiante.DatosPersonales.Curp} ya está registrado en el sistema");
                }

                _Logger.Info($"Registrando nuevo estudiante: {estudiante.DatosPersonales.NombreCompleto}, Matrícula: {estudiante.Matricula}");
                int idEstudiante = _estudiantesData.InsertarEstudiante(estudiante);

                if (idEstudiante <= 0)
                {
                    return (-4, "Error al registrar el estudiante en la base de datos");
                }

                _Logger.Info($"Estudiante registrado exitosamente con ID: {idEstudiante}");
                return (idEstudiante, "Estudiante registrado exitosamente");
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al registrar estudiante: {estudiante.DatosPersonales?.NombreCompleto ?? "Sin nombre"}, Matrícula: {estudiante.Matricula}");
                return (-1, $"Error inesperado: {ex.Message}");
            }
        }

        public Estudiante? ObtenerDetalleEstudiante(int idEstudiante)
        {
            try
            {
                _Logger.Debug($"Solicitando detalle del estudiante con ID: {idEstudiante}");
                return _estudiantesData.ObtenerEstudiantePorId(idEstudiante);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al obtener detalles del estudiante con ID: {idEstudiante}");
                throw;
            }
        }

        public (bool exito, string mensaje) ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                if (estudiante == null)
                {
                    return (false, "No se proporcionaron datos del estudiante");
                }
                if (estudiante.Id <= 0)
                {
                    return (false, "ID de estudiante no válido");
                }
                if (estudiante.DatosPersonales == null)
                {
                    return (false, "No se proporcionaron los datos personales del estudiante");
                }

                Estudiante? estudianteExistente = _estudiantesData.ObtenerEstudiantePorId(estudiante.Id);
                if (estudianteExistente == null)
                {
                    return (false, $"No se encontró el estudiante con ID {estudiante.Id}");
                }

                if (estudiante.Matricula != estudianteExistente.Matricula &&
                    _estudiantesData.ExisteMatricula(estudiante.Matricula))
                {
                    return (false, $"La matrícula {estudiante.Matricula} ya está registrada en el sistema");
                }

                if (estudiante.DatosPersonales.Curp != estudianteExistente.DatosPersonales.Curp)
                {
                    bool personaConMismoCurp = _personasData.ExisteCurp(estudiante.DatosPersonales.Curp);
                    if (personaConMismoCurp)
                    {
                        return (false, $"El CURP {estudiante.DatosPersonales.Curp} ya está registrado para otra persona");
                    }
                }

                _Logger.Info($"Actualizando estudiante con ID: {estudiante.Id}, Nombre: {estudiante.DatosPersonales.NombreCompleto}");
                bool resultado = _estudiantesData.ActualizarEstudiante(estudiante);

                if (!resultado)
                {
                    _Logger.Error($"Error al actualizar el estudiante con ID {estudiante.Id}");
                    return (false, "Error al actualizar el estudiante en la base de datos");
                }

                _Logger.Info($"Estudiante con ID {estudiante.Id} actualizado exitosamente");
                return (true, "Estudiante actualizado exitosamente");
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al actualizar estudiante con ID: {estudiante.Id}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
    }
}
