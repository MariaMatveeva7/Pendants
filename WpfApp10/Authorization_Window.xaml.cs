using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    /// Логика взаимодействия для Authorization_Window.xaml
    /// </summary>
    public partial class Authorization_Window : Window
    {
        public Authorization_Window()
        {
            InitializeComponent();
        }

        private void ButtonAothorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    if (TextLogin.Text != " " && TextPassword.Text != " " )
                {


                    using (AppContext db = new AppContext())
                    {
                        foreach (User user in db.Users)
                        {
                            if (TextLogin.Text == user.Login && TextPassword.Text == user.Password)
                            {
                                if (user.Role == "User")
                                {
                                    MessageBox.Show("Покупатель, вход успешен! ");
                                    User_Window uw = new User_Window();
                                    uw.Show();
                                    this.Close();

                                }
                                if (user.Role == "Admin")
                                {
                                    MessageBox.Show("Администратор, вход успешен!");
                                    Admin_Window admin = new Admin_Window();
                                    admin.Show();
                                    this.Close();

                                }
                                else if (user.Role == "Worker")
                                {
                                    MessageBox.Show("Сотрудник, вход успешен!");
                                    Worker_Window worker = new Worker_Window();
                                    worker.Show();
                                    this.Close();
                                    return;
                                   
                                }


                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль указаны неверно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}

