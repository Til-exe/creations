using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;

namespace Gruppenprojekt.App
{
    public class GameWorldStart : World
    {
        
        public override void Act()
        {
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

            float deltat = Math.Clamp((WorldTime - _HUDLastUpdate) * 0.5f, 0, 1);
            HUDObjectText t = GetHUDObjectTextByName("BLA");
            t.SetOpacity(1 - deltat);

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
            f.SetTexture("./app/Textures/wood1.png");
            f.SetTextureRepeat(100f, 100f);
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
            Enemy e = new Enemy("huso" , 1, 2, 1);
            AddGameObject(e);
            Collectable c1 = new Collectable("1", 3f, 3f, 20f);
            Collectable c2 = new Collectable("2", 10f, 3f, 20f);
            Collectable c3 = new Collectable("3", 20f, 3f, 20f);
            AddGameObject(c1);
            AddGameObject(c2);
            AddGameObject(c3);
            Wall w1 = new Wall("1", 30f, 2f, 50f);
            w1.SetScale(10f, 15f, 5f);
            AddGameObject(w1);
        }
    }
}
