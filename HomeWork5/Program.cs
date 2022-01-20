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
                if (duck is Quackable)
                {
                    Console.WriteLine((duck as Quackable).Quack());
                }
                if (duck is Flyable)
                {
                    Console.WriteLine((duck as Flyable).Fly());
                }
                if(duck is MallardDuck)
                {
                    Console.WriteLine((duck as MallardDuck).Swim());
                }
            }
        }
    }
}
