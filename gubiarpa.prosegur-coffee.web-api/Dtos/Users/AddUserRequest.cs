namespace gubiarpa.prosegur_coffee.web_api.Dtos.Users
{
    public class AddUserRequest
    {
        public string DocumentNumber { get; set; }
        public string Fullname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
