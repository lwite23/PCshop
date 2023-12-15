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

namespace PCshop.Views
{
    /// <summary>
    /// Логика взаимодействия для Zadmins.xaml
    /// </summary>
    public partial class Zadmins : Page
    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Tovar currentTovar;
        public Applications currentApplication;
        public Zadmins()
        {
            InitializeComponent();
            var qwe = AppData.db.Status.Select(p => p.Stats).ToList();
            TBqwe.ItemsSource = qwe;

        }
        public Zadmins(Tovar tovar)
        {
            currentTovar = tovar;
            InitializeComponent();
            this.WindowTitle = "Редактирование товара";
            TBart.Text = currentApplication.IDArticle.ToString();
            TBname.Text = currentTovar.TovarName;
            TBgar.Text = currentTovar.Warranty;
            TBprice.Text = currentTovar.Price.ToString();
            TBdes.Text = currentTovar.Description;
            TBcat.Text = currentTovar.Categories.Category;
            TBpost.Text = currentTovar.Provider.ProviderName;
            if (currentTovar.image != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentTovar.image);
                tovarimg.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
            this.WindowTitle = "Добавление товара";
            var qwe = AppData.db.Status.Select(p => p.Stats).ToList();
            TBqwe.ItemsSource = qwe;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
