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
        }
    }
}
