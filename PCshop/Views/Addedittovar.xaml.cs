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
    /// Логика взаимодействия для Addedittovar.xaml
    /// </summary>
    public partial class Addedittovar : Page
    {
        private byte[] _mainImageData = null;
        public string img = null;
        public string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
        public string selectefFileName;
        public string extension = "";
        public Tovar currentTovar;
        public Addedittovar()
        {
            InitializeComponent();
            this.WindowTitle = "Добавление товара";
        }

        public Addedittovar(Tovar tovar) 
        {
            currentTovar = tovar;
            InitializeComponent();
            this.WindowTitle = "Редактирование товара";
            TBart.Text = currentTovar.Article.ToString();
            TBname.Text = currentTovar.TovarName;
            TBgar.Text = currentTovar.Warranty;
            TBprice.Text = currentTovar.Price.ToString();
            TBdes.Text = currentTovar.Description;
            if(currentTovar.image != null)
            {
                _mainImageData = File.ReadAllBytes(path + currentTovar.image);
                tovarimg.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
        }
        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Фото | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                img = Path.GetFileName(ofd.FileName);
                extension = Path.GetExtension(img);
                selectefFileName = ofd.FileName;
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                tovarimg.Source = new ImageSourceConverter()
                    .ConvertFrom(_mainImageData) as ImageSource;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (img != null)
            {
                img = TBart.Text + extension;
                var files = Directory.GetFiles(path);
                int a = 0;
                while (File.Exists(path + img))
                {
                    a++;
                    img = TBart.Text + $" ({a})" + extension;
                }
                path = path + img;
                File.Copy(selectefFileName, path);
            }
            else if (currentTovar.image != null)
            {
                img = currentTovar.image;
            }
            if (currentTovar == null)
            {
                Tovar tovar = new Tovar()
                {
                    Article = Int32.Parse(TBart.Text),
                    TovarName = TBname.Text,
                    Warranty = TBgar.Text,
                    Price = Int32.Parse(TBprice.Text),
                    Description = TBdes.Text,
                    image = img

                };
                AppData.db.Tovar.Add(tovar);
                AppData.db.SaveChanges();
                MessageBox.Show("Резюме успешно добавленно!");
            }
            else if (currentTovar.image != img || currentTovar.TovarName != TBname.Text ||
                currentTovar.Warranty != TBgar.Text ||
                currentTovar.Price != Int32.Parse(TBprice.Text) ||
                currentTovar.Description != TBdes.Text ||
                currentTovar.Article != Int32.Parse(TBart.Text))




            {
                currentTovar.image = img;
                currentTovar.TovarName = TBname.Text;
                currentTovar.Warranty = TBgar.Text;
                currentTovar.Price = Int32.Parse(TBprice.Text);
                currentTovar.Description = TBdes.Text;
                currentTovar.Article = Int32.Parse(TBart.Text);
                AppData.db.SaveChanges();
                MessageBox.Show("Резюме успешно обновленно!");
                currentTovar = null;
            }
            NavigationService.Navigate(new Views.Tovars());
        }

    }
    
}
