using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Delete_Worker_Window.xaml
    /// </summary>
    public partial class Delete_Worker_Window : Window
    {
        AppContext db;
        public Delete_Worker_Window()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void ButtonRemoveWorker_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (TextLogin.Text != " " && TextPassword.Text != " ")
                {


                    using (AppContext db = new AppContext())
                    {
                        foreach (User user in db.Users)
                        {
                            if (TextLogin.Text == user.Login && TextPassword.Text == user.Password)
                            {
                                if (user.Role == "User")
                                {
                                    MessageBox.Show("Вы ввели некорректные данные, попробуйте еще раз! ");
                                }
                                if (user.Role == "Admin")
                                {
                                    MessageBox.Show("Вы ввели некорректные данные, попробуйте еще раз!");
                                }
                                else if (user.Role == "Worker")
                                {
                                    db.Users.Remove(user);
                                    db.SaveChanges();
                                    MessageBox.Show("Удаление сотрудника прошло успешно!");
                                  
                                    TextLogin.ToolTip = "";
                                    TextLogin.Background = Brushes.Transparent;
                                    TextPassword.ToolTip = "";
                                    TextPassword.Background = Brushes.Transparent;
                                    this.Close();
                                    return;

                                }


                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль указан неверно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
