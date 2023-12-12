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

namespace PCshop.Views
{
    /// <summary>
    /// Логика взаимодействия для Tovaradmin.xaml
    /// </summary>
    public partial class Tovaradmin : Page
    {
        public Tovaradmin()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var content = AppData.db.Tovar.ToList();
            Tovarsq.ItemsSource = content;
        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentTovar = button.DataContext as Tovar;
            NavigationService.Navigate(new Views.Addedittovar(currentTovar));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentTovar = (sender as Button).DataContext as Tovar;
            if(MessageBox.Show("Вы уверены что хотите удалить этот товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) 
            {
                AppData.db.Tovar.Remove(currentTovar);
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
