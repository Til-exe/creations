using glTFLoader.Schema;
using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class Floor:GameObject
    {
        public Floor(string name, float x, float y, float z) {
            this.Name = Name;
            this.SetPosition(x, y, z);
            this.IsCollisionObject = true;
            this.IsAffectedByLight = true;
            this.IsShadowCaster = true;
            this.SetScale(75f, 1f, 100f);
            this.SetTextureRepeat(75, 100);
        }
        public override void Act()
        {            
        }
    }
}
