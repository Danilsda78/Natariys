using Natariys.classes;
using Natariys.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Natariys.windows
{
    /// <summary>
    /// Логика взаимодействия для WindowMessege.xaml
    /// </summary>
    public partial class WindowMessege : Window
    {
        private int _idReseiver = -1;

        public WindowMessege(int idUser)
        {
            InitializeComponent();

            if (idUser != -1)
                OpenReceiver(idUser);

            ReloudSidebar();
        }

        private void __listDialog_Selected(object sender, RoutedEventArgs e)
        {
            var user = (sender as ListBox).SelectedItem as users;

            OpenReceiver(user.id);
        }

        private void ReloudSidebar()
        {
            var allMess = DB.entity.message.ToList().FindAll(m => m.receiver == Manager.User.id || m.sender == Manager.User.id);
            List<int> noDublUsers = new List<int>();
            allMess.ForEach(i => { noDublUsers.Add(i.sender); noDublUsers.Add(i.receiver); });
            noDublUsers = noDublUsers.Distinct().ToList();

            noDublUsers.Remove(Manager.User.id);
            __listDialog.ItemsSource = DB.entity.users.ToList().FindAll(u => noDublUsers.Any(id => u.id == id));
        }

        private void OpenReceiver(int idReseiver)
        {
            var list = DB.entity.message.ToList().FindAll(m => m.sender == Manager.User.id && m.receiver == idReseiver || m.receiver == Manager.User.id && m.sender == idReseiver);

            var set = new List<MessageItemModel>();
            list.ForEach(m => set.Add(new MessageItemModel(m, idReseiver)));

            __messagesList.ItemsSource = set;
            __messageProfile.DataContext = DB.entity.users.First(u => u.id == idReseiver);
            _idReseiver = idReseiver;
            __scroll.ScrollToEnd();

            ReloudSidebar();
            __messageTxt.Text = "";
        }

        private void Button_Click_SendMessage(object sender, RoutedEventArgs e)
        {
            if (_idReseiver == -1)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }

            if (__messageTxt.Text == "")
            {
                MessageBox.Show("Нельзя отправлять пустые сообщения!");
                return;
            }

            var newMess = new message()
            {
                datetime = DateTime.Now,
                receiver = _idReseiver,
                sender = Manager.User.id,
                text = __messageTxt.Text,
            };

            DB.entity.message.Add(newMess);

            DB.entity.SaveChanges();
            OpenReceiver(_idReseiver);
        }

        private void Button_Click_ProfileReceiver(object sender, RoutedEventArgs e)
        {
            if (_idReseiver == -1)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }

            var user = DB.entity.users.ToList().Find(u => u.id == _idReseiver);
            if (user.id_role == 1)
            {
                var w = new WindowProfileClient(user);
                w.ShowDialog();
            }
            else
            {
                var w = new WindowProfileWorker(user);
                w.ShowDialog();
            }
        }
    }
}

public class MessageItemModel
{
    public string Date { get; set; }
    public string Time { get; set; }
    public string Style { get; set; }
    public string Text { get; set; }

    public MessageItemModel(message message, int id_receiver)
    {
        Date = message.datetime.ToString("g");
        Time = message.datetime.TimeOfDay.ToString();
        Style = message.receiver == id_receiver ? "Right" : "Left";
        Text = message.text;
    }
}
