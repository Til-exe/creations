using KWEngine3.GameObjects;
using KWEngine3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using KWEngine3;
using KWEngine3.Audio;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System.Diagnostics;
using System.Threading;
using OpenTK.Windowing.Common.Input;
using Assimp;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Transactions;
using Gruppenprojekt.App.Menus;
using Gruppenprojekt.App.Classes;

namespace Gruppenprojekt.App
{
    public class GameWorldTutorial : World
    {
        private Player p;
        float finalPos = 0f;
        private float _HUDLastUpdate = 0;
        bool fullbright = false;
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.T))
            {
                FlowField f = GetFlowField();
                if (f != null)
                {
                    f.IsVisible = !f.IsVisible;
                }
            }
            if (Keyboard.IsKeyPressed(Keys.B))
            {
                if (fullbright)
                {
                    SetColorAmbient(0.05f, 0.02f, 0.02f);

                }
                else
                {
                    SetColorAmbient(0.5f, 0.5f, 0.5f);

                }
                fullbright = !fullbright;
            }

            float deltat = Math.Clamp((WorldTime - _HUDLastUpdate) * 0.4f, 0, 1);
            HUDObjectText t = GetHUDObjectTextByName("ORBS");
            t.SetOpacity(1 - deltat);
            if (Keyboard.IsKeyPressed(Keys.R) == true && Globals.gameRunning)
            {
                Map.Enabled = !Map.Enabled;
                Globals.MapOpen = !Globals.MapOpen;

                // Optional: Map gemäß der Spielerposition verschieben und rotieren
                if (Map.Enabled == false && finalPos >= 80f)
                {
                    finalPos = 0f;
                }
            }
            if (Map.Enabled == true)
            {
                if (finalPos < 0.01f)
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

                else if (finalPos < 80)
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

                if (finalPos >= 80f)
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
                    Map.Add(p, 0f, new Vector3(1, 0, 0), new Vector3(1, 0, 0), 1f, 0.6f, 3f);
                }
            }
        }
        public override void Prepare()
        {

            PreLoadSounds();
            FlowField pathfinding = new FlowField(0, 2.5f, 0, 50, 50, 0.5f, 5, FlowFieldMode.Simple, typeof(Wall));
            pathfinding.IsVisible = false; //FLOWFIELD DEBUG VISIBILTY
            AddFlowField(pathfinding);

            KWEngine.LoadModel("Pascal", "./App/Models/pascalbild.fbx");

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
            f.SetTextureRepeat(100f, 100f);
            AddGameObject(f);

            p = new Player("Yasin", 0f, 2f, 0f);
            AddGameObject(p);

            SetCameraToFirstPersonGameObject(p, 2f);
            KWEngine.MouseSensitivity = 0.07f;
            MouseCursorGrab();                        

            if (Globals.choseGamemode != "Peacefull")
            {
                Enemy e = new Enemy("huso", -12.5f, 2, 13);
                //AddGameObject(e);
            }
            float xCord = 4f;
            float ScaleHoehe = 5f;
            //Collectable c1 = new Collectable("1", 3f, 4f, 20f);
            //AddGameObject(c1);
            Wall borderNorth = new Wall("1", 100f, xCord, 0f);
            Wall borderSouth = new Wall("1", -100f, xCord, 0f);
            Wall borderWest = new Wall("1", 0f, xCord, 100f);
            Wall borderEast = new Wall("1", 0f, xCord, -100f);
            Wall w1 = new Wall("1", 2f, xCord, 10f);
            Wall w2 = new Wall("2", -2f, xCord, 10f);
            Wall w3 = new Wall("3", 0f, xCord, 20f);
            Wall w4 = new Wall("4", 0f, xCord, -2f);

            w1.SetRotation(0,90,0);
            w1.SetScale(40,ScaleHoehe,1);
            w1.SetTextureRepeat(20, 3);
            w2.SetRotation(0,90,0);
            w2.SetScale(40, ScaleHoehe, 1);
            w2.SetTextureRepeat(20, 3);


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

            AddGameObject(borderWest);
            AddGameObject(borderEast);
            AddGameObject(borderNorth);
            AddGameObject(borderSouth);
            AddGameObject(w1);
            AddGameObject(w2);
            AddGameObject(w3);
            AddGameObject(w4);

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
                Window.Width - Globals.fensterBreite / 2,        // X-Position der Mitte der Map auf dem Bildschirm
                Window.Height - Globals.fensterHoehe / 2,       // Y-Position der Mitte der Map auf dem Bildschirm
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
        public static void PreLoadSounds()
        {
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
    }
}