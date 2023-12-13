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
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Status currentApplication;
        public Tovar currentTovar;
        public appluser()
        {
            InitializeComponent();
           var qwe = AppData.db.Status.Select(e => e.Stats).ToList();
           TBqwe.ItemsSource = qwe;
        }
        public appluser(Tovar tovar)
        {
            TBart.Text = currentTovar.Article.ToString();
            if (currentTovar.image != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentTovar.image);
                PCimage.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
        }
        public appluser(Status status)
        {
            var qwe = AppData.db.Status.Select(e => e.Stats).ToList();
            TBqwe.ItemsSource = qwe;
            TBart.Text = currentTovar.Article.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Window.GetWindow(this).Close();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {

            var chk = AppData.db.Status.Where(a => a.Stats == TBqwe.SelectedItem.ToString());
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
