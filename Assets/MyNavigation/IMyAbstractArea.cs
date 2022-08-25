using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyNavigation
{
    public interface IMyAbstractArea
    {
        Vector3 CentralPoint { get; }
        bool ContainsPoint(Vector3 point);

        bool IsMyArea { get; }
        IMyArea AsMyArea { get; }
        bool IsMyWay { get; }
        IMyWay AsMyWay { get; }
        bool IsMyLinkingWayPoint { get; }
        IMyLinkingWayPoint AsMyLinkingWayPoint { get; }
        bool IsMyWayPoint { get; }
        IMyWayPoint AsMyWayPoint { get; }
    }
}
