﻿using System;
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
using System.Windows.Shapes;

namespace PCshop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Ychetzz.xaml
    /// </summary>
    public partial class Ychetzz : Window
    {
        public Ychetzz()
        {
            InitializeComponent();
            AppFrame.frameYc = yFrame;
            yFrame.Navigate(new Views.zayavki());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.ychet ychet = new Windows.ychet();
            ychet.Show();
            Window.GetWindow(this).Close();
        }
    }
    
}
