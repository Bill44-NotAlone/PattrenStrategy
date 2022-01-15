using System;
using System.Collections.Generic;

namespace Duck
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>() { new RedheadDuck(), new MallardDuck() };
            foreach(Duck duck in ducks) Console.WriteLine(duck.Quack()+" "+duck.Swim()+" "+duck.Display());
            
        }
    }

    public abstract class Duck
    {
        public string Quack()
        {
            return "Quack " + this.GetType();
        }
        public string Swim()
        {
            return "Swim " + this.GetType();
        }
        public abstract string Display();
    }
    public class MallardDuck : Duck
    {
        public override string Display()
        {
            return "Display " + this.GetType();
        }
    }
    public class RedheadDuck : Duck
    {
        public override string Display()
        {
            return "Display " + this.GetType();
        }
    }
}
