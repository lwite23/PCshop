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
    /// Логика взаимодействия для zayavki.xaml
    /// </summary>
    public partial class zayavki : Page
    {
        public zayavki()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var content = AppData.db.Applications.ToList();
            Tovarsq.ItemsSource = content;
        }

        private void Tovarsq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var currentTovar = button.DataContext as Tovar;
            NavigationService.Navigate(new Views.Zadmins(currentTovar));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var currentApplication = (sender as Button).DataContext as Applications;
            if (MessageBox.Show("Вы уверены что хотите удалить эту заявку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AppData.db.Applications.Remove(currentApplication);
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
