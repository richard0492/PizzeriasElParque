using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Object;


namespace Data
{
    public class DataUser
    {

        string connectionString = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=pizzeriaelparque";


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

        public void InsertUser(User user)
        {
            string query = "CALL InsertarUsuario(@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", user.name);
                command.Parameters.AddWithValue("@P1", user.IDnumber);
                command.Parameters.AddWithValue("@P2", user.password);
                command.Parameters.AddWithValue("@P3", user.userType);
                command.Parameters.AddWithValue("@P4", user.firstStart);
                command.Parameters.AddWithValue("@P5", user.enabled);
                command.Parameters.AddWithValue("@P6", user.secondName);
                command.Parameters.AddWithValue("@P7", user.lastName1);
                command.Parameters.AddWithValue("@P8", user.lastName2);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteUser(int ID)
        {

            String dataBase = @"server=localhost; user id=root; password=root; database=pizzeriaelparque";


            string query = "CALL EliminarUsuario(@p0)";

            MySqlConnection user = new MySqlConnection(dataBase);


            using (MySqlCommand cmd = new MySqlCommand(query, user))
            {

                cmd.Parameters.AddWithValue("@p0", ID);

                user.Open();
                cmd.ExecuteNonQuery();
                user.Close();

            }
        }

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



