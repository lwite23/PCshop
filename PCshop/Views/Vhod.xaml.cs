using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PCshop
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Page
    {
        public Vhod()

        {
            InitializeComponent();

        }

        private void ResetCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow user= new MainWindow();
            user.Show();
            Window.GetWindow(this).Close();
        }


        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = AppData.db.Users.FirstOrDefault((u) => u.Login == TBLogin.Text && u.Password == TBPassword.Text);
                if (currentUser == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");
                }
                else
                {
                    App.CurrentUser = currentUser;
                    if (currentUser.Login.Equals(TBLogin.Text) && currentUser.Password.Equals(TBPassword.Text))
                    {

                        if (currentUser.RoleID == 1)
                        {
                            Windows.ychet admin = new Windows.ychet(); //currentUser.userID
                            admin.Show();
                        }
                        else
                        {
                            if (currentUser.Login.Equals(TBLogin.Text) && currentUser.Password.Equals(TBPassword.Text))
                            {

                                if (currentUser.RoleID == 2)
                                {
                                    MainWindow user = new MainWindow(); //currentUser.userID
                                    user.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Введите корректные логин и пароль", "Ошибка авторизации");
                                    
                                }
                                Window.GetWindow(this).Close();
                            }

                        }
                        
                       ;
                    }
                

                    

                }



                //if (CurrentUser == null)
                //{
                //    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации");

                //} else
                //{
                //    switch (CurrentUser.roleID)
                //    {
                //        case 1:MessageBox.Show("Здравствуйте, Администратор " + CurrentUser.name + "!");
                //            break;
                //        case 2:MessageBox.Show("Здравствуйте, гость " + CurrentUser.name + "!");
                //            break;
                //        default:MessageBox.Show("Ошибка");
                //            break;
                //    }

                //    if (CurrentUser.login.Equals(TBLogin.Text) && CurrentUser.password.Equals(TBPassword.Text))
                //    {
                //        NavigationService.Navigate(new DataPage());
                //    }
                //    else
                //    {
                //        MessageBox.Show("Введите корректные логин и пароль");
                //    }                
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString());
            }

        }
    }
}