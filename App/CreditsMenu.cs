using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Gruppenprojekt.App
{
    public class CreditsMenu : World
    {
        public override void Act()
        {
            
            HUDObjectText h1 = GetHUDObjectTextByName("MyHUDObject1");
            
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
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }
            
        }


        public override void Prepare()
        {

            HUDObjectText h1 = new HUDObjectText("BACK");
            h1.SetPosition(50f, 80f);
            h1.Name = "MyHUDObject1";
            h1.SetCharacterDistanceFactor(1.0f);
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(h1);


            HUDObjectText h2 = new HUDObjectText("Text1");
            h2.SetPosition(160f, 250f);
            h2.Name = "MyHUDObject2";
            h2.SetCharacterDistanceFactor(1.0f);
            h2.SetColor(1.0f, 0.0f, 0.0f);
            
            AddHUDObject(h2);


            HUDObjectText h3 = new HUDObjectText("Text2");
            h3.SetPosition(160f, 300f);
            h3.Name = "MyHUDObject3";
            h3.SetCharacterDistanceFactor(1.0f);
            h3.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(h3);

            HUDObjectText h4 = new HUDObjectText("Text3");
            h4.SetPosition(160f, 350f);
            h4.Name = "MyHUDObject3";
            h4.SetCharacterDistanceFactor(1.0f);
            h4.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(h4);

            h2.SetText("Vielen Dank an:");
            h3.SetText("Dominik, Pascal, Til");
            h4.SetText("Für das Entwickeln dieses Spieles!");



        }
    }
}
