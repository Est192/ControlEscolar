using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using ControlEscolar.Utilities;
using ControlEscolar.Model;
using NLog;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Reflection;
using System.Windows.Forms;


namespace ControlEscolar.Data
{
    class EstudiantesDataAccess
    {
        //Logger para esta clase
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.EstudiantesDataAccess");

        //Instancia de la clase de acceso a datos PostgreSQL
        private readonly PostgreSQLDataAccess _dbAccess;

        //Instancia de la clase para manejo de personas
        private readonly PersonasDataAccess _personasData;

        /// <summary>
        /// Constructor de la clase estudiantes
        /// </summary>
        public EstudiantesDataAccess()
        {
            try
            {
                //Obtiene la instancia unica de PostgreSQLDataAccess (patron singleton)
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                //Instancia el acceso a datos de personas para operaciones relacionadas
                _personasData = new PersonasDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar EstudiantesDataAccess");
                throw;
            }
        }


        public List<Estudiante> ObtenerTodosLosEstudiantes(bool soloActivos = true, int tipoFecha = 0,
                                                            DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            try
            {
                string query = "SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,\r\n     CASE\r\n\t  WHEN e.estatus = 0 THEN 'Baja'\r\n\t  WHEN e.estatus = 1 THEN 'Activo'\r\n\t  WHEN e.estatus = 2 THEN 'Temporal'\r\n\t ELSE\r\n         'Desconocido'\r\n\t END AS descestatus_estudiante,\r\n\t e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona\r\nFROM escolar.estudiantes e\r\nINNER JOIN seguridad.personas p ON e.id_persona = p.id\r\nWHERE 1=1";


                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener los estudiantes de la base de datos");
                throw; //Returna lista vacia en caso de error
            }
            finally
            {
                //Cerramos la conexion a la base de datos
                _dbAccess.Disconnect();
            }
        }
    }

}

