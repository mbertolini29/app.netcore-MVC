using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAP_NetCoreApp.Models.Queries
{
    public class BaseQuery
    {
        /// <summary
        /// Guardar la cadena de conexion internamente para todas las llamadas a DB
        /// </summary
        internal string connectionString;

        /// <summary
        /// Constructor
        /// </summary
        public BaseQuery()
        {
            connectionString = Environment.GetEnvironmentVariable("VAP_Demo_ConnStr");
        }

        /// <summary
        /// Obtener la cadena de conexion
        /// </summary
        /// <returns>SqlConnection</returns>
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public class BaseResult
        {
            /// <summary
            /// Tiene el valor de si fue exitoso el proceso en la DB
            /// </summary
            public bool Success { get; set; }

            /// <summary
            /// Mensaje de error si es que existiera alguno
            /// </summary
            public string Message { get; set; }

            /// <summary
            /// ID del objecto recien creado
            /// </summary
            public int ObjectID { get; set; }
        }
    }
}
