using KWEngine3;
using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{    
    internal class Collectable : GameObject
    {
        Random rnd = new Random();
        public LightObject l;
        bool movingUp = true;
        float ColMovementSpeed = 0.007f;
        
        public Collectable(string name, float x, float y, float z) 
        {
            
            this.SetModel("KWSphere"); // KWCube
            this.Name = name;
            this.SetPosition(x, rnd.Next(1,5), z);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetColor(0, 1, 0);
            this.SetColorEmissive(0, 1, 0, 10);

            l = new LightObject(LightType.Point, ShadowQuality.NoShadow);
            l.Name = name;
            l.SetPosition(x, y, z);
            l.SetNearFar(0.05f, 7f);
            l.SetColor(0f, 1f, 0f, 10f);
            
            CurrentWorld.AddLightObject(l);
        }
        public void KillMe()
        {
            Random rn = new Random();
            Globals.Score+=(100 * Globals.multiplikator);
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/Collecting1.wav", false, 0.2f);

            
            ExplosionObject ex = new ExplosionObject(128, 0.5f, 4f, 2.0f, ExplosionType.Skull);
            ex.SetAlgorithm(ExplosionAnimation.WindUp);
            ex.SetColorEmissive(0, 1, 0, 2);
            ex.SetPosition(this.Position);            

            if(CurrentWorld is GameWorldStart)
            {
                (CurrentWorld as GameWorldStart).UpdateHUDLastUpdateTime();
            }
            if(Globals.choseGamemode== "Infinit")
            {
                Globals.SpawnColByDeath = 1;
            }
            else
            {
                Globals.SpawnColByDeath = 0;
            }
            for (int i = 0; i < Globals.SpawnColByDeath; i++)
            {
                Collectable c = new Collectable("New", rnd.Next(-100, 100), rnd.Next(1, 5), rnd.Next(-100, 100));                
                CurrentWorld.AddGameObject(c);                
            }
            CurrentWorld.AddExplosionObject(ex);

            CurrentWorld.RemoveGameObject(this);
            CurrentWorld.RemoveLightObject(l);
        }
        public override void Act()
        {
            if (Globals.gameRunning)
            {
                this.SetRotation(this.Rotation.X + 0.01f, 0, 0);
                float time = CurrentWorld.WorldTime; 
                float amplitude = 1f; 
                float frequency = 2f;
                float sinusValue = (float)Math.Sin(frequency * time); 
                float newY = 2f + amplitude * sinusValue;        
                this.MoveOffset(0, 1f +newY - this.Position.Y, 0);  
                l.MoveOffset(0, 1f + newY - l.Position.Y, 0);
            }
        }
    }
}