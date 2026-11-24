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
using System.Windows.Shapes;

namespace DemAppGazinskaa
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        demEkzEntities1 db = new demEkzEntities1();

        public Menu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgData.ItemsSource = db.Tovar.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
            Close();
        }
    }
}
