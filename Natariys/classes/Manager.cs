using Natariys.data;

namespace Natariys.classes
{
    internal static class Manager
    {
        private static Filter filter = null;
        public static bool IsAuth = false;
        public static users User  { get; private set; }

        public static void Login(users user)
        {
            var w = App.Current.MainWindow as MainWindow;
            w.Login(user);
            User = user;
            IsAuth = true;
        }

        public static void Logout()
        {
            var w = App.Current.MainWindow as MainWindow;
            w.Logout();
            User = null;
            IsAuth = false;
        }

        public static Filter GetFilter()
        {
            if (filter == null)
            {
                filter = new Filter();
            }

            return filter;
        }
    }
}
