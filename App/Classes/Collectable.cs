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
        private LightObject l;
        public Collectable(string name, float x, float y, float z) 
        {
            this.SetModel("KWSphere"); // KWCube
            this.Name = name;
            this.SetPosition(x, y, z);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetColor(0, 1, 0);

            l = new LightObject(LightType.Point, ShadowQuality.NoShadow);
            l.Name = name;
            l.SetPosition(x, y, z);
            l.SetNearFar(0.1f, 8f);
            l.SetColor(0f, 1f, 0f, 10f);
            
            CurrentWorld.AddLightObject(l);
        }

        public void KillMe()
        {
            Globals.Score+=100;
            CurrentWorld.RemoveGameObject(this);
            CurrentWorld.RemoveLightObject(l);

            ExplosionObject ex = new ExplosionObject(128, 0.5f, 4f, 2.0f, ExplosionType.Skull);
            ex.SetAlgorithm(ExplosionAnimation.WindUp);
            ex.SetColorEmissive(0, 1, 0, 2);
            ex.SetPosition(this.Position);
            CurrentWorld.AddExplosionObject(ex);

            if(CurrentWorld is GameWorldStart)
            {
                (CurrentWorld as GameWorldStart).UpdateHUDLastUpdateTime();
            }
        }
        bool movingUp = true;
        float ColMovementSpeed = 0.007f;
        public override void Act()
        {
            
            if(Globals.gameRunning)
            {
                this.SetRotation(this.Rotation.X + 0.01f,0,0);
                if (movingUp && this.Position.Y < 4)
                {
                    if (this.Position.Y > 4) { }
                    this.MoveOffset(0, ColMovementSpeed, 0) ;
                    
                }
                if (this.Position.Y >= 4)
                {
                    movingUp = false;
                }
                if (movingUp == false && this.Position.Y > 2)
                {
                    this.MoveOffset(0, -ColMovementSpeed, 0);
                }
                if (this.Position.Y <= 2)
                {
                    movingUp = true;
                }
            }
            

        }
    }
}
