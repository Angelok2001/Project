using Microsoft.SqlServer.Management.Smo;

namespace Progect.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleDescription { get; set; }
        public bool CrudeValue { get; set; }
        public List<Users> Users { get; set; }
        public List<Documents> Documents { get; set; }
    }

}
