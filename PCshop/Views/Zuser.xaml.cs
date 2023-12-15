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
    /// Логика взаимодействия для Zuser.xaml
    /// </summary>
    public partial class Zuser : Page
    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Tovar currentTovar;
        public Applications currentApplication;
        public Zuser()
        {
            InitializeComponent();
            var qwe = AppData.db.Status.Select(p => p.Stats).ToList();
            TBqwe.ItemsSource = qwe;
        }
        public Zuser(Tovar tovar)
        {
            currentTovar = tovar;
            InitializeComponent();
            this.WindowTitle = "Редактирование товара";
            TBart.Text = currentTovar.Article.ToString();
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
            MainWindow main = new MainWindow();
            main.Show();
            Window.GetWindow(this).Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var qwe = AppData.db.Status.Where(a => a.Stats == TBqwe.SelectedItem.ToString()).FirstOrDefault();
            
            if (currentApplication == null)
            {
                Applications application = new Applications()
                {
                    IDArticle = Int32.Parse(TBart.Text),
                    IDStatus = qwe.ID,
                    IDUsers = App.CurrentUser.ID
                    

                };
                AppData.db.Applications.Add(application);
                AppData.db.SaveChanges();
                MessageBox.Show("Товар добавлен!");
            }
            else
            {
                currentApplication.IDArticle = Int32.Parse(TBart.Text);
                currentApplication.IDStatus = qwe.ID;
                AppData.db.SaveChanges();
                MessageBox.Show("Товар обновлен!");
                currentApplication = null;
            }
            MainWindow main = new MainWindow();
            main.Show();
            Window.GetWindow(this).Close();
        }
    }
}
