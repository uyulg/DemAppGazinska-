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
    /// Логика взаимодействия для ManagerForm.xaml
    /// </summary>
    public partial class ManagerForm : Window
    {
        demEkzEntities1 db = new demEkzEntities1();

        public ManagerForm() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource = db.Tovar.ToList();
            dgOrders.ItemsSource = db.Заказ.ToList();   // ← загружаем сразу оба
        }

        // ===== Переключение =====
        private void ShowProducts_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.Visibility = Visibility.Visible;
            dgOrders.Visibility = Visibility.Collapsed;
            FilterPanel.Visibility = Visibility.Visible;
        }

        private void ShowOrders_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.Visibility = Visibility.Collapsed;
            dgOrders.Visibility = Visibility.Visible;
            FilterPanel.Visibility = Visibility.Collapsed;   
        }

        private void ApplyFilter()
        {
            var q = db.Tovar.ToList();

            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
                q = q.Where(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

            if (cbFilter.SelectedIndex == 1)
                q = q.Where(x => x.Price < 1000).ToList();
            else if (cbFilter.SelectedIndex == 2)
                q = q.Where(x => x.Price >= 1000 && x.Price <= 5000).ToList();
            else if (cbFilter.SelectedIndex == 3)
                q = q.Where(x => x.Price > 5000).ToList();

            if (cbSort.SelectedIndex == 1)
                q = q.OrderBy(x => x.Price).ToList();
            else if (cbSort.SelectedIndex == 2)
                q = q.OrderByDescending(x => x.Price).ToList();

            dgProducts.ItemsSource = q;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
            Close();
        }
    }
}