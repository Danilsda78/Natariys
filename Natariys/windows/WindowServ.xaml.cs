using Natariys.classes;
using Natariys.data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowServ.xaml
    /// </summary>
    public partial class WindowServ : Window
    {
        public WindowServ()
        {
            InitializeComponent();

            __listServ.ItemsSource = DB.entity.services.ToList();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var s = sender as CheckBox;
            var serv = s.DataContext as services;

            Manager.GetFilter().BlockSerch.SerchServic.Add( serv );
        }

        private void Button_ClickSave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
        }
    }
}
