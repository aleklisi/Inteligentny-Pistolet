using System;

namespace Database.Model
{
    public class Policeman : IEquatable<Policeman>
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

        public Policeman()
        {
        }

        public bool Equals(Policeman other)
        {
            if (Name.Equals(other.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int hashProductName = Name == null ? 0 : Name.GetHashCode();

            int hashProductCode = Id.GetHashCode();

            return hashProductName ^ hashProductCode;
        }

    }
}