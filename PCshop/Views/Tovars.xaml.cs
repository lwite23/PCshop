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
    /// Логика взаимодействия для Tovars.xaml
    /// </summary>
    public partial class Tovars : Page
    {
        public Tovars()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            var content = AppData.db.Tovar.ToList();
            Tovarsq.ItemsSource = content;
        }

        private void Tovarsq_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnUserApp_Click(object sender, RoutedEventArgs e)
        {
            Windows.Zayavki zay = new Windows.Zayavki();
            zay.Show();
            Window.GetWindow(this).Close();
        }
    }
}
