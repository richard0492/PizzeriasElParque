using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data
{
    public class DBConection
    {
        string connectionString = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=pizzeriaelparque";

        public MySqlConnection Connection() {
            return new MySqlConnection(connectionString);
        }

    }
}
