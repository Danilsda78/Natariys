using Natariys.data;

namespace Natariys.classes
{
    public static class DB
    {
        public static NatariysDBEntities1 entity { get; private set; }

        public static void Init()
        {
            entity = new NatariysDBEntities1();
        }
    }
}
