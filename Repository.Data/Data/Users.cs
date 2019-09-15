using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Data
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string TrueName { get; set; }

        public int Sex { get; set; } = 0;
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Roles { get; set; }

    }
}
