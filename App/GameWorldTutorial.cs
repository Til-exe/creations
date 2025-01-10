using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using KWEngine3.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using OpenTK.Windowing.Common.Input;
using Assimp;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Transactions;
using Gruppenprojekt.App.Menus;
using System.Diagnostics.Metrics;

namespace Gruppenprojekt.App
{
    public class GameWorldTutorial : World
    {

        private Player p;
        float finalPos = 0f;
        private float _HUDLastUpdate = 0;
        bool fullbright = false;
        public static bool complete1 = true;
        
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
            } return _HUDLastUpdate;
        }
        public void UpdateHUDLastUpdateTime()
        {
            _HUDLastUpdate = WorldTime;
        }
        public override void Act()
        {            
            HUDObjectText Text = GetHUDObjectTextByName("text");
            HUDObjectText Text1 = GetHUDObjectTextByName("text1");
            if (Globals.gameRunning ) {


                if (Globals.TutorialProgress == 0) {
                    Text.SetText("Collect the Red Collectable");
                }
                if (Globals.TutorialProgress == 1) {
                    Text.SetText("Press 'F' to use the Flashlight");
                }
                if (Globals.TutorialProgress == 2) {
                    Text.SetText("Press 'Shift' while Walking to Sprint");                    
                }
                if (Globals.TutorialProgress == 3) {
                    Text.SetText("Press 'R' to Open the Map");
                }
                if (Globals.TutorialProgress == 4) {
                    Text.SetText("Collect the Last Red Collectable");
                    Text1.SetText("to End the Tutorial");
                }
                if (Globals.TutorialProgress == 1 && complete1)
                {
                    p.SetPosition(0, 2, 0); 
                }
                if (Globals.TutorialProgress == 4 && complete1)
                {
                    p.SetPosition(0, 2, 0);
                    InteractionCollectable cComplete = new InteractionCollectable("1", 0f, 4f, 20f);
                    cComplete.SetColorEmissive(1, 0, 0, 10);
                    cComplete.l.SetColor(1, 0, 0, 10);
                    AddGameObject(cComplete);
                }
                if (Globals.TutorialProgress == 5)
                {
                    Globals.Level = 1;
                    Globals.Experience = 1;
                    Globals.TutorialComplete = true;
                    Globals.choseGamemode = "Normal";
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
                complete1 = false;
            } 
            else { Text.SetText(""); Text1.SetText(""); }
            if (Keyboard.IsKeyPressed(Keys.LeftShift )
                && (Keyboard.IsKeyPressed(Keys.W)
                || Keyboard.IsKeyPressed(Keys.A)
                || Keyboard.IsKeyPressed(Keys.D))
                && Globals.TutorialProgress == 2
                || Keyboard.IsKeyPressed(Keys.R) && Globals.TutorialProgress == 3
                || Keyboard.IsKeyPressed(Keys.F) && Globals.TutorialProgress == 1)
            { Globals.TutorialProgress++; complete1 = true; }

            if (Keyboard.IsKeyPressed(Keys.T))
            {
                FlowField f = GetFlowField();
                if (f != null)
                {
                    f.IsVisible = !f.IsVisible;
                }
            }
            if (Keyboard.IsKeyPressed(Keys.Enter))
            {
                Globals.TutorialComplete = true;
                Globals.choseGamemode = "Normal";
                GameWorldStartMenu gm = new GameWorldStartMenu();
                Window.SetWorld(gm);
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
            HUDObjectText text = new HUDObjectText("");
            text.SetPosition(Globals.fensterBreite/2, 40);
            text.SetTextAlignment(TextAlignMode.Center);
            text.Name = "text";
            text.SetCharacterDistanceFactor(1.0f);
            text.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text);
            HUDObjectText text1 = new HUDObjectText("");
            text1.SetPosition(Globals.fensterBreite / 2, 90);
            text1.SetTextAlignment(TextAlignMode.Center);
            text1.Name = "text1";
            text1.SetCharacterDistanceFactor(1.0f);
            text1.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text1);
            Console.WriteLine("[CONSOLE] World: GameWorldTutorial");
            HUDObjectText score = new HUDObjectText("");
            score.SetPosition(Globals.fensterBreite/2, 20);
            score.SetTextAlignment(TextAlignMode.Center);
            score.Name = "Punkte";
            score.SetCharacterDistanceFactor(1.0f);
            score.SetColor(1.0f, 0.0f, 0.0f); 
            AddHUDObject(score);

            FlowField pathfinding = new FlowField(0, 2.5f, 0, 50, 50, 0.5f, 5, FlowFieldMode.Simple, typeof(Wall));
            pathfinding.IsVisible = false; //FLOWFIELD DEBUG VISIBILTY
            //AddFlowField(pathfinding);

            PreLoadSounds();
            KWEngine.LoadModel("Pascal", "./App/Models/pascalbild.fbx");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/shortsound.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlight_click.wav");
            KWEngine3.Audio.Audio.PreloadSound(@"./App/Sounds/flashlightexplode.wav");

            SetBackgroundSkybox("./App/Textures/skybox.png");
            SetCameraFOV(100);
            SetColorAmbient(0.05f, 0.02f, 0.02f);
            KWEngine.MouseSensitivity = 0.07f;
            SetFadeColor(0, 0, 0);
            MouseCursorGrab();
            SetCameraPosition(0.0f, 2.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);

            Floor f = new Floor("floor", 1f, 1f, 1f);
            f.SetTexture("./app/Textures/wood1.png");
            if (Globals.ReturnCode == 0) { }
            if (Globals.ReturnCode == 1) { Globals.ReturnCode = 0; Globals.Score += 1000; }
            f.SetTextureRepeat(100f, 100f);           
            AddGameObject(f);

            p = new Player("Yasin", 0f, 2f, 0f);
            AddGameObject(p);
            SetCameraToFirstPersonGameObject(p, 2f);
            //Enemy e = new Enemy("huso", -12.5f, 2, 13);
            //AddGameObject(e);
            float xCord = 4f;
            float ScaleHoehe = 5f;
            InteractionCollectable cComplete = new InteractionCollectable("1",0f, 4f, 20f);
            cComplete.SetColorEmissive(1,0,0,10);
            cComplete.l.SetColor(1, 0, 0,10);
            AddGameObject(cComplete);
            //InteractionCollectable cNext = new InteractionCollectable("1", 100f, 4f, 100f);
            //cNext.SetColorEmissive(1,0,0,10);
            //cNext.l.SetColor(1, 0, 0,10);
            //AddGameObject(cNext);
            //Collectable c1 = new Collectable("1", 3f, 4f, 20f);
            //AddGameObject(c1);
            Wall borderNorth = new Wall("1", 100f, xCord, 0f);
            Wall borderSouth = new Wall("1", -100f, xCord, 0f);
            Wall borderWest = new Wall("1", 0f, xCord, 100f);
            Wall borderEast = new Wall("1", 0f, xCord, -100f);
            Wall w1 = new Wall("1", 5f, xCord, 10f);
            Wall w2 = new Wall("1", -5f, xCord, 10f);
            Wall w3 = new Wall("1", 0f, xCord, 25f);
            Wall w4 = new Wall("1", 0f, xCord, -5f);
            if (true) {
                w1.AddRotationY(90);
                w1.SetScale(30,ScaleHoehe,1);
                w1.SetTextureRepeat(15,3);
                w2.AddRotationY(90);
                w2.SetScale(30, ScaleHoehe, 1);
                w2.SetTextureRepeat(15,3);
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
            if (true) {
                AddGameObject(borderWest);
                AddGameObject(borderEast);
                AddGameObject(borderNorth);
                AddGameObject(borderSouth);
                AddGameObject(w1);
                AddGameObject(w2);
                AddGameObject(w3);
                AddGameObject(w4);
            } //Add Game Objekts
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
    }
}