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
    /// Логика взаимодействия для Order_Status_Window.xaml
    /// </summary>
    public partial class Order_Status_Window : Window
    {
        AppContext db;
        public Order_Status_Window()
        {
            InitializeComponent();
            db = new AppContext();
            db.Orders.Load();
            this.DataContext = db.Orders.Local.ToBindingList();
        }

        private void Label_AddWorker_MouseDown_2(object sender, MouseButtonEventArgs e)
        {

            Add_Worker_Window add_worker = new Add_Worker_Window();
            add_worker.Show();
        }

        private void Label_RemoveWorker_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Delete_Worker_Window dlt = new Delete_Worker_Window();
            dlt.Show();
           
        }

        private void Label_User_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            User_List_Window usw = new User_List_Window();
            usw.Show();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authwin = new Authorization_Window();
            authwin.Show();
            this.Close();
        }

        private void Label_Product_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Window awwin = new Admin_Window();
            awwin.Show();
            this.Close();
        }

        private void Label_AddProduct_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Add_Product_Window add_worker = new Add_Product_Window();
            add_worker.Show();
        }
    }
}
