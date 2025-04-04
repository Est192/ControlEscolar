using Mposed;
using MposedTypes;
using MLog;
using ControlEscolar.Utilities;
using ControlEscolar.Model;

namespace ControlEscolar.Data
{
    public class EstudiantesDataAccess
    {
        private static readonly Logger _Logger = LoggingManager.GetLogger("ControlEscolar.Data.EstudiantesDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly PersonasDataAccess _personasData;

        public EstudiantesDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _personasData = new PersonasDataAccess();
            }
            catch (Exception ex)
            {
                _Logger.Fatal(ex, "Error al inicializar EstudiantesDataAccess");
                throw;
            }
        }

        public int InsertarEstudiante(Estudiante estudiante)
        {
            try
            {
                int idPersona = _personasData.InsertarPersona(estudiante.DatosPersonales);
                if (idPersona <= 0)
                {
                    _Logger.Error($"No se pudo insertar la persona para el estudiante {estudiante.Matricula}");
                    return -1;
                }

                estudiante.IdPersona = idPersona;

                string query = @"INSERT INTO escolar.estudiantes (id_persona, matricula, semestre, fecha_alta, estatus)
                                VALUES (@IdPersona, @Matricula, @Semestre, @FechaAlta, @Estatus)
                                RETURNING id";

                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", estudiante.IdPersona);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);

                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdPersona, paramMatricula,
                                                          paramSemestre, paramFechaAlta, paramEstatus);

                int idEstudianteGenerado = Convert.ToInt32(resultado);
                _Logger.Info($"Estudiante insertado correctamente con ID: {idEstudianteGenerado}");
                return idEstudianteGenerado;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al insertar el estudiante con matricula {estudiante.Matricula}");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ExisteMatricula(string matricula)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM escolar.estudiantes WHERE matricula = @Matricula";
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", matricula);
                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramMatricula);
                int cantidad = Convert.ToInt32(resultado);
                bool existe = cantidad > 0;
                return existe;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al verificar la existencia de la matricula {matricula}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public Estudiante? ObtenerEstudiantePorId(int id)
        {
            try
            {
                string query = @"SELECT e.id, e.matricula, e.semestre, e.fecha_alta, e.fecha_baja, e.estatus,
                               e.id_persona, p.nombre_completo, p.correo, p.telefono, p.fecha_nacimiento, p.curp, p.estatus as estatus_persona
                               FROM escolar.estudiantes e
                               INNER JOIN seguridad.personas p ON e.id_persona = p.id
                               WHERE e.id = @Id";

                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", id);
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQueryReader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _Logger.Warn($"No se encontró ningún estudiante con ID {id}");
                    return null;
                }

                DataRow row = resultado.Rows[0];

                Persona persona = new Persona(
                    Convert.ToInt32(row["id_persona"]),
                    row["nombre_completo"].ToString() ?? "",
                    row["correo"].ToString() ?? "",
                    row["telefono"].ToString() ?? "",
                    row["curp"].ToString() ?? "",
                    row["fecha_nacimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_nacimiento"]) : null,
                    Convert.ToBoolean(row["estatus_persona"])
                );

                Estudiante estudiante = new Estudiante(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["matricula"].ToString() ?? "",
                    row["semestre"].ToString() ?? "",
                    Convert.ToDateTime(row["fecha_alta"]),
                    row["fecha_baja"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["fecha_baja"]) : null,
                    Convert.ToInt32(row["estatus"]),
                    row["descstatus_estudiante"].ToString() ?? "Desconocido",
                    persona
                );

                return estudiante;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al obtener el estudiante con ID {id}");
                return null;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                _Logger.Debug($"Actualizando estudiante con ID {estudiante.Id} y persona con ID {estudiante.IdPersona}");

                bool actualizacionPersonaExitosa = _personasData.ActualizarPersona(estudiante.DatosPersonales);
                if (!actualizacionPersonaExitosa)
                {
                    _Logger.Warn($"No se pudo actualizar la persona con ID {estudiante.IdPersona}");
                    return false;
                }

                string queryEstudiante = @"UPDATE escolar.estudiantes
                                         SET matricula = @Matricula,
                                         semestre = @Semestre,
                                         fecha_alta = @FechaAlta,
                                         estatus = @Estatus,
                                         fecha_baja = @FechaBaja
                                         WHERE id = @IdEstudiante";

                _dbAccess.Connect();

                NpgsqlParameter paramIdEstudiante = _dbAccess.CreateParameter("@IdEstudiante", estudiante.Id);
                NpgsqlParameter paramMatricula = _dbAccess.CreateParameter("@Matricula", estudiante.Matricula);
                NpgsqlParameter paramSemestre = _dbAccess.CreateParameter("@Semestre", estudiante.Semestre);
                NpgsqlParameter paramFechaAlta = _dbAccess.CreateParameter("@FechaAlta", estudiante.FechaAlta);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estudiante.Estatus);
                NpgsqlParameter paramFechaBaja = _dbAccess.CreateParameter("@FechaBaja",
                    estudiante.FechaBaja.HasValue ? (object)estudiante.FechaBaja.Value : DBNull.Value);

                int filasAfectadasEstudiante = _dbAccess.ExecuteNonQuery(queryEstudiante,
                    paramIdEstudiante, paramMatricula, paramSemestre,
                    paramFechaAlta, paramEstatus, paramFechaBaja);

                bool exito = filasAfectadasEstudiante > 0;

                if (!exito)
                {
                    _Logger.Warn($"No se pudo actualizar el estudiante con ID {estudiante.Id}. No se encontró el registro");
                }
                else
                {
                    _Logger.Debug($"Estudiante con ID {estudiante.Id} actualizado correctamente");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al actualizar el estudiante con ID {estudiante.Id}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }
}
