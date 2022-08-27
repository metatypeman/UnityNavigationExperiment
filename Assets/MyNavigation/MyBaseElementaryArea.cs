using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyNavigation
{
    public abstract class MyBaseElementaryArea: MyAbstractArea
    {
        public override Vector3 CentralPoint => transform.position;
    }
}
