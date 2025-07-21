using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace Natariys.classes
{
    internal class Filter
    {
        public List<UserWork> RootList = new List<UserWork>();
        public BlockSerch BlockSerch = new BlockSerch();

        public Filter()
        {
            DB.entity.users.ToList().ForEach(u => RootList.Add(new UserWork(u)));
        }

        public List<UserWork> GetList()
        {
            var filterList = new List<UserWork>();

            filterList = RootList.FindAll(u =>
                u.id_role == 2
                && (u.first_name.ToLower().Contains(BlockSerch.SerchName) || u.last_name.ToLower().Contains(BlockSerch.SerchName) || u.sur_name.ToLower().Contains(BlockSerch.SerchName))
                && u.Address.ToLower().Contains(BlockSerch.SerchAddress)
                && u.Phone.ToLower().Contains(BlockSerch.SerchPhone)
                && u.Email.ToLower().Contains(BlockSerch.SerchEmail)
            );
            var res1 = BlockSerch.SerchServic.Count < 1 ;
            
            var temp = filterList.FindAll(uw => res1 ? true : uw.Services.Any(ser => BlockSerch.SerchServic.Any(s => s.id == ser.id)));

            return temp;
        }

        public void Reloud()
        {
            RootList.Clear();
            DB.entity.users.ToList().ForEach(u => RootList.Add(new UserWork(u)));
        }
    }
}
