using Natariys.classes;
using Natariys.data;
using System.Windows;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowMyProfileClient.xaml
    /// </summary>
    public partial class WindowMyProfileClient : Window
    {
        users User = Manager.User;

        public WindowMyProfileClient()
        {
            InitializeComponent();

            __imgProfile.DataContext = User;
            __panel.DataContext = User;


        }

        private void __btnEdit_Click(object sender, RoutedEventArgs e)
        {
            __panel.IsEnabled = true;
            __photo.IsEnabled = true;
            __btnSave.IsEnabled = true;
            __btnAlter.IsEnabled = false;
        }

        private void __btnSave_Click(object sender, RoutedEventArgs e)
        {
            DB.entity.SaveChanges();

            __panel.IsEnabled = false;
            __photo.IsEnabled = false;
            __btnSave.IsEnabled = false;
            __btnAlter.IsEnabled = true;
        }
    }
}
