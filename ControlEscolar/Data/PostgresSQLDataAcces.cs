using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Npgsql;
using NLog;
using ControlEscolar.Utilities;
using System.Configuration;
using System.Data;


namespace ControlEscolar.Data
{
    public class PostgreSQLDataAccess
    {
        /// <summary>
        /// Clase q maneja el acceso a datos PostgreSQL incluyendo conexiones, consultas,
        /// y ejecucion de procedimientos almacenados
        /// </summary>
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PostgreSQLDataAccess");
        //cadena de conexion desde app.config
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        private NpgsqlConnection _connection;
        private static PostgreSQLDataAccess? _instance;

        private PostgreSQLDataAccess()
        {
            try
            {
                _connection = new NpgsqlConnection(_connectionString);
                _logger.Info("Instancia de acceso a datos creada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar el acceso a la base de datos");
                throw;
            }
        }

        public static PostgreSQLDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PostgreSQLDataAccess();
            }
            return _instance;
        }

        public NpgsqlParameter CreateParameter(string name, object value)
        {
            return new NpgsqlParameter(name, value ?? DBNull.Value);
        }

        public bool Connect()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                    _logger.Info("Conexión a la base de datos abierta");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al abrir la conexión a la base de datos");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    _logger.Info("Conexión a la base de datos cerrada");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al cerrar la conexión a la base de datos");
            }
        }

        public DataTable ExecuteQuery_Reader(string query, params NpgsqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                _logger.Debug($"Ejecutando consulta: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);//Es como el ExecuteReader
                        _logger.Debug("Consulta ejecutada correctamente");
                    }
                }
                _logger.Info("Consulta ejecutada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al ejecutar la consulta");
            }
            return dataTable;
        }
        private NpgsqlCommand CreateCommand(string query, NpgsqlParameter[] parameters)
        {
            NpgsqlCommand command = new NpgsqlCommand(query, _connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
                foreach (var param in parameters)
                {
                    _logger.Trace($"Parámetro: {param.ParameterName} = {param.Value ?? "NULL"}");
                }
            }
            return command;
        }

        public int ExecuteNonQuery(string query, params NpgsqlParameter[] parameters)
        {
            int rowsAffected = 0;
            try
            {
                _logger.Debug($"Ejecutando consulta: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    rowsAffected = command.ExecuteNonQuery();
                    _logger.Debug("Consulta ejecutada correctamente");
                }
                _logger.Info("Consulta ejecutada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al ejecutar la consulta");
            }
            return rowsAffected;
        }

        public object ExecuteScalar(string query, params NpgsqlParameter[] parameters)
        {
            object result = null;
            try
            {
                _logger.Debug($"Ejecutando consulta: {query}");
                using (NpgsqlCommand command = CreateCommand(query, parameters))
                {
                    result = command.ExecuteScalar();
                    _logger.Debug("Consulta ejecutada correctamente");
                }
                _logger.Info("Consulta ejecutada correctamente");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al ejecutar la consulta");
            }
            return result;
        }


    }
}
