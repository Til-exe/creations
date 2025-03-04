using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using KWEngine3.Helper;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gruppenprojekt.App
{
    public class GameWorldStart : World
    {
        bool startbool = true;
        float counter = 0.7f;          
        private Player p;
        float finalPos = 0f;
        private float _HUDLastUpdate = 0;
        bool fullbright = false;
        bool bird = false; // KAR: Vogelperspektive
        public static List<Vector3> positions = new List<Vector3>();


     
           

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
                    bbg.SetOpacity(0);
                    SetColorAmbient(0.05f, 0.02f, 0.02f);
                }
                else {
                    bbg.SetOpacity(counter);
                    SetColorAmbient(0.5f, 0.5f, 0.5f);
                }
                fullbright = !fullbright;
                //Console.WriteLine(fullbright);
            }

            float deltat = Math.Clamp((WorldTime - _HUDLastUpdate) * 0.4f, 0, 1);
            HUDObjectText t = GetHUDObjectTextByName("ORBS");
            t.SetOpacity(1 - deltat);
            if ((Keyboard.IsKeyPressed(Keys.R)  || Keyboard.IsKeyPressed(Keys.M)) && Globals.gameRunning)
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
                List<Map> wlist = GetGameObjectsByType<Map>();                          //du mulluch hab gefixt, lutsch meine eier, nix is gefixt, lutsch meine eier
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
            bbg.SetZIndex(0);

            if (startbool)
            {
                if (counter != -1f && !fullbright)
                {
                    counter -= 0.0005f;
                    bbg.SetOpacity(counter);
                }
            }
        }
        public override void Prepare()
        {
            KWEngine.LoadModel("EnemyClown", "./App/Models/whiteclown_gltfbin_kwengine/WhiteClown.gltf");


            HUDObjectImage bbg = new HUDObjectImage("./App/Textures/blackscreen.png");
            bbg.SetScale(Globals.fensterBreite, Globals.fensterHoehe);
            bbg.Name = "bbg";
            bbg.SetColor(0, 0, 0);
            bbg.CenterOnScreen();
            bbg.SetZIndex(0);
            bbg.SetOpacity(1f);
            AddHUDObject(bbg);


            Console.WriteLine("[CONSOLE] World: GameWorldStart");
            //KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/ScaryScream.wav", false, 0.2f);

            PreLoadSounds();
            //FlowField pathfinding = new FlowField(0, 2.5f, 0, 50, 50, 1f, 5, FlowFieldMode.Simple, typeof(Wall), typeof(Map));
            //FlowField pathfinding = new FlowField(25, 2.5f, 25, 40, 60, 1f, 5, FlowFieldMode.Simple, typeof(Wall), typeof(Map));
            FlowField pathfinding = new FlowField(25, 2.5f, 25, 80, 120, 0.5f, 5, FlowFieldMode.Simple, typeof(Wall), typeof(Map));
            pathfinding.IsVisible = false; //FLOWFIELD DEBUG VISIBILTY
            AddFlowField(pathfinding);

            KWEngine.LoadModel("Map", "./App/Models/knezi1.glb");
            KWEngine.LoadModel("EscapeLadder", "./App/Models/knezi_ladderOnly.glb");

            // 2025-01-26, KAR: FPS-Armmodell
            KWEngine.LoadModel("FPSARMS", "./App/Models/fps_arms.fbx");

            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/shortsound.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlight_click.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlightexplode.wav");

            SetFadeColor(0, 0, 0);

            SetBackgroundSkybox("./App/Textures/skybox.png");
            SetCameraPosition(0.0f, 2.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);
            SetCameraFOV(100);
            SetColorAmbient(0.05f, 0.02f, 0.02f);
            Floor f = new Floor("floor", 25f, 1f, 20f);
            f.SetTexture("./app/Textures/wood1.png");
            if (Globals.ReturnCode == 0) {  }
            if (Globals.ReturnCode == 1) { Globals.ReturnCode = 0; Globals.Score += 1000; }

            f.SetTextureRepeat(50f, 75f);
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

            positions.Add(new Vector3(50, 3, 28));
            positions.Add(new Vector3(45, 3, -10));
            positions.Add(new Vector3(13, 3, -17));
            positions.Add(new Vector3(12, 3, -8));
            positions.Add(new Vector3(3, 3, -17));
            positions.Add(new Vector3(7, 3, 26));
            positions.Add(new Vector3(25, 3, 60));
            positions.Add(new Vector3(38, 3, 55));
            positions.Add(new Vector3(30, 3, 23));
            positions.Add(new Vector3(40, 3, 23));

            for (int i = 0; i <Globals.ColCount; i++)
            {
                //positions.Add((HelperRandom.GetRandomNumber(3, 50), 3, HelperRandom.GetRandomNumber(-17, 60)));
                //Collectable c = new Collectable("new", positions[i].X, positions[i].Y, positions[i].Z);
                //AddGameObject(c);
            }

            if (Globals.ColCount > positions.Count)
            {
                Console.WriteLine("Nicht genug Positionen verfügbar!");
                return;
            }

            // Liste zufällig mischen
            Random rnd = new Random();
            List<Vector3> shuffledPositions = new List<Vector3>(positions);
            shuffledPositions.Sort((a, b) => rnd.Next(-1, 2));

            // Collectables an zufälligen Positionen erstellen
            for (int i = 0; i < Globals.ColCount; i++)
            {
                Vector3 pos = shuffledPositions[i];
                Collectable c = new Collectable("new", pos.X, pos.Y, pos.Z);
                AddGameObject(c);
            }



            if (Globals.choseGamemode != "Peacefull" )
            {
                Enemy e = new Enemy("huso", 3f, 1.5f, -8);
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