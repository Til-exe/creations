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
        public Player(string name, float x, float y, float z)
        {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(1, 0, 0);
            this.IsCollisionObject = true;
        }

        float speed = 0.05f;
        private string _status = "stand";   // Drei Status für stehen, springen, fallen
        private float _velocity = 0;        // Sprungkraft der Figur (wird verändert)
        private float _gravity = 0.001f;    // Gravitation (bleibt immer gleich)
        public override void Act()
        {
            /*Console.WriteLine(Position);
            if (this.Position.Y !< 1)
            {
                SetPosition(this.Position.X, this.Position.Y - 0.04f, this.Position.Z);
            }*/

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
