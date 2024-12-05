using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

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
            int posX = 200;
            int posY = 200;
            HUDObjectText h1 = new HUDObjectText("BACK");
            h1.SetPosition(50f, 80f);
            h1.Name = "MyHUDObject1";
            h1.SetCharacterDistanceFactor(1.0f);
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(h1);


            HUDObjectText h2 = new HUDObjectText("Text1");
            h2.SetPosition(posX, posY);
            h2.SetColor(1,0,0);
            AddHUDObject(h2);
            posY += 50;

            HUDObjectText h3 = new HUDObjectText("Text2");
            h3.SetPosition(posX, posY);
            h3.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(h3);
            posY += 50;

            HUDObjectText h4 = new HUDObjectText("Text3");
            h4.SetPosition(posX, posY);
            h4.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(h4);
            posY += 100;
            posX -= 50;
            HUDObjectText h5 = new HUDObjectText("Diese Spiel wurde gemacht von:");
            h5.SetPosition(posX, posY);
            h5.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(h5);
            posY += 50;

            HUDObjectText h6 = new HUDObjectText("Dominik, Pascal und Til");
            h6.SetPosition(posX, posY);
            h6.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(h6);

            h2.SetText("Dieses Spiel wurde Inspiriert von");
            h3.SetText("IT STEALS");
            h4.SetText("gemacht von Zeekerrs");



        }
    }
}
