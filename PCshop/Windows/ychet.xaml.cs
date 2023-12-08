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
            MainFrame.Navigate(new Views.Tovars());
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
    }
}
