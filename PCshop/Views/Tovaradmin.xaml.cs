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
            //var tools = App.Context.Products.ToList();
            //switch (sortBox.SelectedIndex)
            //{
            //    case 0:
            //        tools = tools.OrderBy(t => t.Title).ToList();
            //        break;
            //    case 1:
            //        tools = tools.OrderByDescending(t => t.Title).ToList();
            //        break;
            //    case 2:
            //        tools = tools.OrderBy(t => t.Price).ToList();
            //        break;
            //    case 3:
            //        tools = tools.OrderByDescending(t => t.Price).ToList();
            //        break;
            //    default:
            //        break;
            //}
            //if (filterBox.SelectedIndex != 0)
            //{
            //    tools = tools.Where(t => t.productTypeName == filterBox.SelectedItem.ToString()).ToList();
            //}
            //tools = tools.Where(t => t.Title.ToLower().Contains(searchBox.Text.ToLower()) || t.Description.ToLower().Contains(searchBox.Text.ToLower())).ToList();
            //var amount = App.Context.Products.ToList().Count;
            //if (tools.Count == 0)
            //{
            //    searchResultBox.Text = "По вашему запросу ничего не найдено";
            //}
            //else
            //{
            //    searchResultBox.Text = $"Найдено {tools.Count} инструментов из {amount}";
            //}
            //toolsListView.ItemsSource = null;
            //toolsListView.ItemsSource = tools;
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

        private void Tovarsq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
