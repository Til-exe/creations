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
using Assimp;
using System.Threading.Tasks;
using System.IO;

namespace Gruppenprojekt.App.Classes
{
    public class Player : GameObject
    {
        bool flashlight = false;
        private LightObject _flashlight;
        
        HUDObjectText m1 = new HUDObjectText("Zurück zum Spiel");
        HUDObjectText m2 = new HUDObjectText("Hauptmenu");
        HUDObjectText m3 = new HUDObjectText("Verlassen");
        HUDObjectImage bg = new HUDObjectImage("./App/Textures/blackscreen.png");
        HUDObjectText mtitle = new HUDObjectText("Pausiert");
        private HUDObjectText colCount;
        private int counter = 0;
        public Player(string name, float x, float y, float z)
        {
            Globals.gameRunning = true;
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(1, 0, 0);
            this.SetScale(1, 2, 1);
            this.IsCollisionObject = true;
            
            //Taschenlampe
            _flashlight = new LightObject(LightType.Directional, ShadowQuality.Low);
            _flashlight.Name = "flashlight";
            _flashlight.SetNearFar(0.1f, 18f);
            _flashlight.SetColor(0, 0, 0, 0);
            _flashlight.SetFOV(140);
            CurrentWorld.AddLightObject(_flashlight);
            

            colCount = new HUDObjectText("Sie haben kein Licht");
            colCount.Name = "BLA";
            colCount.SetPosition(350f, 32f);
            colCount = new HUDObjectText("");
            colCount.Name = "ORBS";
            colCount.SetPosition(290f, 20f);
            colCount.SetFont(FontFace.NovaMono);
            colCount.SetScale(30f);
            colCount.SetOpacity(0);
            CurrentWorld.AddHUDObject(colCount);


            mtitle.Name = "PAUSE";                       
            mtitle.SetPosition(160f, 100f);          
            mtitle.SetScale(100f);                       
            mtitle.SetCharacterDistanceFactor(1.0f);            
            mtitle.SetColor(1.0f, 0.0f, 0.0f);

            bg.Name = "background";
            bg.SetScale(Window.Width, Window.Height);
            bg.SetColor(0, 0, 0);
            bg.CenterOnScreen();
            bg.SetZIndex(-100);
            bg.SetOpacity(0.65f);

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
        

        bool Sprinting = false;
        int k = 0;
        int l = 0;
        int r = 0;

        float nextTimeFlicker = -1;



        public override void Act()
        {
            if(nextTimeFlicker > 0)
            {
                if(WorldTime >= nextTimeFlicker)
                {
                    _flashlight.SetColor(0, 0, 0, 0);

                }
            }
                


            Random rnd = new Random();
            int random = rnd.Next(20000);
            _flashlight.SetPosition(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVectorLocalRight);
            _flashlight.SetTarget(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector * 100); // KAR: Taschenlampe muss weiiiiit in die Ferne schauen
            if (random == 69 || Keyboard.IsKeyPressed(Keys.Space))
            {
                Console.WriteLine("TASCHENLAMPE AUS IN EINER SEKUNDE");
                nextTimeFlicker = WorldTime + 1f; // Beispiel: nächster Zeitpunkt 2.018

                /*
                Random timer = new Random();
                int delay = timer.Next(100);
                _flashlight.SetColor(0, 0, 0, 0);
                if (delay == 50)
                {

                }
                if (delay == 1)
                {
                    _flashlight.SetColor(1, 1, 1, 4);
                }
                */

                /*
                await Task.Delay(18);
                
                await Task.Delay(6);
                _flashlight.SetColor(0, 0, 0, 0);
                await Task.Delay(21);
                _flashlight.SetColor(1, 1, 1, 4);
                await Task.Delay(9);
                _flashlight.SetColor(0, 0, 0, 0);
                await Task.Delay(13);
                _flashlight.SetColor(1, 1, 1, 4);
                await Task.Delay(10);
                _flashlight.SetColor(0, 0, 0, 0);
                flashlight = false;
                */
            }
            if (Keyboard.IsKeyPressed(Keys.F) && flashlight == false)
            {
                _flashlight.SetColor(1, 1, 1, 4);
                flashlight = true;
                Console.WriteLine("Penis an");
            }
            else if (Keyboard.IsKeyPressed(Keys.F) && flashlight == true)
            {
                _flashlight.SetColor(0, 0, 0, 0);
                flashlight = false;
                Console.WriteLine("Penis aus");
            }


            bool k = false;
            //Sprinting
            if (k == false) 
            {
                if (Keyboard.IsKeyDown(Keys.LeftShift)) { Globals.Sprinting = true; }
                else { Globals.Sprinting = false; }
            }        
            //Sprint Toggle
            if (Keyboard.IsKeyPressed(Keys.CapsLock))
            {
                if (k == false)
                {
                    k = true;
                }
                else
                {  k = false;}
                Globals.Sprinting = true;
                
            }
            //Player speed regeln
            if(Globals.Sprinting)
            {
                Globals.speed = 0.105f;
            }
            else
            {
                Globals.speed = 0.05f;
            }

            //Movement
            int forward = 0;
            int strafe = 0;
            if (Globals.gameRunning)
            {
                if (Keyboard.IsKeyDown(Keys.W)) { forward += 1; }
                if (Keyboard.IsKeyDown(Keys.D)) { strafe += 1; }
                if (Keyboard.IsKeyDown(Keys.A)) { strafe -= 1; }
                if (Keyboard.IsKeyDown(Keys.S)) { forward -= 1; Globals.speed = 0.05f; }
                
            }

            //pause Menu
            if (Keyboard.IsKeyPressed(Keys.Escape) || Keyboard.IsKeyPressed(Keys.Tab))
            {
                stop();
            }


            if (Keyboard.IsKeyPressed(Keys.Q))
            {
                weiter();
            }


            //minimap
            if (Keyboard.IsKeyDown(Keys.R)) { /*Minimap*/ }

            //pause Menu Button Use
            if (m1 != null)
            {   //Weiter spielen
                if (m1.IsMouseCursorOnMe() == true)
                {
                    m1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    m1.SetColorEmissiveIntensity(0.0f);
                }
                if ((Mouse.IsButtonPressed(MouseButton.Left) && m1.IsMouseCursorOnMe() == true))
                {
                    CurrentWorld.MouseCursorResetPosition();
                    
                    weiter();
                }
            }
            if (m2!= null)
            {   //Hauptmenu
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
                    Globals.Trys++;
                    //string path = @"F:\.Programming\Repositys\Gruppenprojekt\App\data\data.txt";    //Zuhause
                    //path = @"C:\Users\Til.Stuckenberg\source\GAME\App\data\data.txt";    //Schule
                    string path = @"./App/data/data.txt";
                    string appendText = Convert.ToString(Globals.Score) + "\n";
                    File.AppendAllText(path, appendText);
                }
            }
            if (m3 != null)
            {   //Anwendung Verlassen / schließen
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

            //Einsammeln von Collectable's
            List<Intersection> intersections = GetIntersections();
            foreach (Intersection i in intersections)
            {
                GameObject collider = i.Object;
                if (collider is Enemy)
                {
                    //spieler kollidiert mit Enemy
                }
                Vector3 mtv = i.MTV;
                MoveOffset(mtv);
                if (collider is Collectable)
                {
                    (collider as Collectable).KillMe();
                    counter = counter + 1;
                    colCount.SetText("Gesammelte Orbs: " + counter);
                    /*
                    if (counter == 1)
                    {
                        colCount.SetText("Sie haben " + counter + " Licht");
                    }
                    else if (counter > 1)
                    {
                        colCount.SetText("Sie haben " + counter + " Lichter");
                    }
                    */
                }
            }
            
        }


        public void Camera(int forward, int strafe)
        {
            if (Globals.gameRunning)
            {
                CurrentWorld.AddCameraRotationFromMouseDelta();
                CurrentWorld.UpdateCameraPositionForFirstPersonView(Center, 2f);
                MoveAndStrafeAlongCameraXZ(forward, strafe, Globals.speed);
                TurnTowardsXZ(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector);
            }
            

        }
        public void removeAllHUD() 
        {
            CurrentWorld.RemoveHUDObject(bg);
            CurrentWorld.RemoveHUDObject(m1);
            CurrentWorld.RemoveHUDObject(m2);
            CurrentWorld.RemoveHUDObject(m3);
            CurrentWorld.RemoveHUDObject(mtitle);

        }
        public void stop()
        {
            Globals.gameRunning = false;
            CurrentWorld.MouseCursorReset();
            CurrentWorld.MouseCursorResetPosition();
            CurrentWorld.AddHUDObject(m1);
            CurrentWorld.AddHUDObject(m2);
            CurrentWorld.AddHUDObject(m3);
            CurrentWorld.AddHUDObject(bg);
            CurrentWorld.AddHUDObject(mtitle);
        }
        public void weiter()
        {
            Globals.gameRunning = true;            
            CurrentWorld.MouseCursorGrab();
            removeAllHUD();
        }
        


    }

}
