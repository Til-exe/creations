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
        
        private float _HUDLastUpdate = 0;
       

        
        public float GetHUDLastUpdateTime()
        {
            
            HUDObjectText h = GetHUDObjectTextByName("MyHUDObject");
            HUDObjectText h1 = GetHUDObjectTextByName("Weiter");
            // Wenn ein Objekt dieses Typs und dieses Namens gefunden werden
            // konnte, ist die Variable h nicht 'leer', also 'nicht null':
            
            
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
            // WorldTime ist 2.5
            // _HUDLastUpdate ist 2.2
            // deltat = 0.3

            float deltat = Math.Clamp((WorldTime - _HUDLastUpdate) * 0.4f, 0, 1);
            HUDObjectText t = GetHUDObjectTextByName("BLA");
            t.SetOpacity(1 - deltat);

            if (Keyboard.IsKeyPressed(Keys.R) == true)
            {

                Map.Enabled = !Map.Enabled;

            }




            if (Map.Enabled == true)
            {
                // Optional: Map gemäß der Spielerposition verschieben und rotieren
                Map.UpdateCameraRotation(CameraLookAtVectorXZ);
                Map.UpdateCamera(
                    new Vector3(
                        p.Position.X,
                        p.Position.Y + 10,
                        p.Position.Z)
                );


                List<Collectable> list = GetGameObjectsByType<Collectable>();
                for (int C_count = 0; C_count < list.Count; C_count++)
                {
                    Map.Add(list[C_count], 0f, new Vector3(0, 1, 0), new Vector3(0, 1, 0), 1f, 0.6f, 3f, "./App/Textures/green.png");
                }
                List<Wall> wlist = GetGameObjectsByType<Wall>();
                for (int W_count = 0; W_count < wlist.Count; W_count++)
                {
                    Map.Add(wlist[W_count], 0f, new Vector3(0, 0, 1), new Vector3(0, 0, 1), 1f, 0.6f, 0f, "./App/Textures/bl_wall.jpg");
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
           
            SetBackgroundSkybox("./App/Textures/skybox.png");
            SetCameraPosition(0.0f, 2.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);
            SetCameraFOV(100);
            SetColorAmbient(0.45f, 0.25f, 0.25f);
            Floor f = new Floor("floor", 1f, 1f, 1f);
            if (GwStartMenuOption.ReturnCode == 0) { f.SetTexture("./app/Textures/wood1.png"); }
            if (GwStartMenuOption.ReturnCode == 1) { f.SetTexture("./app/Textures/wood11.png"); GwStartMenuOption.ReturnCode = 0; }

            f.SetTextureRepeat(100f, 100f);
            AddGameObject(f);

            p = new Player("Yasin", -13f, 2f, -4f);
            AddGameObject(p);


            SetCameraToFirstPersonGameObject(p, 2f);
            KWEngine.MouseSensitivity = 0.07f;
            MouseCursorGrab();



            LightObject light = new LightObject(LightType.Sun, ShadowQuality.Low);
            light.Name = ("scheiß auf den Namen");
            light.SetNearFar(0.1f, 25f);
            light.SetPosition(0f, 5f, 0);
            //AddLightObject(light);


            //test 
            Enemy e = new Enemy("huso" , 10, 2, 1);
            AddGameObject(e);
            Collectable c1 = new Collectable("1", 3f, 3f, 20f);
            Collectable c2 = new Collectable("2", 10f, 3f, 20f);
            Collectable c3 = new Collectable("3", 20f, 3f, 20f);
            AddGameObject(c1);
            AddGameObject(c2);
            AddGameObject(c3);
            Wall w1 = new Wall("1", 0f, 4f, 5f);
            Wall w2 = new Wall("2", -5f, 4f, 0f);
            Wall w3 = new Wall("3", -5f, 4f, 10f);
            Wall w4 = new Wall("4", 0f, 4f, 15f);
            Wall w5 = new Wall("5", 10f, 4f, 10f);
            Wall w6 = new Wall("6", -15f, 4f, 10f);
            Wall w7 = new Wall("7", -15f, 4f, 0f);
            Wall w8 = new Wall("8", 10f, 4f, 0f);
            Wall w9 = new Wall("9", 0f, 4f, -5f);
            Wall w10 = new Wall("10", -2.5f, 6.9f, 5);
            w5.SetRotation(0, 90, 0);
            w5.SetScale(10f, 5f, 1f);
            w6.SetRotation(0, 90, 0);
            w6.SetScale(10f, 5f, 1f);
            w7.SetRotation(0, 90, 0);
            w7.SetScale(10f, 5f, 1f);
            w8.SetRotation(0, 90, 0);
            w8.SetScale(10f, 5f, 1f);
            w10.SetScale(25f, 1f, 20f);
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
        createMap();
        }
        public void createMap()
        {
            Map.SetCamera(
                 0f, 50f, 0f,                   // Position der Map-Kamera
                 ProjectionDirection.NegativeY, // Blickrichtung der Kamera (in diesem Beispiel nach unten)
                 80,                            // Sichtfeld der Kamera (in z.B. Metern) in der Breite
                 80,                            // Sichtfeld der Kamera (in z.B. Metern) in der Höhe
                 1,                             // Naheinstellgrenze (Objekte näher als 1 Einheit werden ignoriert)
                 100);                          // Ferneinstellgrenze (Weiter als 100 Einheiten entfernte Objekte werden ignoriert)

            // Position der Map auf dem Bildschirm konfigurieren:
            Map.SetViewport(
                Window.Width -1280/2,        // X-Position der Mitte der Map auf dem Bildschirm
                Window.Height - 720/2,       // Y-Position der Mitte der Map auf dem Bildschirm
                1280,                           // Breite der Map auf dem Bildschirm
               720,                           // Höhe der Map auf dem Bildschirm
               false);                         // Map soll als Kreis dargestellt werden

            // Optional: Hintergrund der Map konfigurieren
            Map.SetBackground(
                "./App/Textures/black.jpg",       // Hintergrundtextur
                10000,                           // Wie viele Einheiten der Spielwelt deckt der Hintergrund ab? (Breite)
                10000,                           // Wie viele Einheiten der Spielwelt deckt der Hintergrund ab? (Höhe)
                1f,                          // Sichtbarkeit 0 bis 1
                100.0f,                          // Texturwiederholung  X
                100.0f);                         // Texturwiederholung Y

                      

            FlowField pathfinding = new FlowField(0,2.5f,0,100, 100, 0.5f, 5, FlowFieldMode.Simple, typeof(Wall));
            pathfinding.IsVisible = false; //FLOWFIELD DEBUG VISIBILTY
            SetFlowField(pathfinding);
            
        }
    }
}
