using Natariys.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natariys.classes
{
    internal class UserWork : users
    {
        public string Address { get; set; }
        public string Email { get => email; set => email = value != null ? value : ""; }
        public string Phone { get => phone; set => phone = value != null ? value : ""; }
        public List<services> Services { get; set; }

        public UserWork() { }
        public UserWork(users user)
        {
            id = user.id;
            id_role = user.id_role;
            login = user.login;
            password = user.password;
            img_path = user.img_path;
            first_name = user.first_name;
            last_name = user.last_name;
            sur_name = user.sur_name;
            phone = user.phone;
            email = user.email;
            Services = user.services.ToList();
            address = user.address;

            Address = address != null ? address.name : "";
        }
    }
}
