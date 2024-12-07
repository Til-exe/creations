using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class Wall:GameObject
    {
        public Wall(string name , float x, float y ,float z) {
        this.Name = name;
        this.SetPosition(x, y, z);
        this.IsCollisionObject = true;
        this.IsShadowCaster = true;
        this.SetScale(20f, 5f, 1f);
        this.FlowFieldCost = 255;
        this.SetTexture("./app/Textures/wood1.png");
        this.SetTextureRepeat(10f, 3f);
        }
        public override void Act()
        {            
        }
    }
}
