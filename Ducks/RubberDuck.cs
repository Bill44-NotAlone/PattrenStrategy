using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public class RubberDuck : Duck, Quackable
    {
        public override string Display()
        {
            return "Display " + this.GetType();
        }

        public string Quack()
        {
            return "Quack " + this.GetType();
        }
    }
}
