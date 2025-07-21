using Natariys.classes;
using Natariys.data;
using System.Linq;
using System.Windows;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = __login.Text;
            var password = __password.Password;
            users user = null;

            try
            {
                user = DB.entity.users.First(x => x.login == login && x.password == password);
            }
            catch
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

            if (user != null)
            {
                Manager.Login(user);

                this.Close();
            }
        }

    }
}
