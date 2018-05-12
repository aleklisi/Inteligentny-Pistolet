namespace SmartGunWeb.Core
{
    public class Policeman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Status Status { get; set; }

        public Policeman()
        {

        }

        public Policeman(int id, string pass)
        {
            Id = id;
            Password = pass;
            Status = Status.Ok;
        }

        public Policeman(int id, string name, Status status ,string pass)
        {
            Id = id;
            Password = pass;
            Name = name;
            Status = status;
        }

    }
}