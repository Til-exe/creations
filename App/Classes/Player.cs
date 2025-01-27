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
using Gruppenprojekt.App.death_winscreen;

using Assimp.Configs;
using OpenTK.Graphics.ES11;
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
        HUDObjectText gamemode = new HUDObjectText("Gamemode:" + Globals.choseGamemode);
        HUDObjectImage bg = new HUDObjectImage("./App/Textures/blackscreen.png");
        HUDObjectText mtitle = new HUDObjectText("Pausiert");
        HUDObjectText winCondition = new HUDObjectText("Verschwinde von hier !");
        private HUDObjectText colCount;
        private int counter = 0;
        private float timestampLastWalkSound = 0;

        private Random _random = new Random();
        Win winscreen = new Win();
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
        public static bool enemyspeedcap = false;
        private float _enemySpeedResetTime = -1f;
        float timestampLastSighting = 0;
        bool penis1 = true;
        float penisZeit;
        float digga;
        static bool penis12 = true;
        static float penis151 = 0f;

        private bool IsBird() // Testmethode von KAR
        {
            if(CurrentWorld is GameWorldStart)
            {
                return (CurrentWorld as GameWorldStart).IsBird();
            }
            return false;
        }
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
            this.SetColorEmissive(1, 1, 1, 2);
            
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

            if(Globals.choseGamemode != "Tutorial")
            {
                CurrentWorld.AddHUDObject(displayTimer);
            }

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

            gamemode.SetPosition(700f, 300f);
            gamemode.Name = "gamemode";
            gamemode.SetCharacterDistanceFactor(1.0f);
            gamemode.SetColor(1.0f, 0.0f, 0.0f);

            winCondition.Name = "win";
            winCondition.SetPosition(Globals.fensterBreite / 2, 40f);
            winCondition.SetCharacterDistanceFactor(1.0f);
            winCondition.SetColor(1.0f, 0.0f, 0.0f);
            winCondition.SetTextAlignment(TextAlignMode.Center);
        }
        public static void AddBlackHUDBorder()
        {
            HUDObjectImage bg = new HUDObjectImage("./App/Textures/blackscreen.png");
            HUDObjectImage bg1 = new HUDObjectImage("./App/Textures/blackscreen.png");
            if (penis12)
            {
                bg.SetScale(Globals.fensterBreite * 10, Globals.fensterHoehe / 5);
                bg.Name = "bbg";
                bg.SetColor(0, 0, 0);
                bg.SetPosition(Globals.fensterBreite / 2, 0);
                bg.SetZIndex(0);
                bg.SetOpacity(1f);
                CurrentWorld.AddHUDObject(bg);
                Console.WriteLine("[HUDObject] added 'bg'");

                bg1.SetScale(Globals.fensterBreite * 10, Globals.fensterHoehe / 5);
                bg1.Name = "bbg";
                bg1.SetColor(1, 0, 0);
                bg1.SetPosition(Globals.fensterBreite / 2, Globals.fensterHoehe);
                bg1.SetZIndex(0);
                bg1.SetOpacity(1f);
                CurrentWorld.AddHUDObject(bg1);
                Console.WriteLine("[HUDObject] added 'bg1'");
                penis12 = false;
            }
            //Console.WriteLine("X: " + bg1.Position.X + " Y: " + bg1.Position.Y + " penis151: " + penis151);
            //Console.WriteLine("X: " + bg.Position.X + " Y: " + bg.Position.Y + " penis151: " + penis151);
        }
        public override void Act()
        {            
            //Death Action
            if (Globals.GameEnd && Globals.EndReal)
            {
                safeScore();
                GameWorldStartMenu gwsm = new GameWorldStartMenu();
                Window.SetWorld(gwsm);
            }
            if (counter == Globals.ColCount)    //Ende wenn alle Collectables eingesammelt worden sind
            {
                AddBlackHUDBorder();
                if (penis1)
                {
                    penisZeit = WorldTime;
                    penis1 = false;
                }
                float penisNew = WorldTime - penisZeit;
                digga = (WorldTime - penisNew) - 60;
                
                CurrentWorld.AddHUDObject(winCondition);
                if (this.Position.X > 25 && this.Position.Z > 5 && this.Position.X < 35 && this.Position.Z < 7) 
                {
                    safeScore();                    
                    Window.SetWorld(winscreen);
                }                
            }
            //Displaying Time
            string ActualTimeDisplay = min + "m " + sek + "s";
            sek = Convert.ToInt32(CurrentWorld.WorldTime) - removedTime;
            if (sek == 60) {
                removedTime += 60;
                min++;                
            }
            if(Convert.ToInt32(WorldTime) < 60) {
                ActualTimeDisplay = sek + "s";
            }                                                    //Coordinaten Displayn (in Klammern einfügen)
            displayTimer.SetText("Timer: " + ActualTimeDisplay); //  +"\n" + Math.Round(this.Position.X) + " " + Math.Round(this.Position.Y) + " "+ Math.Round(this.Position.Z)
            //Flaschlight Action
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
            //random Flashlight Breaking
            int random = 0;
            if (Globals.gameRunning) 
            {
               random = rnd.Next(20000);
            }
            _flashlight.SetPosition(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVectorLocalRight);
            _flashlight.SetTarget(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector * 100); // KAR: Taschenlampe muss weiiiiit in die Ferne schauen
            if (random == 69 && flashlight == true || (Keyboard.IsKeyPressed(Keys.Space) && Globals.debugMode) && flashlight == true)
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
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/flashlightexplode.wav", false, 0.1f);
                    Console.WriteLine("penis flacker vorbei");
                    Console.WriteLine("Penis aus");
                }
            }
            //Activate Flashlight
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
            if (!toggleSprint) 
            {
                if (Keyboard.IsKeyDown(Keys.LeftShift)) { Globals.Sprinting = true; }
                else { Globals.Sprinting = false; }
            }
            //Sprint Toggle
            if (Keyboard.IsKeyPressed(Keys.CapsLock))
            {
                toggleSprint = !toggleSprint;
                Globals.Sprinting = true;                
            }
            int forward = 0;
            int strafe = 0;
            //Movement
            if (Globals.gameRunning && !Globals.MapOpen )
            {
                if (WorldTime - timestampLastWalkSound > 0.5f)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/Playersteps.wav", false, 0.3f);
                    timestampLastWalkSound = WorldTime;
                }

                if (Keyboard.IsKeyDown(Keys.W)) { forward += 1; }
                if (Keyboard.IsKeyDown(Keys.D)) { strafe += 1;  }
                if (Keyboard.IsKeyDown(Keys.A)) { strafe -= 1;  }
                if (Keyboard.IsKeyDown(Keys.S)) { forward -= 1;  }
                Globals.speed = 0.05f;
                if (Keyboard.IsKeyDown(Keys.W) && Globals.Sprinting) { Globals.speed = 0.105f; }
                if (Keyboard.IsKeyDown(Keys.D) && Globals.Sprinting) { Globals.speed = 0.069f; }
                if (Keyboard.IsKeyDown(Keys.A) && Globals.Sprinting) { Globals.speed = 0.069f; }
            }
            //pause Menu
            if ((Keyboard.IsKeyPressed(Keys.Escape) || Keyboard.IsKeyPressed(Keys.Home) ||Keyboard.IsKeyPressed(Keys.Tab)  )&& !Globals.MapOpen)
            {
                stop();
            }
            //Pause Menu Weiter spielen
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
                if ((Mouse.IsButtonPressed(MouseButton.Left) && m1.IsMouseCursorOnMe() == true))
                {
                    CurrentWorld.MouseCursorResetPosition();
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    weiter();
                }
            }
            //Pause Menu Hauptmenu
            if (m2!= null)
            {  
                if (m2.IsMouseCursorOnMe() == true && Globals.TutorialComplete)
                {
                    m2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    m2.SetColorEmissiveIntensity(0.0f);
                }
                if (Globals.TutorialComplete) {
                    if (Mouse.IsButtonPressed(MouseButton.Left) && m2.IsMouseCursorOnMe() == true )
                    {
                        KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                        safeScore();
                        GameWorldStartMenu gm = new GameWorldStartMenu();
                        Window.SetWorld(gm);
                    }
                }
                else
                {
                    m2.SetOpacity(0.5f);
                }
                
                
            }
            //Pause Menu Close
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
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);                    
                    string penistext = Convert.ToString(Globals.Score) + "\n";
                    File.AppendAllText(Globals.path, penistext);
                    Window.Close();
                }
            }
            if(IsBird() == false) Camera(forward, strafe);
            else
            {
                if(Keyboard.IsKeyDown(Keys.W)){ MoveOffset(0, 0, -0.05f); }
                if (Keyboard.IsKeyDown(Keys.S)) { MoveOffset(0, 0, +0.05f); }
                if (Keyboard.IsKeyDown(Keys.A)) { MoveOffset(-0.05f, 0, 0); }
                if (Keyboard.IsKeyDown(Keys.D)) { MoveOffset(0.05f, 0, 0); }
                CurrentWorld.SetCameraPosition(5, 125, 20);
                CurrentWorld.SetCameraTarget(5, 0, 20);

            }
            //Einsammeln von Collectable's
            List<Intersection> intersections = GetIntersections();
            foreach (Intersection i in intersections)
            {
                GameObject collider = i.Object;
                if (collider is Enemy)
                {
                    //??? Anscheinend haben wir eine komplett neue Funktion fürn Tod???? alter das war doch alles schon da. Geile Truppe. egal
                }
                Vector3 mtv = i.MTV;
                MoveOffset(mtv);
                if (collider is Collectable)
                {
                    (collider as Collectable).KillMe();
                    counter = counter + 1;
                    colCount.SetText("Gesammelte Orbs: " + counter);
                    collectablepos = collider.Position;
                    Enemy.Collectabletarget(collectablepos);
                }
                else if (collider is InteractionCollectable)
                {
                    (collider as InteractionCollectable).KillMe(1, 0, 0, 2);
                    counter = counter + 1;
                    colCount.SetText("Gesammelte Orbs: " + counter);
                }
            }
            //Flashlight slow of enemy
            Vector3 rayStart = this.Center;
            Vector3 rayDirection = this.LookAtVector;
            List<RayIntersection> results = HelperIntersection.RayTraceObjectsForViewVectorFast(rayStart, rayDirection, this, 10, true, typeof(Enemy), typeof(Wall), typeof(Map));
            if (flashlight == true && results.Count > 0 && results[0].Object is Enemy)
            {
                RayIntersection raycollision = results[0];
                Console.WriteLine(raycollision.ToString());
                Console.WriteLine("Hit");
                enemyspeedcap = true;
                timestampLastSighting = WorldTime;
                Globals.EnemySpeed = 0.04f;
                Console.WriteLine("enemyspeedcap wird auf true gesetzt");
            }
            if (timestampLastSighting + 4f > WorldTime && timestampLastSighting != 0)
            {
                Globals.EnemySpeed = 0.04f;
                enemyspeedcap = false;                                                      //Hier sind die Geschwindigkeitseinstellungen
            }
            else
            {
                if (Globals.choseGamemode == "Hard")
                {
                    Globals.EnemySpeed = 0.12f;
                }
                else
                {
                    Globals.EnemySpeed = 0.08f;
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
            CurrentWorld.RemoveHUDObject(gamemode);
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
            CurrentWorld.AddHUDObject(gamemode);
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
        public static void safeScore()
        {
            if (sek + (min * 60) >= 180)
            {
                Globals.Experience += 5;                
            }
            else if (sek + (min * 60) >= 120)
            {
                Globals.Experience += 4;
            }
            else if (sek + (min * 60) >= 60)
            {
                Globals.Experience += 2;
            }
            else { Globals.Experience += 1;}
            if ((Globals.Score) >= 5)
            {
                Globals.Experience += 1;
            }
            Globals.displayCounter = Convert.ToString(CurrentWorld.WorldTime) + "\n";
            string appendText = Convert.ToString(Globals.Score) + "\n";
            File.AppendAllText(Globals.timePath, Globals.displayCounter);
            File.AppendAllText(Globals.path, appendText);            
            
            
            
            
        }
    }
}