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

namespace DemAppGazinskaa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        demEkzEntities1 db = new demEkzEntities1();

        private void LogBt_Click(object sender, RoutedEventArgs e)
        {
            var user = db.User.FirstOrDefault(
                x => x.Login == tbLogin.Text && x.Password == tbPassword.Password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            Hide();

            if (user.Role == "Администратор")
                new AdminForm().ShowDialog();
            else if (user.Role == "Менеджер")
                new ManagerForm().ShowDialog();
            else
                new Menu().ShowDialog();   // клиент

            Close();
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Menu().ShowDialog();   // гость тоже сюда
            Close();
        }
    }
}
