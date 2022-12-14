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
        int InstanceId { get; }

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
