using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Gruppenprojekt.App
{
    public class GameWorldStartMenu : World
    {

        public override void Act()
        {
            HUDObjectText h = GetHUDObjectTextByName("MyHUDObject");

            // Wenn ein Objekt dieses Typs und dieses Namens gefunden werden
            // konnte, ist die Variable h nicht 'leer', also 'nicht null':
            if (h != null)
            {
                if (h.IsMouseCursorOnMe() == true)
                {
                    h.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    h.SetColorEmissiveIntensity(0.0f);
                }
            }
            if (Keyboard.IsKeyDown(Keys.W)) { }
        }

        public override void Prepare()
        {
            // Platziere ein textbasiertes HUD-Objekt:
            HUDObjectText h = new HUDObjectText("HUD");
            h.SetPosition(64, 32);                // 64 Pixel von links und 
                                                  // 32 Pixel von oben auf dem Bildschirm 
            h.Name = "MyHUDObject";               // Interner Name des Objekts, damit es später 
                                                  // von anderen Objekten gefunden werden kann
            h.SetCharacterDistanceFactor(1.0f);   // Abstandsmultiplikator (der Buchstaben zueinander)
            h.SetColor(1.0f, 0.0f, 0.0f);         // Reguläre Färbung (hier: rot)
            h.SetColorEmissive(1.0f, 1.0f, 1.0f); // Glühfarbe (RGB), die Intensität wird separat geregelt

            AddHUDObject(h);


            SetBackgroundSkybox("./App/Textures/skybox.png");
            SetCameraPosition(0.0f, 2.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);
            SetCameraFOV(100);
            SetColorAmbient(0.75f, 0.75f, 0.75f);
            Floor f = new Floor("floor", 1f, 1f, 1f);
            f.SetTexture("./app/Textures/wood1.jpg");
            f.SetTextureRepeat(10f, 10f);
            AddGameObject(f);
            Player p = new Player("Yasin", 1f, 2f, 1f);
            AddGameObject(p);

            SetCameraToFirstPersonGameObject(p, 2f);
            KWEngine.MouseSensitivity = 0.05f;
            MouseCursorGrab();


            LightObject light = new LightObject(LightType.Sun, ShadowQuality.Low);
            light.Name = ("scheiß auf den Namen");
            light.SetNearFar(0.1f, 25f);
            light.SetPosition(0f, 5f, 0);
            AddLightObject(light);


            //test 
            Enemy e = new Enemy("huso", 1, 2, 1);
            AddGameObject(e);


        }
    }
}
