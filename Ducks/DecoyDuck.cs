using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            flyable = new FlyNoWay();
            quackable = new MuteQuack();
        }
    }
}
