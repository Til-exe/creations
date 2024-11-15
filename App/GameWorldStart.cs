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
            
        }

        public override void Prepare()
        {

            SetBackgroundSkybox("./App/Textures/skybox.png");
            SetCameraPosition(0.0f, 2.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);
            SetCameraFOV(100);
            SetColorAmbient(0.75f, 0.75f, 0.75f);
            Floor f = new Floor("floor", 1f, 1f, 1f);
            f.SetTexture("./app/Textures/wood1.png");
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
            Enemy e = new Enemy("huso" , 1, 2, 1);
            AddGameObject(e);
            Collectable c1 = new Collectable("1", 3f, 3f, 20f);
            Collectable c2 = new Collectable("2", 10f, 3f, 20f);
            Collectable c3 = new Collectable("3", 20f, 3f, 20f);
            AddGameObject(c1);
            AddGameObject(c2);
            AddGameObject(c3);
        }
    }
}
