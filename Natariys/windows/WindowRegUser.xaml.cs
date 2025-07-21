using Microsoft.Win32;
using Natariys.classes;
using Natariys.data;
using System;
using System.Linq;
using System.Windows;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowRegUser.xaml
    /// </summary>
    public partial class WindowRegUser : Window
    {
        users newUser = new users();

        public WindowRegUser()
        {
            InitializeComponent();

            var img = new ImgModel() { img_path = "/assets/user_defoult.png" };
            __imgProfile.DataContext = img;
            newUser.img_path = img.img_path;
        }

        private void BtnSave_Click_Reg(object sender, RoutedEventArgs e)
        {
            var isUser = DB.entity.users.ToList().Any(u => u.login == __login.Text);

            if (__firstName.Text == "" ||
                __lastName.Text == "" ||
                __phone.Text == "" ||
                __login.Text == "" ||
                __password.Text == "")
            {
                MessageBox.Show("Заполните обязательные данные!");
                return;
            }

            if (isUser)
            {
                MessageBox.Show("Логин уже занят, придумайте другой!");
                return;
            }

            if (__email.Text.Contains("@") && __email.Text.Contains("."))
            {
                MessageBox.Show("Почта неккоректа!");
                return;
            }

            newUser.id_role = 1;
            newUser.first_name = __firstName.Text;
            newUser.last_name = __lastName.Text;
            newUser.sur_name = __surName.Text;
            newUser.phone = __phone.Text;
            newUser.email = __email.Text;
            newUser.login = __login.Text;
            newUser.password = __password.Text;

            DB.entity.users.Add(newUser);

            try
            {
                DB.entity.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
        }

        private void Photo_Click_Img(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.jpg;*.png";
            dialog.ShowDialog();

            newUser.img_path = dialog.FileName;
            var img = new ImgModel() { img_path = dialog.FileName };
            __imgProfile.DataContext = img;
        }
    }
}

public class ImgModel
{
    public string img_path { get; set; }
}