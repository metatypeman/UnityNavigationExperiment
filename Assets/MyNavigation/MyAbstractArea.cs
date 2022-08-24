using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyNavigation
{
    public abstract class MyAbstractArea : MonoBehaviour, IMyAbstractArea
    {
        void Awake()
        {
            //tag = "MyNavigation";
        }

        void OnGUI()
        {
            //tag = "MyNavigation";
        }

        public abstract Vector3 CentralPoint { get; }

        public virtual bool IsMyArea => false;
        public virtual IMyArea AsMyArea => null;
        public virtual bool IsMyWay => false;
        public virtual IMyWay AsMyWay => null;
        public virtual bool IsMyLinkingWayPoint => false;
        public virtual IMyLinkingWayPoint AsMyLinkingWayPoint => null;
        public virtual bool IsMyWayPoint => false;
        public virtual IMyWayPoint AsMyWayPoint => null;
    }
}
