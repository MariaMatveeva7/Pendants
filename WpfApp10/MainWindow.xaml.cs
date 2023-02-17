using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Login = TextLogin.Text.Trim();
                string Password = TextPassword.Text.Trim();
                string Password2 = TextPassword2.Text.Trim();
                string FIO = TextFIO.Text.Trim();
                string Telephone = TextTelephone.Text.Trim();
                string Role = "User";
                if (Login.Length < 5)
                {
                    MessageBox.Show("Это поле введено не корректно!");
                    TextLogin.Background = Brushes.MistyRose;
                }
                else if (Password.Length < 6)
                {
                    MessageBox.Show("Это поле введено не корректно!");
                    TextPassword.Background = Brushes.MistyRose;
                }
                else if (Password != Password2)
                {
                    MessageBox.Show("Это поле введено не корректно!");
                    TextPassword2.Background = Brushes.MistyRose;
                }
                else if (FIO.Length < 5)
                {
                    MessageBox.Show("Это поле введено не корректно!");
                    TextFIO.Background = Brushes.MistyRose;
                }
                else if (Telephone.Length != 11)
                {
                    MessageBox.Show("Это поле введено не корректно!");
                    TextTelephone.Background = Brushes.MistyRose;
                }
                else
                {
                    TextLogin.ToolTip = "";
                    TextLogin.Background = Brushes.Transparent;
                    TextPassword.ToolTip = "";
                    TextPassword.Background = Brushes.Transparent;
                    TextPassword2.ToolTip = "";
                    TextPassword2.Background = Brushes.Transparent;
                    TextFIO.ToolTip = "";
                    TextFIO.Background = Brushes.Transparent;
                    TextTelephone.ToolTip = "";
                    TextTelephone.Background = Brushes.Transparent;


                    User user = new User(Login, Password, FIO, Telephone, Role); ;
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Вы успешно прошли регистрацию!");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authwin = new Authorization_Window();
            authwin.Show();
            this.Close();

        }
    }
    }

