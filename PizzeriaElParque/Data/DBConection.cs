using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data
{
    /// <summary>
    /// clase encargada de realizar la conección para la base de datos
    /// </summary>
    public class DBConection
    {
        string connectionString = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=pizzeriaelparque";

        /// <summary>
        /// Metodo encargado de crear la conección con la bas de datos
        /// </summary>
        /// <returns>Cadena de conección</returns>
        public MySqlConnection Connection() {
            return new MySqlConnection(connectionString);
        }

    }
}
