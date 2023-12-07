using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для korotAddEdit.xaml
    /// </summary>
    public partial class korotAddEdit : Page
    {
        public TableName currentTable;
        public string itemName;
        public Roles role;
        public Provider provider;
        public Categories categories;
        public bool addOrEditFlag = false;
        public korotAddEdit(TableName tn)
        {
            InitializeComponent();
            this.WindowTitle = "Добавление";
            currentTable = tn;
            addOrEditFlag = true;
            switch (currentTable)
            {
                case TableName.Provider:
                    this.WindowTitle = "Добавление Поставщика";
                    TBName.Text = "Поставщик:";
                    break;
                case TableName.Roles:
                    this.WindowTitle = "Добавление ролей";
                    TBName.Text = "Роль:";
                    break;
                case TableName.Categories:
                    this.WindowTitle = "Добавление Категории";
                    TBName.Text = "Категория:";
                    break;
                default:
                    break;
            }
        }
        public korotAddEdit(TableName tn, Provider pr = null, Categories cat = null, Roles rl = null)
        {
            this.currentTable = tn;
            addOrEditFlag = false;
            this.provider = pr;
            this.categories = cat;
            this.role = rl;
            InitializeComponent();


            switch (currentTable)
            {
                case TableName.Provider:
                    this.WindowTitle = "Редактирование поставщика";
                    TBName.Text = "Поставщик:";
                    TBShortName.Text = provider.ProviderName;
                    break;
                case TableName.Categories:
                    this.WindowTitle = "Редактирование категории";
                    TBName.Text = "Категория:";
                    TBShortName.Text = categories.Category;
                    break;
                case TableName.Roles:
                    this.WindowTitle = "Редактирование ролей";
                    TBName.Text = "Роль:";
                    TBShortName.Text = role.Role;
                    break;
              
                default:
                    break;
            }

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            if (addOrEditFlag)
            {
                switch (currentTable)
                {
                    case TableName.Provider:
                        Provider provider = new Provider()
                        {
                            ProviderName = TBShortName.Text,
                        };
                        AppData.db.Provider.Add(provider);
                        break;
                    case TableName.Categories:
                        Categories categories = new Categories()
                        {
                            Category = TBShortName.Text,
                        };
                        AppData.db.Categories.Add(categories);
                        break;
                    case TableName.Roles:
                        Roles role = new Roles()
                        {
                            Role = TBShortName.Text,
                        };
                        AppData.db.Roles.Add(role);
                        break;
                    default:
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена в таблицу!");
            }
            else
            {
                switch (currentTable)
                {
                    case TableName.Provider:
                        provider.ProviderName = TBShortName.Text;
                        break;
                    case TableName.Categories:
                        categories.Category = TBShortName.Text;
                        break;
                    case TableName.Roles:
                        role.Role = TBShortName.Text;
                        break;
                }
                AppData.db.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
            }
            NavigationService.Navigate(new korot(currentTable));
        }
    }
}
