using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MyNavigation
{
    public class MyWay : MyBaseElementaryArea, IMyWay
    {
        public override bool IsMyWay => true;
        public override IMyWay AsMyWay => this;
    }
}
