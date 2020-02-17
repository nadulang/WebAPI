namespace Group2Contact.Model
{
    public class ContactRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Full_name { get; set; }
    }

    public class UserContact : ContactRequest
    {
        public int Id { get; set; }
    }
}