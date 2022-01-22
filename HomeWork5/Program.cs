using System;
using System.Collections.Generic;
using Ducks;

namespace SpaceDuck
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>() {
                new RedheadDuck(), 
                new MallardDuck(), 
                new DecoyDuck(), 
                new RubberDuck()
            };

            for (int i = 0; i< ducks.Count; i++) 
            {
                Duck duck = ducks[i];
                Console.WriteLine(duck.Display());
                Console.WriteLine(duck.Quack());
                Console.WriteLine(duck.Fly());
                Console.WriteLine(duck.Swim());
            }
            Console.WriteLine("=");
            Console.WriteLine("=");
            MallardDuck mallard = (MallardDuck)ducks[1];
            Console.WriteLine(mallard.Quack());
            mallard.SetQuackBehavir(new MuteQuack());
            Console.WriteLine(mallard.Quack());
            mallard.SetQuackBehavir(new Squeak());
            Console.WriteLine(mallard.Quack());
        }
    }
}
