using System.Security.Cryptography.X509Certificates;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Gruppenprojekt.App.Classes;
using Gruppenprojekt.App.Menus;
using KWEngine3.GameObjects;
using OpenTK.Mathematics;
using System.Xml.Linq;
using KWEngine3.Audio;
using System.Linq;
using System.IO;
using KWEngine3;
using System;

namespace Gruppenprojekt.App.Menus
{
    public class IntroScreen : World
    {
        int hochzähler = 0;
        int hochzähler1 = 0;
        float tScale = 1.0f;
        bool maxGerreicht = true;
        public override void Act()
        {
            
            HUDObjectText title = GetHUDObjectTextByName("itSteals");
            HUDObjectText start = GetHUDObjectTextByName("start");
            /*HUDObjectText back = GetHUDObjectTextByName("back");
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
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }*/
            if (maxGerreicht)
            {
                if (hochzähler != -1) { hochzähler++; }                    
                if (hochzähler1 != -1) { hochzähler1++; }
                if (hochzähler == 2) {
                    hochzähler = 0;
                    tScale++;
                    title.SetScale(tScale); }                    
                if (tScale == 120.0f) {
                    hochzähler = -2;
                    maxGerreicht = false;
                    start.SetScale(50f);
                }
                if (hochzähler1 == 240) 
                {
                    
                }

            }
            if (start != null)
            {
                if (start.IsMouseCursorOnMe() == true)
                {
                    start.SetColorEmissiveIntensity(1.0f);
                }
                else
                {
                    start.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && start.IsMouseCursorOnMe() == true)
                {
                    GameWorldStartMenu gwo = new GameWorldStartMenu();
                    Window.SetWorld(gwo);

                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 255f);
                }
            }
        }
        public override void Prepare()
        {/*
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

            HUDObjectText h4 = new HUDObjectText("gemacht von Zeekerrs");
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
            AddHUDObject(h6);*/
            GameWorldStart.PreLoadSounds(); 
            //KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/IntroMusic1.wav", false, 0.5f);
            HUDObjectText title = new HUDObjectText("ITS STOLEN");
            title.Name = "itSteals";
            title.SetScale(1f);
            title.SetPosition(Globals.fensterBreite/2,Globals.fensterHoehe/2-100);
            title.SetTextAlignment(TextAlignMode.Center);
            title.SetColor(1, 0, 0);
            AddHUDObject(title);

            HUDObjectText start = new HUDObjectText("Start");
            start.Name = "start";
            start.SetScale(1f);
            start.SetPosition(Globals.fensterBreite / 2, Globals.fensterHoehe / 2 + 100f);
            start.SetTextAlignment(TextAlignMode.Center);
            start.SetColor(1, 0, 0);
            start.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(start);
            
        }
    }
}
