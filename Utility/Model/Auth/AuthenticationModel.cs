using Utility.TypeCheck;

namespace Utility.Model.Auth
{
    public class AuthenticationModel
    {
        public AuthenticationModel(int id, string name, string surname, string email, string userRole)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            UserRole = userRole;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; } 

        public List<string> GetUserRoles => UserRole.Split(',').Where(i => !i.Length.IsNullOrEmpty()).Select(i => i.Trim()).ToList();
    }
}