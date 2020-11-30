using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilox2DGameEngine.Character
{
    public abstract class Actor
    {
        public abstract void Destroy(Actor w);

        public abstract void Damge(Actor instigator, int damage);





    }
}
