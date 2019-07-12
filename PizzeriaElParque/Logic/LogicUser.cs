using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Object;

namespace Logic
{
    /// <summary>
    /// Clase encargada del manejo logico de usuarios
    /// </summary>
    public class LogicUser
    {

        DataUser dataUser = new DataUser();

        /// <summary>
        /// Metodo encargado de enviar un usuario a la capa de datos para insertar
        /// </summary>
        /// <param name="IDnumber">Identificador de usuario</param>
        /// <param name="password">Contraseña de usuario</param>
        /// <param name="name">Nombre de usuario</param>
        /// <param name="userType">Rol de usuario</param>
        /// <param name="secondName">Segundo nombre de usuario</param>
        /// <param name="lastName1">Primer apellido</param>
        /// <param name="lastName2">Segundo apellido</param>
        public void InsertUser(int IDnumber, String password, String name, int userType, string secondName, string lastName1, string lastName2)
        {

            User user = new User();


         
            user.IDnumber = IDnumber;
            user.password = password;
            user.name = name;
            user.enabled = 's';
            user.userType = userType;
            if (secondName == null || secondName == " ")
            {
                user.secondName = "N/A";
            }
            user.secondName = secondName;
            user.lastName1 = lastName1;
            user.lastName2 = lastName2;
            user.firstStart = 's';
            dataUser.InsertUser(user);

          
        }

        /// <summary>
        /// Metodo encargado de enviar los datos de un usuario a la capa de datos para modificar los datos en la base de datos
        /// </summary>
        /// <param name="dnumber">Identificador de usuario</param>
        /// <param name="name">Nombre de usuario</param>
        /// <param name="enabled">Verificador para habilitar usuario</param>
        /// <param name="userType">Rol de usuario</param>
        /// <param name="secondName">Segundo nombre de usuario</param>
        /// <param name="lastName1">Primer apellido</param>
        /// <param name="lastName2">Segundo apellido</param>
        /// <returns></returns>
        public bool ModifyUser(int dnumber, string name, char enabled, int userType, string secondName, string lastName1, string lastName2)
        {
            dataUser.modifyUser(new User(dnumber, name, enabled, userType, secondName, lastName1, lastName2));
            return false;
        }

        /// <summary>
        /// Metodo encargado de consultar a la capa de datos
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        ///
        public List<User> ConsultUsers()
        {
            List<User> users = new List<User>();

            DataUser listUser = new DataUser();

            users = listUser.ConsultUsers();

            return users;
        }

        /// <summary>
        /// Metodo encargado de consultar un usuario en la capa de datos
        /// </summary>
        /// <param name="IDUser">Identificador de usuario</param>
        /// <returns>Nombre completo de usuario</returns>
        public String ConsultUser(String IDUser)
        {
            String fullNombre = dataUser.ConsultUser(IDUser);
            return fullNombre;
        }

        /// <summary>
        /// Metodo encargado de consultar a la capa de datos usuarios 
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        /// 
        public List<User> ConsultUsersList()
        {
            List<User> users = new List<User>();

            DataUser listUser = new DataUser();

            users = listUser.ConsultUsersList();

            return users;
        }

        /// <summary>
        /// Metodo encargado de consultar a la capa de datos un usuario mediante su identificación
        /// </summary>
        /// <param name="IDUser"> Identificacion de usuario</param>
        /// <returns>Nombre completo de usuario</returns>
        public String ConsultUserModify(String IDUser)
        {
            String fullNombre = dataUser.ConsultUsersModify(IDUser);
            return fullNombre;
        }

        /// <summary>
        /// Metodo encargado de enviar la información a la capa de datos para dehabiñitar un usuario
        /// </summary>
        /// <param name="ID">Identificador de usuario</param>
        /// <param name="enabled">Verificador para deshabilitar un usuario</param>
        public void DeleteUser(int ID, char enabled)
        {
            dataUser.DeleteUser(ID, enabled);
        }

        /// <summary>
        /// Metodo encargado de verificra si existe el usuario para permitir su ingreso
        /// </summary>
        /// <param name="User_ID">Identificador de usuario</param>
        /// <param name="User_Name">Contrasena de usuario</param>
        /// <returns>Verdadero o falso</returns>
        public bool loginUser(int User_ID, String User_Name)
        {

            return false;
        }

        /// <summary>
        /// Metodo encargado de consulta a la capa de datos el tipo de usuario que esta ingresando al sistema
        /// </summary>
        /// <param name="IDCard">Identificación de usuario</param>
        /// <returns>usuario</returns>
        public string typeUser(int IDCard)
        {
            User typeUser = new User();

            DataUser type = new DataUser();

            typeUser = type.typeUser(IDCard);

            return typeUser.password + "/" + typeUser.userType;
        }

        /// <summary>
        /// metodo encargado de de verificra en la capa de datos si es el primer ingreso del usuario
        /// </summary>
        /// <param name="IDCard">Identificador de usuario</param>
        /// <returns>Usario</returns>
        public char firstS(int IDCard)
        {
            User firstS = new User();

            DataUser first = new DataUser();

            firstS = first.firstS(IDCard);

            return firstS.firstStart;
        }

        /// <summary>
        ///  Metodo encargado de enviar la información a la capa de datos para modificar la contraseña de usuario
        /// </summary>
        /// <param name="IDCard">Identificador de usario</param>
        /// <param name="password">Contraseña de usuario</param>
        /// <param name="firstStart">Verificador de primer ingreso de usuario</param>
        /// <returns>verdadero o falso</returns>
        public Boolean modifyPassword(int IDCard, string password, char firstStart)
        {

            
                DataUser modify = new DataUser();

            if (modify.modifyPassword(IDCard, password, firstStart) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

