using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp10
{
     class User
    {
        public int ID { get; set; }
        public string Login;
        public string Password;
        public string FIO;
        public string Telephone;
        public string Role;

        public string login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public string fio
        {
            get { return FIO; }
            set { FIO = value; }
        }
        public string telephone
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
        public string role
        {
            get { return Role; }
            set { Role = value; }
        }

        public User() { }

        public User(string Login, string Password, string FIO, string Telephone, string Role)
        {
            this.Login = Login;
            this.Password = Password;
            this.FIO = FIO;
            this.Telephone = Telephone;
            this.Role = Role;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")

        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
    }
}
