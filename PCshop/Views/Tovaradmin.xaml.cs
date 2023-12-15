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
            var tovars = AppData.db.Tovar.ToList();
            switch (sort.SelectedIndex)
            {
                case 0:
                    tovars = tovars.OrderBy(t => t.TovarName).ToList();
                    break;
                case 1:
                    tovars = tovars.OrderByDescending(t => t.TovarName).ToList();
                    break;
                case 2:
                    tovars = tovars.OrderBy(t => t.Price).ToList();
                    break;
                case 3:
                    tovars = tovars.OrderByDescending(t => t.Price).ToList();
                    break;
                default:
                    break;
            }
            tovars = tovars.Where(t => t.TovarName.ToLower().Contains(serch.Text.ToLower()) || t.Description.ToLower().Contains(serch.Text.ToLower())).ToList();
            var amount = AppData.db.Tovar.ToList().Count;
            if (tovars.Count == 0)
            {
                result.Text = "По вашему запросу ничего не найдено";
            }
            else
            {
                result.Text = $"Найдено {tovars.Count} товаров из {amount}";
            }
            Tovarsq.ItemsSource = null;
            Tovarsq.ItemsSource = tovars;
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
            var currentApplications = (sender as Button).DataContext as Applications;
            if(MessageBox.Show("Вы уверены что хотите удалить этот товар?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) 
            {
                AppData.db.Tovar.Remove(currentTovar);
                AppData.db.SaveChanges();
                Update();
            }
        }

        private void Tovarsq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
