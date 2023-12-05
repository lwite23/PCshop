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
                CreateCaptcha();
            }
        
        public string CaptchaValue { get; set; }

        public event System.EventHandler CaptchaRefreshed;

        private void ResetCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            CreateCaptcha();
        }

        private void CreateCaptcha()
        {
            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            System.Random r = new System.Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];

                pwd += temp;
            }

            CaptchaText.Text = pwd;

            CaptchaValue = CaptchaText.Text;

            CaptchaRefreshed?.Invoke(this, System.EventArgs.Empty);
        }

        private void CaptchaText_TextChanged(object sender, TextChangedEventArgs e)
        {

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

                        if (currentUser.RoleID == 1 || currentUser.RoleID == 2)
                        {
                            MainWindow admin = new MainWindow(); //currentUser.userID
                            admin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные логин и пароль", "Ошибка авторизации");
                        }
                        Window.GetWindow(this).Close();
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