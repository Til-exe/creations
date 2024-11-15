using KWEngine3;
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
            this.SetModel("KWSphere"); // KWCube
            this.Name = name;
            this.SetPosition(x, y, z);
            this.IsCollisionObject = false;
            this.IsShadowCaster = true;
            this.SetColor(0, 1, 0);

            LightObject l = new LightObject(LightType.Point, ShadowQuality.NoShadow);
            l.Name = name;
            l.SetPosition(x, y, z);
            l.SetNearFar(0.1f, 25f);
            l.SetColor(0f, 1f, 0f, 10f);
            CurrentWorld.AddLightObject(l);
        }

        public override void Act()
        {
           
        }
    }
}
