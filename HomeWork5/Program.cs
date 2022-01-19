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
                if (duck is RedheadDuck)
                {
                    RedheadDuck redheadDuck = duck as RedheadDuck;
                    Console.WriteLine(redheadDuck.Display());
                    Console.WriteLine(redheadDuck.Fly());
                    Console.WriteLine(redheadDuck.Quack());
                }
                if (duck is MallardDuck)
                {
                    MallardDuck mallardDuck = duck as MallardDuck;
                    Console.WriteLine(mallardDuck.Display());
                    Console.WriteLine(mallardDuck.Fly());
                    Console.WriteLine(mallardDuck.Quack());
                }
            }
        }
    }
}
