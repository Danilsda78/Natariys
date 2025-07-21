using Natariys.data;
using System.Collections.Generic;

namespace Natariys.classes
{
    public class BlockSerch
    {
        private string serchAddress = "";
        private string serchName = "";
        private string serchPhone = "";
        private string serchEmail = "";

        public string SerchAddress { get => serchAddress?.ToLower(); set => serchAddress = value; }
        public string SerchName { get => serchName?.ToLower(); set => serchName = value; }
        public string SerchPhone { get => serchPhone?.ToLower(); set => serchPhone = value; }
        public string SerchEmail { get => serchEmail?.ToLower(); set => serchEmail = value; }
        public List<services> SerchServic;

        public BlockSerch()
        {
            SerchServic = new List<services>();
        }
    }
}
