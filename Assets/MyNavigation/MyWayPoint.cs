using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MyNavigation
{
    public class MyWayPoint: MyBaseElementaryArea, IMyWayPoint
    {
        public override bool IsMyWayPoint => true;
        public override IMyWayPoint AsMyWayPoint => this;
    }
}
