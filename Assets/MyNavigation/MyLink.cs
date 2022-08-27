using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MyNavigation
{
    public class MyLink
    {
        public MyAbstractArea A { get; set; }
        public MyAbstractArea B { get; set; }

        public override string ToString()
        {
            return $"[{A?.name} <-> {B?.name}]";
        }
    }
}
