using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class Collectable : GameObject
    {
        public Collectable(string name, float x, float y, float z) 
        {
            this.Name = name;
            this.SetPosition(x, y, z);
            IsCollisionObject = false;
            IsShadowCaster = true;
            this.SetColor(0, 1, 0);
        }

        public override void Act()
        {
           
        }
    }
}
