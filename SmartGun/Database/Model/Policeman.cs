namespace Database.Model
{
    public class Policeman
    {
        public int Id;
        public readonly string Name;
        public readonly string Nick;
        public int X;
        public int Y;

        public Policeman(string name, string nick)
        {
            Name = name;
            Nick = nick;
        }
    }
}