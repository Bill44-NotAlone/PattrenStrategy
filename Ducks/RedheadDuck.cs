using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            flyable = new FlyWithWings();
            quackable = new DQuack();
        }
    }
}
