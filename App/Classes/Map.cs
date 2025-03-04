using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class Map : GameObject
    {
        public Map(string name, float x, float y, float z)
        {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.FlowFieldCost = 255;
        }
        public override void Act()
        {
        }
    }
}
