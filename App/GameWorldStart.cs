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
        bool startbool = false;
        float counter = 0.7f;          
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
            HUDObjectImage bbg = GetHUDObjectImageByName("bbg");
            if (startbool)
            {
                bbg.SetZIndex(0);
                if (counter != -1f)
                {
                    counter -= 0.005f;
                    bbg.SetOpacity(counter);
                }
                if (counter <= 0.1f)
                {
                    RemoveHUDObject(bbg);
                    
                }
            }
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
                    Map.SetCamera(p.Position.X, p.Position.Y, p.Position.Z, ProjectionDirection.NegativeY, 10 + finalPos, 10 + finalPos, 1, 100);
                }                
               
                else if (finalPos < 80 )
                {
                    Map.SetCamera(p.Position.X, p.Position.Y, p.Position.Z, ProjectionDirection.NegativeY, 10 + finalPos, 10 + finalPos, 1, 100); 
                    finalPos = finalPos + 0.8f;
                }
               
                if(finalPos >= 80f)
                {
                    // Optional: Map gemäß der Spielerposition verschieben und rotieren
                    Map.UpdateCameraRotation(CameraLookAtVectorXZ);
                    AddCameraRotationFromMouseDelta();
                }

                Wall dach = (Wall)GetGameObjectByName("10");
                Map map = (Map)GetGameObjectByName("map");
                Map leiter = (Map)GetGameObjectByName("Leiter");

                List<Collectable> list = GetGameObjectsByType<Collectable>();
                for (int C_count = 0; C_count < list.Count; C_count++)
                {
                    Map.Add(list[C_count], 0f, new Vector3(0, 1, 0), new Vector3(0, 1, 0), 1f, 0.6f, 3f, "./App/Textures/green.png");
                }
                List<Map> wlist = GetGameObjectsByType<Map>();                          //du mulluch hab gefixt, lutsch meine eier
                {
                    
                        Map.AddAsRealModel(map, 1f, new Vector3(0.4f,0,0), new Vector3(0.4f, 0,0), 0.4f, 1f);
                        Map.AddAsRealModel(leiter, 1f, Vector3.One, Vector3.Zero, 0f, 1f);
                    
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

            HUDObjectImage bbg = new HUDObjectImage("./App/Textures/blackscreen.png");
            bbg.SetScale(Globals.fensterBreite, Globals.fensterHoehe);
            bbg.Name = "bbg";
            bbg.SetColor(0, 0, 0);
            bbg.CenterOnScreen();
            bbg.SetZIndex(0);
            bbg.SetOpacity(1f);
            AddHUDObject(bbg);


            Console.WriteLine("[CONSOLE] World: GameWorldStart");
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/ScaryScream.wav", false, 0.2f);

            PreLoadSounds();
            FlowField pathfinding = new FlowField(0, 2.5f, 0, 50, 50, 1f, 5, FlowFieldMode.Box, typeof(Wall), typeof(Map));
            pathfinding.IsVisible = false; //FLOWFIELD DEBUG VISIBILTY
            AddFlowField(pathfinding);

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

            p = new Player("Yasin", 30f , 2f, 3f);
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
                Enemy e = new Enemy("huso", 0f, 2, 0);                
                AddGameObject(e);
            }

            Map map = new Map("map", 0, 0, 0);
            Map leiter = new Map("Leiter", 0, 0, 0);
            map.SetModel("Map");
            leiter.SetModel("EscapeLadder");
            map.SetScale(5f,8f,5f);
            map.SetPositionY(1f);
            map.SetTextureRepeat(1, 1);
            leiter.SetScale(5f, 8f, 5f);
            leiter.SetPositionY(1f);
            leiter.SetTextureRepeat(1, 1);
            AddGameObject(map); 
            AddGameObject(leiter);
            createMap();

            Wall w10 = new Wall("10", 25, 7, 20);
            w10.SetScale(75f, 1f, 100f);
            w10.SetTextureRepeat(75, 100);
            AddGameObject(w10);
        }
        public void createMap()
        {
            Map.SetCamera(
            p.Position.X, p.Position.Y, p.Position.Z, ProjectionDirection.NegativeY, 10, 10, 1, 100);
            Map.SetViewport(Window.Width -Globals.fensterBreite/2, Window.Height - Globals.fensterHoehe/2, Globals.fensterBreite, Globals.fensterHoehe, false);
            Map.SetBackground("./App/Textures/bgmap2.png", 1000, 1000, 1f, 50.0f, 50.0f);                                   
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