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
using KazanNeft.Model;
using KazanNeft.Windows;

namespace KazanNeft
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = Context._con.Employees.Where(p => p.Username == UsernameTB.Text && p.Password == PasswordTB.Text).FirstOrDefault();
            if (user != null)
            {
                if(user.isAdmin == true)
                {
                    EMManagment eMManagment = new EMManagment();
                    eMManagment.Show();
                    this.Close();
                }
                else
                {
                    EMRequest eMRequest = new EMRequest();
                    eMRequest.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
