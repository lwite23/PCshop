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
    /// Логика взаимодействия для addeditwnd.xaml
    /// </summary>
    public partial class addeditwnd : Window
    {
        public addeditwnd()
        {
            InitializeComponent();
            AppFrame.frameWnd = wndFrame;
            wndFrame.Navigate(new Views.Addedittovar());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
