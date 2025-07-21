using Microsoft.Win32;
using Natariys.classes;
using Natariys.data;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowRegWorker.xaml
    /// </summary>
    public partial class WindowRegWorker : Window
    {
        users newUser = new users();
        List<services> newServices = new List<services>();

        public WindowRegWorker()
        {
            InitializeComponent();

            var img = new ImgModel() { img_path = "/assets/user_defoult.png" };
            __imgProfile.DataContext = img;
            newUser.img_path = img.img_path;
        }

        private void __photo_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.jpg;*.png";
            dialog.ShowDialog();

            newUser.img_path = dialog.FileName;
            var img = new ImgModel() { img_path = dialog.FileName };
            __imgProfile.DataContext = img;
        }

        private void BtnSave_Click_Save(object sender, RoutedEventArgs e)
        {
            var isUser = DB.entity.users.ToList().Any(u => u.login == __login.Text);

            if (__firstName.Text == "" ||
                __lastName.Text == "" ||
                __phone.Text == "" ||
                __login.Text == "" ||
                __password.Text == "" ||
                __address.Text == "")
            {
                MessageBox.Show("Заполните обязательные данные!");
                return;
            }

            if (isUser)
            {
                MessageBox.Show("Логин уже занят, придумайте другой!");
                return;
            }

            if (__email.Text != "")
                if (!__email.Text.Contains("@") && !__email.Text.Contains("."))
                {
                    MessageBox.Show("Почта неккоректа!");
                    return;
                }

            if (newServices.Count < 1)
            {
                MessageBox.Show("Добавте хотя бы 1 услугу");
                return;
            }

            for (int i = 0; i < newServices.Count; i++)
            {
                DB.entity.services.ToList().ForEach(s =>
                {
                    if (s.name == newServices[i].name)
                        newServices[i] = s;
                });
                
            }

            newUser.id_role = 2;
            newUser.first_name = __firstName.Text;
            newUser.last_name = __lastName.Text;
            newUser.sur_name = __surName.Text;
            newUser.phone = __phone.Text;
            newUser.email = __email.Text;
            newUser.login = __login.Text;
            newUser.password = __password.Text;
            newUser.address = new address() { name = __address.Text };
            newUser.services = newServices;

            DB.entity.users.Add(newUser);
            DB.entity.SaveChanges();
            
            Close();
        }

        private void BtnAdd_Click_AddServ(object sender, RoutedEventArgs e)
        {
            if (__txtAddServ.Text == "")
            {
                MessageBox.Show("Введите название");
                return;
            }

            newServices.Add(new services() { name = __txtAddServ.Text });
            __txtAddServ.Text = "";
            __listServ.ItemsSource = null;
            __listServ.ItemsSource = newServices;
        }

        private void BtnAdd_Click_DelServ(object sender, RoutedEventArgs e)
        {
            if (__listServ.SelectedItem == null)
            {
                MessageBox.Show("Ввыберите услугу");
                return;
            }

            var ser = __listServ.SelectedItem as services;

            newServices.Remove(ser);
            __listServ.ItemsSource = null;
            __listServ.ItemsSource = newServices;
        }
    }
}
