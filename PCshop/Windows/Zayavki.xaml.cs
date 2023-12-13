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
using System.Windows.Shapes;

namespace PCshop.Windows
{
    /// <summary>
    /// Логика взаимодействия для Zayavki.xaml
    /// </summary>
    public partial class Zayavki : Window
    {
        public Zayavki()
        {
            
            InitializeComponent();
            AppFrame.frameZ = zFrame;
            zFrame.Navigate(new Views.appluser());
        }
    }
}
