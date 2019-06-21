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

        public User()
        {
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
