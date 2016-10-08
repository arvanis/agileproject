using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImNew.Infrastructure
{
    class DtoUserDetails
    {
        public List<string> Technologies { get; set; }              
        public string Role { get; set; }
        public string Hobbies { get; set; }
        public string About { get; set; }
    }
}
