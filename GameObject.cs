using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class GameObject
    {
        public int x;
        public int y;
        public char avatar = '%';
        public string name;

        public string GetName()
        {
            return name;
        }
    }
}
