using Natariys.classes;
using Natariys.data;
using Natariys.windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Natariys
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Filter filter;

        public MainWindow()
        {
            InitializeComponent();

            DB.Init();
            filter = Manager.GetFilter();

            __list.ItemsSource = filter.GetList();
            __serchList.ItemsSource = filter.BlockSerch.SerchServic;
        }

        public void Login(users user)
        {
            __boxProfile.DataContext = user;

            __boxProfile.Visibility = Visibility.Visible;
            __boxLogin.Visibility = Visibility.Collapsed;
        }

        public void Logout()
        {
            __boxProfile.DataContext = null;

            __boxProfile.Visibility = Visibility.Collapsed;
            __boxLogin.Visibility = Visibility.Visible;
        }

        private void Button_Click_FilterServ(object sender, RoutedEventArgs e)
        {
            var w = new WindowServ();
            w.Closing += (object s, System.ComponentModel.CancelEventArgs ev) =>
            {
                __serchList.ItemsSource = filter.BlockSerch.SerchServic.ToList();
                __list.ItemsSource = filter.GetList();
            };
            w.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var w = new WindowLogin();
            w.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.Logout();
            Logout();
        }

        private void TextBox_SerchChanged(object sender, TextChangedEventArgs e)
        {
            filter.BlockSerch.SerchAddress = __address.Text;
            filter.BlockSerch.SerchPhone = __phone.Text;
            filter.BlockSerch.SerchName = __name.Text;
            filter.BlockSerch.SerchEmail = __email.Text;

            __list.ItemsSource = filter.GetList();
        }

        private void Button_Click_Message(object sender, RoutedEventArgs e)
        {
            if (!Manager.IsAuth)
            {
                MessageBox.Show("Вы не авторизованы!");
                return;
            }

            var t = (int)(sender as Button).Tag;

            if (t == Manager.User.id)
            {
                MessageBox.Show("Вы не можете написать сами себе!");
                return;
            }

            var w = new WindowMessege(t);
            w.ShowDialog();
        }

        private void Button_Click_ClearFilter(object sender, RoutedEventArgs e)
        {
            filter.BlockSerch.SerchAddress = "";
            filter.BlockSerch.SerchPhone = "";
            filter.BlockSerch.SerchName = "";
            filter.BlockSerch.SerchEmail = "";
            filter.BlockSerch.SerchServic = new List<services>();

            __address.Text = "";
            __phone.Text = "";
            __name.Text = "";
            __email.Text = "";
            __serchList.ItemsSource = null;

            __list.ItemsSource = filter.GetList();
        }

        private void Button_Click_RegUser(object sender, RoutedEventArgs e)
        {
            var w = new WindowRegUser();
            w.Closing += (object send, System.ComponentModel.CancelEventArgs ev) => __list.ItemsSource = filter.GetList();
            w.ShowDialog();
        }

        private void Button_Click_RegWorker(object sender, RoutedEventArgs e)
        {
            var w = new WindowRegWorker();
            w.Closing += (object send, System.ComponentModel.CancelEventArgs ev) => __list.ItemsSource = filter.GetList();
            w.ShowDialog();

        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            if (Manager.User.id_role == 2)
            {
                var w = new WindowMyProfileWorker();
                w.Closing += (object send, System.ComponentModel.CancelEventArgs ev) => __list.ItemsSource = filter.GetList();
                w.ShowDialog();
            }
            else
            {
                var w = new WindowMyProfileClient();
                w.Closing += (object send, System.ComponentModel.CancelEventArgs ev) => __list.ItemsSource = filter.GetList();
                w.ShowDialog();
            }
        }

        private void Button_Click_MessageProf(object sender, RoutedEventArgs e)
        {

            var w = new WindowMessege(-1);
            w.ShowDialog();
        }
    }
}