using System;

namespace Examples
{
    public class Car
    {
        internal string CarBrand;
        internal string OwnerName;
        internal int Age;

        public void Print()
        {
            Console.WriteLine($"{CarBrand}, {OwnerName}, {Age}");
        }

        public Car(string brand, string name, int age)
        {
            CarBrand = brand;
            OwnerName = name;
            Age = age;
        }

    }
}