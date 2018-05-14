namespace Database.Model
{
    public class Policeman
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Nick { set; get; }
        public double X { set; get; }
        public double Y { set; get; }

        public Policeman(string name, string nick)
        {
            Name = name;
            Nick = nick;
        }
        public Policeman() { }
    }
}