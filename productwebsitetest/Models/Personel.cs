namespace productwebsitetest.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AllowedPermitCount { get; set; }
        public string Password { get; set; }
        public int ActiveStatus { get; set; }
        public string Email { get; set; }
        public int TotalPermitCount { get; set; }
    }
}
