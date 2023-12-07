using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для korot.xaml
    /// </summary>
    public partial class korot : Page
    {
        public TableName currentTable;
        public korot()
        {
            InitializeComponent();
        }
        public korot(TableName tn)
        {
            currentTable = tn;
            this.WindowTitle = currentTable.ToString();

            InitializeComponent();
            Update();
        }
        public void Update()
        {
            switch (currentTable)
            {
                case TableName.Provider:
                    List<Provider> provider = AppData.db.Provider.ToList();
                    LVShort.ItemsSource = provider;
                    break;
                case TableName.Categories:
                    var categories = AppData.db.Categories.ToList();
                    LVShort.ItemsSource = categories;
                    break;
                case TableName.Roles:
                    var role = AppData.db.Roles.ToList();
                    LVShort.ItemsSource = role;
                    break;




            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (currentTable)
            {
                case TableName.Provider:
                    var currentProvider = button.DataContext as Provider;
                    NavigationService.Navigate(new korotAddEdit(currentTable, currentProvider));
                    break;
                case TableName.Categories:
                    var currentCategories = button.DataContext as Categories;
                    NavigationService.Navigate(new korotAddEdit(currentTable, null, currentCategories));
                    break;
                case TableName.Roles:
                    var currentRole = button.DataContext as Roles;
                    NavigationService.Navigate(new korotAddEdit(currentTable, null, null, currentRole));
                    break;;
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                switch (currentTable)
                {
                    case TableName.Provider:
                        var currentProvider = (sender as Button).DataContext as Provider;
                        AppData.db.Provider.Remove(currentProvider);
                        break;
                    case TableName.Categories:
                        var currentCategories = (sender as Button).DataContext as Categories;
                        AppData.db.Categories.Remove(currentCategories);
                        break;
                    case TableName.Roles:
                        var currentRole = (sender as Button).DataContext as Roles;
                        AppData.db.Roles.Remove(currentRole);
                        break;
                    

                    default:
                        break;
                }
                AppData.db.SaveChanges();
                Update();
            }
        }
    }
}
