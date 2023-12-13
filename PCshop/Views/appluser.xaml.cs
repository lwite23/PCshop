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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PCshop.Views
{
    /// <summary>
    /// Логика взаимодействия для appluser.xaml
    /// </summary>
    public partial class appluser : Page
    {
        public appluser()
        {
            InitializeComponent();
           var chk = AppData.db.Applications.Select(e => e.Checkk).ToList();
           
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Window.GetWindow(this).Close();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            
            var chk = AppData.db.Applications.Where
            NavigationService.GoBack();
        }
    }
}
