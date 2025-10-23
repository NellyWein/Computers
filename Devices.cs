using System;

namespace Catalog
{
    // Персональный ПК
    public class PersonalComputer : Computer
    {
        public PersonalComputer(string man = "Unknown", string mod = "Unknown", double pr = 0.0, int r = 0)
            : base(man, mod, pr, r)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Персональный компьютер:");
            base.PrintInfo();
        }

        public override string GetTypeName() => "Персональный ПК";
    }

    // Ноутбук
    public class Laptop : Computer
    {
        public Laptop(string man = "Unknown", string mod = "Unknown", double pr = 0.0, int r = 0)
            : base(man, mod, pr, r)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Ноутбук:");
            base.PrintInfo();
        }

        public override string GetTypeName() => "Ноутбук";
    }
}
