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
using OpenTK.Windowing.Common.Input;

namespace Gruppenprojekt.App.Classes
{
    public class Player : GameObject
    {
        HUDObjectText m1 = new HUDObjectText("Zurück zum Spiel");
        HUDObjectText m2 = new HUDObjectText("Hauptmenu");
        HUDObjectText m3 = new HUDObjectText("LEAVE");
        public Player(string name, float x, float y, float z)
        {
            
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(1, 0, 0);
            this.IsCollisionObject = true;

            m1.SetPosition(160f, 200f);
            m1.Name = "Weiter";
            m1.SetCharacterDistanceFactor(1.0f);
            m1.SetColor(1.0f, 0.0f, 0.0f);
            m1.SetColorEmissive(1.0f, 1.0f, 1.0f);

            m2.SetPosition(160f, 250f);
            m2.Name = "Menu";
            m2.SetCharacterDistanceFactor(1.0f);
            m2.SetColor(1.0f, 0.0f, 0.0f);
            m2.SetColorEmissive(1.0f, 1.0f, 1.0f);

            m3.SetPosition(160f, 300f);
            m3.Name = "Leave";
            m3.SetCharacterDistanceFactor(1.0f);
            m3.SetColor(1.0f, 0.0f, 0.0f);
            m3.SetColorEmissive(1.0f, 1.0f, 1.0f);
        }

        


        float speed = 0.05f;
        bool gameRunning = true;
        bool Sprinting = false;
        int k = 0;
        public override void Act()
        {
            




            //Sprinting
            if (k == 0) 
            {
                if (Keyboard.IsKeyDown(Keys.LeftShift)) { Sprinting = true; }
                else { Sprinting = false; }
            }           
            if (Keyboard.IsKeyPressed(Keys.CapsLock))
            {
                if (k == 0)
                {
                    k = 1;
                }
                else
                {  k = 0;}
                Sprinting = true;
                
            }
            if(Sprinting)
            {
                speed = 0.105f;
            }
            else
            {
                speed = 0.05f;
            }

            //Movement
            int forward = 0;
            int strafe = 0;
            if (gameRunning)
            {
                if (Keyboard.IsKeyDown(Keys.W)) { forward += 1; }
                if (Keyboard.IsKeyDown(Keys.D)) { strafe += 1; }
                if (Keyboard.IsKeyDown(Keys.A)) { strafe -= 1; }
                if (Keyboard.IsKeyDown(Keys.S)) { forward -= 1; speed = 0.05f; }
            }
            
            if (Keyboard.IsKeyDown(Keys.Escape) || Keyboard.IsKeyDown(Keys.Tab))
            {
                stop();
            }
            if (m1 != null)
            {
                if (m1.IsMouseCursorOnMe() == true)
                {
                    m1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    m1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && m1.IsMouseCursorOnMe() == true)
                {
                    weiter();
                }
            }
            if (m2!= null)
            {
                if (m2.IsMouseCursorOnMe() == true)
                {
                    m2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    m2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && m2.IsMouseCursorOnMe() == true)
                {
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);

                }
            }
            if (m3 != null)
            {
                if (m3.IsMouseCursorOnMe() == true)
                {
                    m3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    m3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && m3.IsMouseCursorOnMe() == true)
                {
                    Window.Close();

                }
            }



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
            if (gameRunning)
            {
                CurrentWorld.AddCameraRotationFromMouseDelta();
                CurrentWorld.UpdateCameraPositionForFirstPersonView(Center, 2f);
                MoveAndStrafeAlongCameraXZ(forward, strafe, speed);
                TurnTowardsXZ(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector);
            }
            

        }
        public void removeAllHUD() 
        {
            CurrentWorld.RemoveHUDObject(m1);
            CurrentWorld.RemoveHUDObject(m2);
            CurrentWorld.RemoveHUDObject(m3);
        }
        public void stop()
        {
            gameRunning = false;
            CurrentWorld.MouseCursorReset();
            CurrentWorld.MouseCursorResetPosition();
            CurrentWorld.AddHUDObject(m1);
            CurrentWorld.AddHUDObject(m2);
            CurrentWorld.AddHUDObject(m3);
        }
        public void weiter()
        {
            gameRunning = true;
            CurrentWorld.MouseCursorGrab();
            removeAllHUD();
        }



    }

}
