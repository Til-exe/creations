using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace Gruppenprojekt.App.Menus
{
    public class LevelMenu : World
    {
        int dLevel = 0;
        public override void Act()
        {
            HUDObjectText back = GetHUDObjectTextByName("back");
            HUDObjectText dLevelText = GetHUDObjectTextByName("dLevelText");
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
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 0.2f);
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }
            if(Keyboard.IsKeyPressed(Keys.Left))
            {
                dLevel--;   
            }
            if (Keyboard.IsKeyPressed(Keys.Right))
            {
                dLevel++;
            }
            dLevelText.SetText("Level " + Math.Clamp(dLevel, 0, 5));
        }
        public override void Prepare()
        {
            int posX = 200;
            int posY = 200;
            HUDObjectText back = new HUDObjectText("BACK");
            back.SetPosition(50f, 80f);
            back.Name = "back";
            back.SetColor(1.0f, 0.0f, 0.0f);
            back.SetColorEmissive(1.0f, 1.0f, 1.0f);

            
            posY += 50;

            HUDObjectText dLevelText = new HUDObjectText("Level " + Math.Clamp(dLevel, 0, 5));
            dLevelText.SetPosition(posX, posY);
            dLevelText.SetColor(1.0f, 0.0f, 0.0f);
            dLevelText.Name = "dLevelText";
            posY += 50;

            HUDObjectText h4 = new HUDObjectText("NOCH NICHT FERTIG ");
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
            AddHUDObject(dLevelText);
            AddHUDObject(h4);
            AddHUDObject(h5);
            AddHUDObject(h6);
        }
    }
}
