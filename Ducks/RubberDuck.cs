using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            flyable = new FlyNoWay();
            quackable = new Squeak();
        }
    }
}
