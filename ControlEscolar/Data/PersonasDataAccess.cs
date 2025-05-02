using Mposed;
using MposedTypes;
using MLog;
using ControlEscolar.Utilities;
using ControlEscolar.Model;
using ControlEscolar.Data;
using Npgsql;


namespace ControlEscolar.Data
{
    public class PersonasDataAccess
    {
        private static readonly Logger _Logger = LoggingManager.GetLogger("ControlEscolar.Data.PersonasDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;

        public PersonasDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch (Exception ex)
            {
                _Logger.Fatal(ex, "Error al inicializar PersonasDataAccess");
                throw;
            }
        }

        public int InsertarPersona(Persona persona)
        {
            try
            {
                string query = "INSERT INTO seguridad.personas (nombre_completo, correo, telefono, fecha_nacimiento, curp, estatus) " +
                               "VALUES (@NombreCompleto, @Correo, @Telefono, @FechaNacimiento, @Curp, @Estatus) " +
                               "RETURNING id";

                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramCorreo, paramTelefono,
                                                          paramFechaNac, paramCurp, paramEstatus);

                int idGenerado = Convert.ToInt32(resultado);
                _Logger.Info($"Persona insertada correctamente con ID: {idGenerado}");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al insertar la persona {persona.NombreCompleto}");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ExisteCurp(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM seguridad.personas WHERE curp = @Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", curp);
                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramCurp);
                int count = Convert.ToInt32(resultado);
                return count > 0;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al verificar la existencia del CURP: {curp}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                string query = "UPDATE seguridad.personas " +
                              "SET nombre_completo = @NombreCompleto, " +
                              "    correo = @Correo, " +
                              "    telefono = @Telefono, " +
                              "    fecha_nacimiento = @FechaNacimiento, " +
                              "    curp = @Curp, " +
                              "    estatus = @Estatus " +
                              "WHERE id = @Id";

                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", persona.Id);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                MngsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramCorreo,
                                                              paramTelefono, paramFechaNac, paramCurp, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _Logger.Info($"Persona con ID {persona.Id} actualizada correctamente");
                }
                else
                {
                    _Logger.Warn($"No se pudo actualizar la persona con ID {persona.Id}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al actualizar la persona con ID {persona.Id}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        private class MngsqlParameter
        {
        }
    }
}