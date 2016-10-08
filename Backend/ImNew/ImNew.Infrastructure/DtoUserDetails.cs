using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImNew.Infrastructure
{
    public class DtoUserDetails
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { set; get; }

        public List<string> Technologies { get; set; }  
                    
        public string Role { get; set; }
        public int RoleId { get; set; }

        public List<string> Hobbies { get; set; }
        public string About { get; set; }
    }
}
