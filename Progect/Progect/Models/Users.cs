namespace Progect.Models
{
    public class Users
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string OtherDatails { get; set; }
    }
}
