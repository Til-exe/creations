using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Common.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using KWEngine3.GameObjects;
using OpenTK.Mathematics;
using System.Diagnostics;
using KWEngine3.Helper;
using System.Threading;
using KWEngine3.Audio;
using KWEngine3;
using System.IO;
using Assimp;
using System;
using Gruppenprojekt.App.Menus;

namespace Gruppenprojekt.App.Classes
{
    public class Player : GameObject
    {
        public Vector3 collectablepos;
        bool flashlight = false;
        private LightObject _flashlight;
        HUDObjectText displayTimer = new HUDObjectText("Timer: ");
        HUDObjectText m1 = new HUDObjectText("Zurück zum Spiel");
        HUDObjectText m2 = new HUDObjectText("Hauptmenu");
        HUDObjectText m3 = new HUDObjectText("Verlassen");
        HUDObjectText score = new HUDObjectText("Punkte");
        HUDObjectImage bg = new HUDObjectImage("./App/Textures/blackscreen.png");
        HUDObjectText mtitle = new HUDObjectText("Pausiert");
        private HUDObjectText colCount;
        private int counter = 0;
        public Player(string name, float x, float y, float z)
        {

            sek = 0;
            removedTime = 0;
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
            colCount.SetPosition(Globals.fensterBreite/2, 32f);
            colCount = new HUDObjectText("");
            colCount.Name = "ORBS";
            colCount.SetPosition(Globals.fensterBreite/2, 20f);
            colCount.SetTextAlignment(TextAlignMode.Center);
            colCount.SetFont(FontFace.NovaMono);
            colCount.SetScale(30f);
            colCount.SetOpacity(0);
            CurrentWorld.AddHUDObject(colCount);


            mtitle.Name = "PAUSE";                       
            mtitle.SetPosition(Globals.fensterBreite/2, 100f);   
            mtitle.SetTextAlignment(TextAlignMode.Center);
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

            displayTimer.SetPosition(50f, 50f);
            displayTimer.Name = "displayTimer";
            displayTimer.SetCharacterDistanceFactor(1.0f);
            displayTimer.SetColor(1.0f, 0.0f, 0.0f);
            CurrentWorld.AddHUDObject(displayTimer);
            


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

            score.SetPosition(700f, 200f);
            score.Name = "Punkte";
            score.SetCharacterDistanceFactor(1.0f);
            score.SetColor(1.0f, 0.0f, 0.0f);

        }
        private Random _random = new Random();
        Random rnd = new Random();
        public bool BOOM = false;
        public bool FirstAct = true;
        private bool _flickering = false;
        bool toggleSprint = false;

        private float _flickerVorbei = 0f;         
        private float _nextFlicker = 0f; 
        
        public double WorldTimeVar = 0;

