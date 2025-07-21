using Natariys.data;
using System.Windows;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowProfile.xaml
    /// </summary>
    public partial class WindowProfileWorker : Window
    {
        public WindowProfileWorker(users user)
        {
            InitializeComponent();

            DataContext = user;
        }
    }
}
