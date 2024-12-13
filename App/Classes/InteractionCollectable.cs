using KWEngine3;
using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class InteractionCollectable : GameObject
    {
        Random rnd = new Random();
        public LightObject l;
        bool movingUp = true;
        float ColMovementSpeed = 0.007f;
        public InteractionCollectable(string name, float x, float y, float z)
        {
            this.SetModel("KWSphere"); // KWCube
            this.Name = name;
            this.SetPosition(x, rnd.Next(1, 5), z);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetColor(0, 1, 0);
            this.SetColorEmissive(1, 0, 0, 10);

            l = new LightObject(LightType.Point, ShadowQuality.NoShadow);
            l.Name = name;
            l.SetPosition(x, y, z);
            l.SetNearFar(0.05f, 7f);
            l.SetColor(1f, 0f, 0f, 10f);

            CurrentWorld.AddLightObject(l);
        }
        public void KillMe(float r, float g, float b, float em)
        {
            TutorialProgressAction();
            Globals.Score += (100 * Globals.multiplikator);
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/Collecting1.wav", false, 0.2f);
            ExplosionObject ex = new ExplosionObject(128, 0.5f, 4f, 2.0f, ExplosionType.Skull);
            ex.SetAlgorithm(ExplosionAnimation.WindUp);
            ex.SetColorEmissive(r, g, b, em);
            ex.SetPosition(this.Position);
            if (CurrentWorld is GameWorldStart)
            {
                (CurrentWorld as GameWorldStart).UpdateHUDLastUpdateTime();
            }            
            CurrentWorld.AddExplosionObject(ex);
            CurrentWorld.RemoveGameObject(this);
            CurrentWorld.RemoveLightObject(this.l);
        }
        public override void Act()
        {
            if (Globals.gameRunning)
            {
                this.SetRotation(this.Rotation.X + 0.01f, 0, 0);
                if (movingUp && this.Position.Y < 4)
                {
                    if (this.Position.Y > 4) { }
                    this.MoveOffset(0, ColMovementSpeed, 0);
                    l.MoveOffset(0, ColMovementSpeed, 0);
                }
                if (this.Position.Y >= 4)
                {
                    movingUp = false;
                }
                if (movingUp == false && this.Position.Y > 2)
                {
                    this.MoveOffset(0, -ColMovementSpeed, 0);
                    l.MoveOffset(0, -ColMovementSpeed, 0);
                }
                if (this.Position.Y <= 2)
                {
                    movingUp = true;
                }
            }
        }
        public static void TutorialProgressAction()
        {
            if(Globals.TutorialProgress == 0) 
            {
                InteractionCollectable ic = new InteractionCollectable("1", 10, 2, 10);
                CurrentWorld.AddGameObject(ic);
                Globals.TutorialProgress = 1;
            }
            if(Globals.TutorialProgress == 1) {
                InteractionCollectable ic = new InteractionCollectable("1", 30, 2, 30);
                CurrentWorld.AddGameObject(ic);
                Globals.TutorialProgress = 2;
            }
            if(Globals.TutorialProgress == 2) { }
            if(Globals.TutorialProgress == 3) { }
            if(Globals.TutorialProgress == 4) { }
            if(Globals.TutorialProgress == 5) { }
        }
    }
}