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
            if (maxGerreicht)
            {
                if (hochzähler != -1) { hochzähler++; }                    
                if (hochzähler1 != -1) { hochzähler1++; }
                if (hochzähler == 2) {
                    hochzähler = 0;
                    tScale++;
                    title.SetScale(tScale/2); }                    
                if (tScale == 240.0f) {
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

                    KWEngine3.Audio.Audio.StopAllSound();
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);

                }
            }
        }
        public override void Prepare()
        {
            if(Globals.TutorialComplete)
            {
                Globals.choseGamemode ="Normal"; 
            }
            else
            {
                Globals.choseGamemode = "Tutorial";
            }
            
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/IntroMusic1.wav", false, 0.06f);
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
