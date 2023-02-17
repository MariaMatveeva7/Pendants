using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Логика взаимодействия для User_List_Window.xaml
    /// </summary>
    public partial class User_List_Window : Window
    {
        AppContext db;
        public User_List_Window()
        {
            InitializeComponent();
            db = new AppContext();
            db.Users.Load();
            this.DataContext = db.Users.Local.ToBindingList();

        }

        private void Label_RemoveWorker_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Delete_Worker_Window dlt = new Delete_Worker_Window();
            dlt.Show();
        }

        private void Label_AddWorker_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Add_Worker_Window add_worker = new Add_Worker_Window();
            add_worker.Show();
        }

        private void Label_Product_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Window awwin = new Admin_Window();
            awwin.Show();
            this.Close();
        }

        private void Label_Order_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Order_Status_Window order = new Order_Status_Window();
            order.Show();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authwin = new Authorization_Window();
            authwin.Show();
            this.Close();
        }
    }
}
