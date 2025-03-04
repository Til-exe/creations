using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace Gruppenprojekt.App.Menus
{
    public class CreditsMenu : World
    {
        public override void Act()
        {
            HUDObjectText back = GetHUDObjectTextByName("back");
            if (back != null)
            {
                if (back.IsMouseCursorOnMe() == true)
                {
                    back.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    back.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && back.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }
        }
        public override void Prepare()
        {
            //Console.WriteLine("[CONSOLE] World: CreditsMenu");
            int posX = 200;
            int posY = 200;
            HUDObjectText back = new HUDObjectText("BACK");
            back.SetPosition(50f, 80f);
            back.Name = "back";
            back.SetColor(1.0f, 0.0f, 0.0f);
            back.SetColorEmissive(1.0f, 1.0f, 1.0f);

            HUDObjectText h2 = new HUDObjectText("Dieses Spiel wurde Inspiriert von");
            h2.SetPosition(posX, posY);
            h2.SetColor(1, 0, 0);
            posY += 50;

            HUDObjectText h3 = new HUDObjectText("IT STEALS");
            h3.SetPosition(posX, posY);
            h3.SetColor(1.0f, 0.0f, 0.0f);
            posY += 50;

            HUDObjectText h4 = new HUDObjectText("gemacht von Zeekerss");
            h4.SetPosition(posX, posY);
            h4.SetColor(1.0f, 0.0f, 0.0f);
            posY += 100;
            posX -= 50;

            HUDObjectText h5 = new HUDObjectText("Diese Spiel wurde gemacht von:");
            h5.SetPosition(posX, posY);
            h5.SetColor(1.0f, 0.0f, 0.0f);
            posY += 50;

            HUDObjectText h6 = new HUDObjectText("Dominik, Pascal und Til");
            h6.SetPosition(posX, posY);
            h6.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(back);
            AddHUDObject(h2);
            AddHUDObject(h3);
            AddHUDObject(h4);
            AddHUDObject(h5);
            AddHUDObject(h6);
        }
    }
}
