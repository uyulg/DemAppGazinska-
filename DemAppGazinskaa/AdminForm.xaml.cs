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
using System.Xml.Linq;

namespace DemAppGazinskaa
{
    /// <summary>
    /// Логика взаимодействия для AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        demEkzEntities1 db = new demEkzEntities1();

        public AdminForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        
        { 
            LoadData(); 
        }

        private void LoadData()
        {
            dgData.ItemsSource = db.Tovar.ToList();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Tovar t)
            {
                txtArticle.Text = t.Article;
                txtName.Text = t.Name;
                txtPrice.Text = t.Price.ToString();
                txtDiscount.Text = t.Discount.ToString();
                txtQty.Text = t.Quantity_stock.ToString();
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Tovar t = new Tovar();
            t.Article = txtArticle.Text;
            t.Name = txtName.Text;
            t.Price = (short)decimal.Parse(txtPrice.Text);    
            t.Discount = byte.Parse(txtDiscount.Text);        
            t.Quantity_stock = byte.Parse(txtQty.Text);       
            db.Tovar.Add(t);
            db.SaveChanges();
            LoadData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Tovar t = (Tovar)dgData.SelectedItem;
            t.Article = txtArticle.Text;
            t.Name = txtName.Text;
            t.Price = (short)decimal.Parse(txtPrice.Text);
            t.Discount = byte.Parse(txtDiscount.Text);
            t.Quantity_stock = byte.Parse(txtQty.Text);
            db.SaveChanges();
            LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Tovar t = (Tovar)dgData.SelectedItem;
            db.Tovar.Remove(t);
            db.SaveChanges();
            LoadData();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
            Close();
        }
    }
}