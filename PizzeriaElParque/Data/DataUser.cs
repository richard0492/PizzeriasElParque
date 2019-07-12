using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Object;


namespace Data
{
/// <summary>
///Clasa encargada del manejo de datos de usuario 
/// </summary>

 
  public class DataUser
    {

        string connectionString = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=pizzeriaelparque";

        /// <summary>
        /// Metodo encargado de consultar a la base de datos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// 
        public List<User> ConsultUsers()
        {
            List<User> users = new List<User>();

            string query = "Call ConsultarNombre()";

            DBConection connection = new DBConection();


            connection.Connection().Open();

            MySqlDataAdapter commandDatabase = new MySqlDataAdapter(query, connection.Connection());

            DataSet dataSet = new DataSet();

            commandDatabase.Fill(dataSet, "User");

            foreach (DataTable tabla in dataSet.Tables)
            {
                foreach (DataRow dr in tabla.Rows)
                {
                    User user = new User(Int32.Parse(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString());

                    users.Add(user);
                }
            }

            connection.Connection().Close();

            return users;

        }
       
        /// <summary>
        /// Metodo encargado de consultar a la base de datos los usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// 
        public List<User> ConsultUsersList()
        {
            List<User> users = new List<User>();

            string query = "Call ConsultarListaUsuarios()";

            DBConection connection = new DBConection();


            connection.Connection().Open();

            MySqlDataAdapter commandDatabase = new MySqlDataAdapter(query, connection.Connection());

            DataSet dataSet = new DataSet();

            commandDatabase.Fill(dataSet, "User");

            foreach (DataTable tabla in dataSet.Tables)
            {
                foreach (DataRow dr in tabla.Rows)
                {
                    User user = new User(Int32.Parse(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), dr.ItemArray[5].ToString());

                    users.Add(user);
                }
            }

            connection.Connection().Close();

            return users;

        }

        /// <summary>
        /// Metodo encargado de consultar a la base de datos un usuario mediante su identificacion
        /// </summary>
        /// <param name="ID"> Identificacion de usuario</param>
        /// <returns>Nombre completo de usuario</returns>
        public String ConsultUsersModify(string ID)
        {

            User user = null;

            MySqlConnection connectionUser = new MySqlConnection(connectionString);

            string query = "CALL ConsultarNombreModificar(@p0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionUser))
            {
                cmd.Parameters.AddWithValue("@p0", Int32.Parse(ID));

                connectionUser.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       user = new User(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

                    }
                }
                connectionUser.Close();
            }

            return user.fullName;

        }

        /// <summary>
        /// Metodo encargado de consulta a la base de datos el tipo de usuario que esta ingresando al sistema
        /// </summary>
        /// <param name="IDCard">Identificación de usuario</param>
        /// <returns>usuario</returns>
        public User typeUser(int IDCard)
        {

            User user = null;

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = "CALL ConsultarTipo(@p0)";

        using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@p0", IDCard);

                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        user = new User(reader[0].ToString(), Int32.Parse(reader[1].ToString()));
                }
                connection.Close();
            }

            return user;
        }

        /// <summary>
        /// metodo encargado de de verificra en la base de datos si es el primer ingreso del usuario
        /// </summary>
        /// <param name="IDCard">Identificador de usuario</param>
        /// <returns>Usario</returns>
        public User firstS(int IDCard)
        {

            User user = null;

            MySqlConnection connection = new MySqlConnection(connectionString);

            string query = "CALL ConsultarPrimerInicio(@p0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@p0", IDCard);

                connection.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        user = new User(Char.Parse(reader[0].ToString()));
                }
                connection.Close();
            }

            return user;
        }
        
        /// <summary>
        ///  Metodo encargado de modificar la contraseña de usuario
        /// </summary>
        /// <param name="IDCard">Identificador de usario</param>
        /// <param name="password">Contraseña de usuario</param>
        /// <param name="firstStart">Verificador de primer ingreso de usuario</param>
        /// <returns>verdadero o falso</returns>
        public Boolean modifyPassword(int IDCard, string password, char firstStart) {

            string query = "CALL ModificarContraseñaUsuario(@P0,@P1,@P2)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", password);
                command.Parameters.AddWithValue("@P1", IDCard);
                command.Parameters.AddWithValue("@P2", firstStart);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            return false;

        }
        
        /// <summary>
        /// Metodo encargado modificar los datos de un unsiario en la base de datos
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <returns>Verdadero o falso</returns>
        public Boolean modifyUser(User user)
        {

            string query = "CALL ModificarUsuario(@P0,@P1,@P2,@P3,@P4,@P5,@P6)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", user.name);
                command.Parameters.AddWithValue("@P1", user.userType);
                command.Parameters.AddWithValue("@P2", user.enabled);
                command.Parameters.AddWithValue("@P3", user.IDnumber);
                command.Parameters.AddWithValue("@P4", user.secondName);
                command.Parameters.AddWithValue("@P5", user.lastName1);
                command.Parameters.AddWithValue("@P6", user.lastName2);
                
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            return false;

        }

        /// <summary>
        /// Metodo encargado de insertar un usuario en la base de datos
        /// </summary>
        /// <param name="user">Usuario</param>
        public void InsertUser(User user)
        {
            string query = "CALL InsertarUsuario(@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", user.name);
                command.Parameters.AddWithValue("@P1", user.IDnumber);
                command.Parameters.AddWithValue("@P2", user.userType);
                command.Parameters.AddWithValue("@P3", user.firstStart);
                command.Parameters.AddWithValue("@P4", user.enabled);
                command.Parameters.AddWithValue("@P5", user.secondName);
                command.Parameters.AddWithValue("@P6", user.lastName1);
                command.Parameters.AddWithValue("@P7", user.lastName2);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// Metodo encargado de deshabilitar un usario en la base de datos
        /// </summary>
        /// <param name="user_ID">Identificador de usuario</param>
        /// <param name="enabled">Verificador para deshabilitar un usuario</param>
        public void DeleteUser(int user_ID, char enabled)
        {
            string query = "CALL ModificarHabilitadoUsuario(@p0,@p1)";

            MySqlConnection product = new MySqlConnection(connectionString);


            using (MySqlCommand cmd = new MySqlCommand(query, product))
            {

                cmd.Parameters.AddWithValue("@p0", enabled);
                cmd.Parameters.AddWithValue("@p1", user_ID);
                product.Open();
                cmd.ExecuteNonQuery();
                product.Close();
            }
        }
        
        /// <summary>
        /// Metodo encargado de consultar un usuario en la base de datos
        /// </summary>
        /// <param name="ID">Identificador de usuario</param>
        /// <returns>Nombre completo de usuario</returns>
        public String ConsultUser(String ID)
        {

            User user = null;

            MySqlConnection connectionUser = new MySqlConnection(connectionString);

            string query = "CALL ConsultarUsuario(@p0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionUser))
            {
                cmd.Parameters.AddWithValue("@p0", Int32.Parse(ID));

                connectionUser.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        user = new User(Int32.Parse(reader[0].ToString()), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                }
                connectionUser.Close();
            }

            return user.fullName;
        }
    }



}



