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
            IsCollisionObject = true;
            IsAffectedByLight = true;         
            this.SetScale(150,1 ,150 );
            SetTexture("./Textures/wood1.jpg");
        }


        public override void Act()
        {
            
        }
    }
}
