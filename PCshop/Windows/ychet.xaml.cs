using PCshop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace PCshop.Windows
{
    /// <summary>
    /// Логика взаимодействия для ychet.xaml
    /// </summary>
    public partial class ychet : Window
    {
        public TableName currentTable;

        public ychet()
        {

            InitializeComponent();
            AppFrame.frameMain = MainFrame;
            MainFrame.Navigate(new Views.Tovaradmin());
        }

        private void Фильтрация_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.Auth user = new Windows.Auth();
            user.Show();
            Window.GetWindow(this).Close();
        }

        

        private void DtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.addeditwnd addeditwnd = new Windows.addeditwnd();
            addeditwnd.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Ychetzz ychetz = new Windows.Ychetzz();
            ychetz.Show();
            Window.GetWindow(this).Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
