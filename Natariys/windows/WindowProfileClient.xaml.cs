using Natariys.data;
using System.Windows;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowProfileClient.xaml
    /// </summary>
    public partial class WindowProfileClient : Window
    {
        public WindowProfileClient(users user)
        {
            InitializeComponent();

            DataContext = user;
        }
    }
}
