using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public abstract class Duck
    {
        protected IFlyable flyable;
        protected IQuackable quackable;
        public string Swim()
        {
            return "Буль буль буль.";
        }
        public string Display()
        {
            return this.GetType() + " " + flyable.GetType() + " " + quackable.GetType();
        }

        public string Quack()
        {
            return quackable.Quack();
        }

        public string Fly()
        {
            return flyable.Fly();
        }
    }
}
