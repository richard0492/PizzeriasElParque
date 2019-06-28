using System;
using System.Collections.Generic;
using System.Text;

namespace Object
{
    public class User
    {
        public int IDnumber { set; get; }
        public string password { set; get; }
        public string name { set; get; }
        public char firstStart { set; get; }
        public char enabled { set; get; }
        public int userType { set; get; }
        public string secondName { set; get; }
        public string lastName1 { set; get; }
        public string lastName2 { set; get; }
        public string fullName { set; get; }
        public string nameType { set; get; }

        public User()
        {
        }

        public User(string name)
        {
            this.name = name;
        }

        public User(int dnumber, string name, string secondName, string lastName1, string lastName2, string nameType)
        {
            IDnumber = dnumber;
            this.name = name;
            this.secondName = secondName;
            this.lastName1 = lastName1;
            this.lastName2 = lastName2;
            this.nameType = nameType;
            this.fullName = this.IDnumber + " / " + this.name + " / " + this.secondName + " / " + this.lastName1 + " / " + this.lastName2 + " / " + this.nameType;
        }

        public User(int IDnumber, string name, string secondName, string lastName1, string lastName2)
        {
            if (secondName == "")
            {
                this.IDnumber = IDnumber;
                this.name = name;
                this.secondName = secondName;
                this.lastName1 = lastName1;
                this.lastName2 = lastName2;
                this.fullName = this.IDnumber + " / " + this.name + " " + this.lastName1 + " " + this.lastName2;

            }
            else
            {
                this.IDnumber = IDnumber;
                this.name = name;
                this.secondName = secondName;
                this.lastName1 = lastName1;
                this.lastName2 = lastName2;
                this.fullName = this.IDnumber + " / " + this.name + " " + this.secondName + " " + this.lastName1 + " " + this.lastName2;
            }
        }

        public User(int dnumber, string name, char enabled, int userType, string secondName, string lastName1, string lastName2)
        {
            IDnumber = dnumber;
            this.name = name;
            this.enabled = enabled;
            this.userType = userType;
            this.secondName = secondName;
            this.lastName1 = lastName1;
            this.lastName2 = lastName2;
        }

        public User(string password, int userType)
        {
            this.password = password;
            this.userType = userType;
        }

        public User(char firstStart)
        {
            this.firstStart = firstStart;
        }

    }
}