        public int timedpenisboom = 0;
        static int removedTime = 0;
        static int sek = 0;
        static int min = 0;
        public override void Act()
        {

            string ActualTimeDisplay = min + "m " + sek + "s";
            sek = Convert.ToInt32(CurrentWorld.WorldTime) - removedTime;
            if (sek == 60)
            {
                removedTime += 60;
                min++;
            }
            if(Convert.ToInt32(WorldTime) < 60)
            {
                ActualTimeDisplay = sek + "s";
            }
            displayTimer.SetText("Timer: " + ActualTimeDisplay);
            if (timedpenisboom < 50 && BOOM)
            {
                timedpenisboom++;
            }
            if (timedpenisboom == 50)
            {                
                timedpenisboom = 0;
                BOOM = false;
                _flashlight.SetColor(0, 0, 0, 0);
            }
            
            int random = rnd.Next(20000);
            _flashlight.SetPosition(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVectorLocalRight);
            _flashlight.SetTarget(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector * 100); // KAR: Taschenlampe muss weiiiiit in die Ferne schauen
            if (random == 69 && flashlight == true || Keyboard.IsKeyPressed(Keys.Space) && flashlight == true)
            {
                _flickering = true;
                _flickerVorbei = WorldTime + 0.5f;
                _nextFlicker = WorldTime + GetRandomFlickerDelay(); 
                Console.WriteLine("penis flackern");
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/shortsound.wav", false, (float)0.1);
            }
            if (_flickering)
            {                
                if (WorldTime >= _nextFlicker)
                {
                    if (_flashlight.Color.W > 0) 
                    { 
                        _flashlight.SetColor(0,0,0,0); 
                    }
                    else
                    {
                        _flashlight.SetColor(1, 1, 1, 8); 
                    }
                    _nextFlicker = WorldTime + GetRandomFlickerDelay();
                }
                if (WorldTime >= _flickerVorbei)
                {
                    BOOM = true;
                    timedpenisboom = 0;
                    flashlight = false;
                    _flickering = false;
                    _flashlight.SetColor(1, 1, 1, 13);
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/flashlightexplode.wav", false, (float)0.1);
                    Console.WriteLine("penis flacker vorbei");
                    Console.WriteLine("Penis aus");
                }
            }
            if (Keyboard.IsKeyPressed(Keys.F) && flashlight == false)
            {
                _flashlight.SetColor(1, 1, 1, 4);
                flashlight = true;
                Console.WriteLine("Penis an");
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/flashlight_click.wav", false, (float)0.1);
            }
            else if (Keyboard.IsKeyPressed(Keys.F) && flashlight == true)
            {
                _flashlight.SetColor(0, 0, 0, 0);
                flashlight = false;
                Console.WriteLine("Penis aus");
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/flashlight_click.wav", false, (float)0.1);
            }
            
            //Sprinting
            if (toggleSprint == false) 
            {
                if (Keyboard.IsKeyDown(Keys.LeftShift)) { Globals.Sprinting = true; }
                else { Globals.Sprinting = false; }
            }        
            //Sprint Toggle
            if (Keyboard.IsKeyPressed(Keys.CapsLock))
            {
                if (toggleSprint == false) {
                    toggleSprint = true;
                }
                else
                {  toggleSprint = false;}
                Globals.Sprinting = true;
                
            }
            if(Globals.Sprinting) {
                Globals.speed = 0.105f;
            }
            else{
                Globals.speed = 0.05f;
            }
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
            if ((Keyboard.IsKeyPressed(Keys.Escape) || Keyboard.IsKeyPressed(Keys.Tab)  )&& !Globals.MapOpen)
            {
                stop();
            }
            if (Keyboard.IsKeyPressed(Keys.Q))
            {
                //weiter();
            }

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
                    
                    Globals.Trys++;
                    string path = @"./App/data/data.txt";
                    string timePath = @"./App/data/time.txt";

                    Globals.displayCounter = Convert.ToString(CurrentWorld.WorldTime) + "\n";
                    string appendText = Convert.ToString(Globals.Score) + "\n";
                                       
                    File.AppendAllText(timePath, Globals.displayCounter);
                    File.AppendAllText(path, appendText);

                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
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
                    Globals.Trys++;
                    string path = @"./App/data/data.txt";

                    string appendText = Convert.ToString(Globals.Score) + "\n";
                    File.AppendAllText(path, appendText);
                    Window.Close();
                }
            }
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
                    collectablepos = collider.Position;
                    Enemy e = CurrentWorld.GetGameObjectByName<Enemy>("huso");
                    if(e != null)
                    {

                    }
                }
            }
        } 
        public void Camera(int forward, int strafe)
        {
            if (Globals.gameRunning) {
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
            CurrentWorld.RemoveHUDObject(score);
            displayTimer.SetPosition(50f, 50f);
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
            CurrentWorld.AddHUDObject(score);
            displayTimer.SetPosition(700f,250f);
            score.SetText("Punktestand: " + Globals.Score);
        }
        public void weiter()
        {
            Globals.gameRunning = true;            
            CurrentWorld.MouseCursorGrab();
            removeAllHUD();
        }
        private float GetRandomFlickerDelay()
        {
            return (float)_random.NextDouble() * 0.08f + 0.02f;
        }
    }
}