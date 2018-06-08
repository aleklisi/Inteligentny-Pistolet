using System;

namespace Examples
{
    public class Car
    {
        internal string CarBrand;
        internal string OwnerName;
        private int _age;

        public int Age
        {
            get
            {
                //DLA PRZYKŁADU LazyLoadingIdea ODKOMENTOWAC!!!
                //Console.WriteLine("Getting Age");
                return _age;
            }
            set => _age = value;
        }

        public Car(string brand, string name, int age)
        {
            CarBrand = brand;
            OwnerName = name;
            _age = age;
        }

    }
}