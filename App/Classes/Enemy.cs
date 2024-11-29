using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class Enemy: GameObject
    {
        public Enemy(string name, float x, float y, float z) {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(0f, 0f, 1f);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetScale(1, 5, 1);




        }

        public override void Act()
        {
            
        }
    }
}
