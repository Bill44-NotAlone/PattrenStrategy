using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public class MallardDuck : Duck, Flyable
    {
        public override string Display()
        {
            return "Display " + this.GetType();
        }

        public string Fly()
        {
            return "Fly" + this.GetType();
        }
    }
}
