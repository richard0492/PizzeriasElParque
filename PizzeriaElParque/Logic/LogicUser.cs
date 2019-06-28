using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Object;

namespace Logic
{
    public class LogicUser
    {

        DataUser dataUser = new DataUser();

        public void InsertUser(int IDnumber, String password, String name, int userType, string secondName, string lastName1, string lastName2)
        {

            User user = new User();


            //   if (ConsultUser(IDnumber.ToString()) == null)
            //  {
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

            //    return true;

            //  } else {

            //    return false;
            // }
        }


        public bool ModifyUser(int dnumber, string name, char enabled, int userType, string secondName, string lastName1, string lastName2)
        {
            dataUser.modifyUser(new User(dnumber, name, enabled, userType, secondName, lastName1, lastName2));
            return false;
        }

        public List<User> ConsultUsers()
        {
            List<User> users = new List<User>();

            DataUser listUser = new DataUser();

            users = listUser.ConsultUsers();

            return users;
        }

        public String ConsultUser(String IDUser)
        {
            String fullNombre = dataUser.ConsultUser(IDUser);
            return fullNombre;
        }

        public List<User> ConsultUsersList()
        {
            List<User> users = new List<User>();

            DataUser listUser = new DataUser();

            users = listUser.ConsultUsersList();

            return users;
        }


        public String ConsultUserModify(String IDUser)
        {
            String fullNombre = dataUser.ConsultUsersModify(IDUser);
            return fullNombre;
        }

        public void DeleteUser(int ID, char enabled)
        {
            dataUser.DeleteUser(ID, enabled);
        }

        public bool loginUser(int User_ID, String User_Name)
        {

            return false;
        }

        public string typeUser(int IDCard)
        {
            User typeUser = new User();

            DataUser type = new DataUser();

            typeUser = type.typeUser(IDCard);

            return typeUser.password + "/" + typeUser.userType;
        }

        public char firstS(int IDCard)
        {
            User firstS = new User();

            DataUser first = new DataUser();

            firstS = first.firstS(IDCard);

            return firstS.firstStart;
        }

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

