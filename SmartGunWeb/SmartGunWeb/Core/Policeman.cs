namespace SmartGunWeb.Core
{
    public class Policeman : User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public Policeman()
        {

        }

        public Policeman(int id, string pass)
        {
            Id = id;
            Password = pass;
        }

        public Policeman(int id, string name, string status ,string pass)
        {
            Id = id;
            Password = pass;
            Name = name;
            Status = status;
        }

    }
}