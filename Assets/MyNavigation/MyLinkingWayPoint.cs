using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MyNavigation
{
    public class MyLinkingWayPoint: MyBaseElementaryArea, IMyLinkingWayPoint
    {
        public override bool IsMyLinkingWayPoint => true;
        public override IMyLinkingWayPoint AsMyLinkingWayPoint => this;
    }
}
