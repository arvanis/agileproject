using System.Collections.Generic;

namespace ImNew
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
    }
}
  