using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Gruppenprojekt.App.Classes
{
    public class Player : GameObject
    {
        private HUDObjectText colCount;
        private int counter = 0;
        public Player(string name, float x, float y, float z)
        {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(1, 0, 0);
            this.SetScale(1, 2, 1);
            this.IsCollisionObject = true;
            
            colCount = new HUDObjectText("Sie haben kein Licht");
            colCount.Name = "BLA";
            colCount.SetPosition(350f, 32f);
            colCount.SetFont(FontFace.NovaMono);
            colCount.SetScale(30f);
            colCount.SetOpacity(0);
            CurrentWorld.AddHUDObject(colCount);
        }

        float speed = 0.05f;
        public override void Act()
        {
            //Sprinting
            if (Keyboard.IsKeyDown(Keys.LeftShift)) { speed = 0.105f; }
            else { speed = 0.05f; }

            //Movement
            int forward = 0;
            int strafe = 0;
            if (Keyboard.IsKeyDown(Keys.W)) { forward += 1; }
            if (Keyboard.IsKeyDown(Keys.D)) { strafe += 1; }
            if (Keyboard.IsKeyDown(Keys.A)) { strafe -= 1; }
            if (Keyboard.IsKeyDown(Keys.S)) { forward -= 1; speed = 0.05f; }

            //Escape Menu       Keine Funktion bis Jetzt
            if (Keyboard.IsKeyDown(Keys.Escape)) { }        

            //Die Methode ist da um den Code übersichtlicher zu machen
            Camera(forward, strafe);
            List<Intersection> intersections = GetIntersections();
            foreach (Intersection i in intersections)
            {
                GameObject collider = i.Object;
                if (collider is Enemy)
                {
                    KWEngine.LogWriteLine("Jeremy");
                }
                Vector3 mtv = i.MTV;
                MoveOffset(mtv);
                if (collider is Collectable)
                {
                    (collider as Collectable).KillMe();
                    counter = counter + 1;
                    
                    
                        
                    
                     if(counter == 1)
                    {
                        colCount.SetText("Sie haben " + counter + "Licht");
                    }
                    else if (counter > 1)
                    {
                        colCount.SetText("Sie haben " + counter + "Lichter");
                    }
                    
                }
            }
        }
        public void Camera(int forward, int strafe)
        {
            CurrentWorld.AddCameraRotationFromMouseDelta();
            CurrentWorld.UpdateCameraPositionForFirstPersonView(Center, 2f);
            MoveAndStrafeAlongCameraXZ(forward, strafe, speed);
            TurnTowardsXZ(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector);

        }


    }

}
