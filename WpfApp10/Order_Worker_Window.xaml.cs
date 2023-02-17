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
    /// Логика взаимодействия для Order_Worker_Window.xaml
    /// </summary>
    public partial class Order_Worker_Window : Window
    {
        AppContext db;
        public Order_Worker_Window()
        {
            InitializeComponent();
            db = new AppContext();
            db.Orders.Load();
            this.DataContext = db.Orders.Local.ToBindingList();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Worker_Window ww = new Worker_Window();
            ww.Show();
            this.Close();
        }

        private void Label_AddProduct_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Add_Product_Window add_worker = new Add_Product_Window();
            add_worker.Show();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (list_order.SelectedItem == null) return;
            // получаем выделенный объект
            Order contest = list_order.SelectedItem as Order;
            Order_Redact_Window cons = new Order_Redact_Window(new Order
            {
                
                id_order = contest.id_order,
                id_user = contest.id_user,
                Status_order = contest.Status_order,
                id_backet = contest.id_backet,
                Address = contest.Address,
                Delivery_time = contest.Delivery_time,
                Payment_method = contest.Payment_method
               
            });
            if (cons.ShowDialog() == true)
            {
                // получаем измененный объект
                contest = db.Orders.Find(cons.Order.id_order);
                if (contest != null)
                {
                    contest.Status_order = cons.Order.status_order;
                    contest.id_user = cons.Order.id_user;
                    contest.id_backet = cons.Order.id_backet;
                    contest.Address = cons.Order.address;
                    contest.Delivery_time = cons.Order.delivery_time;
                    contest.Payment_method = cons.Order.payment_method;

                    //db.Entry(contest).State = EntityState.Modified;
                    db.SaveChanges();
                    list_order.Items.Refresh();
                }
            }
        }
    }
}

