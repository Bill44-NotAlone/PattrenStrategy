using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    public abstract class Duck
    {
        public string Swim()
        {
            return "Swim " + this.GetType();
        }
        public abstract string Display();
    }
}
