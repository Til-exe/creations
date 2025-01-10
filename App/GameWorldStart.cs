using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using KWEngine3.Helper;
using System.Collections.Generic;

namespace Gruppenprojekt.App
{
    public class GameWorldStart : World
    {
        private Player p;
        float finalPos = 0f;
        private float _HUDLastUpdate = 0;
        bool fullbright = false;
        bool bird = false; // KAR: Vogelperspektive

        public bool IsBird()
        {
            return bird;
        }

        public float GetHUDLastUpdateTime()
        {            
            HUDObjectText h = GetHUDObjectTextByName("MyHUDObject");
            HUDObjectText h1 = GetHUDObjectTextByName("Weiter");
            if (h1 != null)
            {
                if (h1.IsMouseCursorOnMe() == true)
                {
                    h1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    h1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && h1.IsMouseCursorOnMe() == true)
                {
                    MouseCursorGrab();
                }
            }
            return _HUDLastUpdate;
        }
        public void UpdateHUDLastUpdateTime()
        {
            _HUDLastUpdate = WorldTime;
        }
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.T) && Globals.debugMode)
            {
                FlowField f = GetFlowField();
                if (f != null)
                {
                    f.IsVisible = !f.IsVisible;
                }
            }            
            if (Keyboard.IsKeyPressed(Keys.B) && Globals.debugMode)
            {
                if (fullbright)
                {
                    SetColorAmbient(0.05f, 0.02f, 0.02f);

                }
                else {
                    SetColorAmbient(0.5f, 0.5f, 0.5f);

                }
                fullbright = !fullbright;
            }
            // WorldTime ist 2.5
            // _HUDLastUpdate ist 2.2
            // deltat = 0.3

            float deltat = Math.Clamp((WorldTime - _HUDLastUpdate) * 0.4f, 0, 1);
            HUDObjectText t = GetHUDObjectTextByName("ORBS");
            t.SetOpacity(1 - deltat);
            if (Keyboard.IsKeyPressed(Keys.R) == true && Globals.gameRunning)
            {
                Map.UpdateCameraRotation(CameraLookAtVectorXZ);

                AddCameraRotationFromMouseDelta();

                Map.Enabled = !Map.Enabled;
                Globals.MapOpen = !Globals.MapOpen;
                
                // Optional: Map gemäß der Spielerposition verschieben und rotieren
                if(Map.Enabled == false && finalPos >= 80f)
                {
                    finalPos = 0f;
                }
            }
            if (Map.Enabled == true)
            {
               
                if(finalPos < 0.03f )
                {
                    finalPos = finalPos + 0.0001f;                   
                    Map.SetCamera(
                    p.Position.X, p.Position.Y, p.Position.Z,                   // Position der Map-Kamera
                    ProjectionDirection.NegativeY, // Blickrichtung der Kamera (in diesem Beispiel nach unten)
                    10 + finalPos,                            // Sichtfeld der Kamera (in z.B. Metern) in der Breite
                    10 + finalPos,                            // Sichtfeld der Kamera (in z.B. Metern) in der Höhe
                    1,                             // Naheinstellgrenze (Objekte näher als 1 Einheit werden ignoriert)
                    100);
                }                
               
                else if (finalPos < 80 )
                {
                    Map.SetCamera(
                    p.Position.X, p.Position.Y, p.Position.Z,                   // Position der Map-Kamera
                    ProjectionDirection.NegativeY, // Blickrichtung der Kamera (in diesem Beispiel nach unten)
                    10 + finalPos,                            // Sichtfeld der Kamera (in z.B. Metern) in der Breite
                    10 + finalPos,                            // Sichtfeld der Kamera (in z.B. Metern) in der Höhe
                    1,                             // Naheinstellgrenze (Objekte näher als 1 Einheit werden ignoriert)
                    100);
                    finalPos = finalPos + 0.8f;
                }
               
                if(finalPos >= 80f)
                {
                    // Optional: Map gemäß der Spielerposition verschieben und rotieren
                    Map.UpdateCameraRotation(CameraLookAtVectorXZ);
                    AddCameraRotationFromMouseDelta();
                }

                Wall dach = (Wall)GetGameObjectByName("10");

                List<Collectable> list = GetGameObjectsByType<Collectable>();
                for (int C_count = 0; C_count < list.Count; C_count++)
                {
                    Map.Add(list[C_count], 0f, new Vector3(0, 1, 0), new Vector3(0, 1, 0), 1f, 0.6f, 3f, "./App/Textures/green.png");
                }
                List<Wall> wlist = GetGameObjectsByType<Wall>();
                for (int W_count = 0; W_count < wlist.Count; W_count++)
                {
                    if (wlist[W_count].Name != "10")
                    {
                        Map.Add(wlist[W_count], 0f, new Vector3(0, 0, 1), new Vector3(0, 0, 1), 1f, 0.6f, 0f, "./App/Textures/bl_wall.jpg");
                    }
                }
                List<Player> plist = GetGameObjectsByType<Player>();
                for (int p_count = 0; p_count < plist.Count; p_count++)
                {
                    if (finalPos >= 0.02f) {
                        Map.Add(p, 0f, new Vector3(1, 0, 0), new Vector3(1, 0, 0), 1f, 0.6f, 3f);
                    }
                }
            }
        }
        public override void Prepare()
        {
            Console.WriteLine("[CONSOLE] World: GameWorldStart");
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/ScaryScream.wav", false, 0.2f);

            PreLoadSounds();
            FlowField pathfinding = new FlowField(0, 2.5f, 0, 50, 50, 0.5f, 5, FlowFieldMode.Simple, typeof(Wall));
            pathfinding.IsVisible = false; //FLOWFIELD DEBUG VISIBILTY
            AddFlowField(pathfinding);

            KWEngine.LoadModel("Pascal", "./App/Models/pascalbild.fbx");
            KWEngine.LoadModel("Map", "./App/Models/knezi1.glb");
            KWEngine.LoadModel("EscapeLadder", "./App/Models/knezi_ladderOnly.glb");

            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/shortsound.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlight_click.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlightexplode.wav");

            SetFadeColor(0, 0, 0);

            SetBackgroundSkybox("./App/Textures/skybox.png");
            SetCameraPosition(0.0f, 2.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);
            SetCameraFOV(100);
            SetColorAmbient(0.05f, 0.02f, 0.02f);
            Floor f = new Floor("floor", 1f, 1f, 1f);
            f.SetTexture("./app/Textures/wood1.png");
            if (Globals.ReturnCode == 0) {  }
            if (Globals.ReturnCode == 1) { Globals.ReturnCode = 0; Globals.Score += 1000; }

            f.SetTextureRepeat(100f, 100f);
            AddGameObject(f);

            p = new Player("Yasin", 0 , 2f, 0);
            AddGameObject(p);

            SetCameraToFirstPersonGameObject(p, 2f);
            KWEngine.MouseSensitivity = 0.07f;
            MouseCursorGrab();



            LightObject light = new LightObject(LightType.Sun, ShadowQuality.Low);
            light.Name = ("scheiß auf den Namen");
            light.SetNearFar(0.1f, 25f);
            light.SetPosition(0f, 5f, 0);
            //AddLightObject(light);

            for(int i = 0; i <Globals.ColCount; i++)
            {
                Random rnd = new Random();
                Collectable c1 = new Collectable("new", (float)rnd.Next(1,100), 4f, (float)rnd.Next(1, 100));
                AddGameObject(c1);
            }

            if (Globals.choseGamemode != "Peacefull" )
            {
                Enemy e = new Enemy("huso", -12.5f, 2, 13);                
                AddGameObject(e);
            }
            float xCord = 4f;
            float ScaleHoehe = 5f;

            Wall map = new Wall("map", 0, 0, 0);
            Wall leiter = new Wall("Leiter", 0, 0, 0);
            map.SetModel("Map");
            leiter.SetModel("EscapeLadder");
            map.SetScale(5f,8f,5f);
            map.SetPositionY(1f);
            AddGameObject(map); 
            AddGameObject(leiter);
            

            /*
            Wall borderNorth = new Wall("1", 100f, xCord, 0f);
            Wall borderSouth = new Wall("1", -100f, xCord, 0f);
            Wall borderWest = new Wall("1", 0f, xCord, 100f);
            Wall borderEast = new Wall("1", 0f, xCord, -100f);
            Wall w1 = new Wall("1", 0f, xCord, 5f);
            Wall w2 = new Wall("2", -5f, xCord, 0f);
            Wall w3 = new Wall("3", -5f, xCord, 10f);
            Wall w4 = new Wall("4", 0f, xCord, 15f);
            Wall w5 = new Wall("5", 10f, xCord, 10f);
            Wall w6 = new Wall("6", -15f, xCord, 10f);
            Wall w7 = new Wall("7", -15f, xCord, 0f);
            Wall w8 = new Wall("8", 10f, xCord, 0f);
            Wall w9 = new Wall("9", 0f, xCord, -5f);
            Wall w10 = new Wall("10", -2.5f, xCord+3, 5);
            

            if (true) 
            {
                w4.SetScale(30f, ScaleHoehe, 1f);
                w5.SetRotation(0, 90, 0);
                w5.SetScale(10f, ScaleHoehe, 1f);
                w6.SetRotation(0, 90, 0);
                w6.SetScale(10f, ScaleHoehe, 1f);
                w7.SetRotation(0, 90, 0);
                w7.SetScale(10f, ScaleHoehe, 1f);
                w8.SetRotation(0, 90, 0);
                w8.SetScale(10f, ScaleHoehe, 1f);
                w10.SetScale(25f, 1f, 20f);

                borderNorth.SetRotation(0, 90, 0);
                borderNorth.SetScale(200, ScaleHoehe, 1);
                borderNorth.SetTextureRepeat(100f, 5f);
                borderSouth.SetRotation(0, 90, 0);
                borderSouth.SetScale(200, ScaleHoehe, 1);
                borderSouth.SetTextureRepeat(100f, 5f);
                borderEast.SetScale(200, ScaleHoehe, 1);
                borderEast.SetTextureRepeat(100f, 5f);
                borderWest.SetScale(200, ScaleHoehe, 1);
                borderWest.SetTextureRepeat(100f, 5f);
            } //Set Attributes            

            if (true) 
            {
                AddGameObject(borderWest);
                AddGameObject(borderEast);
                AddGameObject(borderNorth);
                AddGameObject(borderSouth);
                AddGameObject(w1);
                AddGameObject(w2);
                AddGameObject(w3);
                AddGameObject(w4);
                AddGameObject(w5);
                AddGameObject(w6);
                AddGameObject(w7);
                AddGameObject(w8);
                AddGameObject(w9);
                AddGameObject(w10);
            } //Add Game Objekts
            */
            createMap();
        }
        public void createMap()
        {
            Map.SetCamera(
                 p.Position.X, p.Position.Y, p.Position.Z,                   // Position der Map-Kamera
                 ProjectionDirection.NegativeY, // Blickrichtung der Kamera (in diesem Beispiel nach unten)
                 10,                            // Sichtfeld der Kamera (in z.B. Metern) in der Breite
                 10,                            // Sichtfeld der Kamera (in z.B. Metern) in der Höhe
                 1,                             // Naheinstellgrenze (Objekte näher als 1 Einheit werden ignoriert)
                 100);                          // Ferneinstellgrenze (Weiter als 100 Einheiten entfernte Objekte werden ignoriert)

            // Position der Map auf dem Bildschirm konfigurieren:
            Map.SetViewport(
                Window.Width -Globals.fensterBreite/2,        // X-Position der Mitte der Map auf dem Bildschirm
                Window.Height - Globals.fensterHoehe/2,       // Y-Position der Mitte der Map auf dem Bildschirm
                Globals.fensterBreite,                           // Breite der Map auf dem Bildschirm
               Globals.fensterHoehe,                           // Höhe der Map auf dem Bildschirm
               false);                         // Map soll als Kreis dargestellt werden

                        // Optional: Hintergrund der Map konfigurieren
            Map.SetBackground(
                "./App/Textures/bgmap2.png",       // Hintergrundtextur
                1000,                           // Wie viele Einheiten der Spielwelt deckt der Hintergrund ab? (Breite)
                1000,                           // Wie viele Einheiten der Spielwelt deckt der Hintergrund ab? (Höhe)
                1f,                          // Sichtbarkeit 0 bis 1
                50.0f,                          // Texturwiederholung  X
                50.0f);                         // Texturwiederholung Y            
            
        }
        public static void PreLoadSounds() {
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/shortsound.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlight_click.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/Collecting.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/deepGrowl1.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/IntroMusic1.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/scaryAmbience.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/ScaryMenuMusic1.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/ScaryScream.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/click.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/click1.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/basicClick.wav");



        }
    }
}   