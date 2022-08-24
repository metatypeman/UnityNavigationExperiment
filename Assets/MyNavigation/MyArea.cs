using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MyNavigation
{
    public class MyArea: MyBaseElementaryArea, IMyArea
    {
        public override bool IsMyArea => true;
        public override IMyArea AsMyArea => this;
    }
}
