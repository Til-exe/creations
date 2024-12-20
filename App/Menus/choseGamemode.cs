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
    public class choseGamemode : World
    {
        public override void Act()
        {
            HUDObjectText back = GetHUDObjectTextByName("back");
            HUDObjectText normal = GetHUDObjectTextByName("Normal");
            HUDObjectText infinit = GetHUDObjectTextByName("Infinit");
            HUDObjectText peacefull = GetHUDObjectTextByName("Peacefull");
            HUDObjectText hard = GetHUDObjectTextByName("Hard");
            HUDObjectText tutorial = GetHUDObjectTextByName("Tutorial");
            GameWorldStartMenu.functionBackButton(back);
            
            functionGamemodeChose(normal, "Normal");
            functionGamemodeChose(infinit, "Infinit");
            functionGamemodeChose(peacefull, "Peacefull");
            functionGamemodeChose(hard, "Hard"); 
            
            functionGamemodeChose(tutorial, "Tutorial");
            infinit.SetText("Infinit");
            normal.SetText("Normal");
            peacefull.SetText("Friedlich");
            hard.SetText("Schwer");
            tutorial.SetText("Tutorial");
            if (Globals.choseGamemode == "Infinit") { infinit.SetText("> Infinit"); }
            if (Globals.choseGamemode == "Normal") { normal.SetText("> Normal"); }
            if (Globals.choseGamemode == "Peacefull") { peacefull.SetText("> Friedlich"); }
            if (Globals.choseGamemode == "Hard") { hard.SetText("> Schwer"); }
            if (Globals.choseGamemode == "Tutorial") { tutorial.SetText("> Tutorial"); }
        }
        public override void Prepare()
        {
            //Console.WriteLine("[CONSOLE] World: choseGamemode");
            HUDObjectText back = new HUDObjectText(Globals.backText);
            back.SetPosition(50f, 80f);
            back.Name = "back";
            back.SetCharacterDistanceFactor(1.0f);
            back.SetColor(1.0f, 0.0f, 0.0f);
            back.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(back);

            HUDObjectText h = new HUDObjectText(""); //Text: "Hat bislang noch keine Auswirkungen auf das Spiel"
            h.SetPosition(160f, 180f);
            h.Name = "MyHUDObject1";
            h.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(h);

            HUDObjectText Normal = new HUDObjectText("Normal");
            Normal.SetPosition(160f, 300f);
            Normal.Name = "Normal";
            Normal.SetCharacterDistanceFactor(1.0f);
            Normal.SetColor(1.0f, 0.0f, 0.0f);
            Normal.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Normal);

            HUDObjectText Infinit = new HUDObjectText("Infinit");
            Infinit.SetPosition(160f, 400f);
            Infinit.Name = "Infinit";
            Infinit.SetCharacterDistanceFactor(1.0f);
            Infinit.SetColor(1.0f, 0.0f, 0.0f);
            Infinit.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Infinit);

            HUDObjectText Peacefull = new HUDObjectText("Peacefull");
            Peacefull.SetPosition(160f, 250f);
            Peacefull.Name = "Peacefull";
            Peacefull.SetColor(1.0f, 0.0f, 0.0f);
            Peacefull.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Peacefull);

            HUDObjectText Hard = new HUDObjectText("Hard");
            Hard.SetPosition(160f, 350f);
            Hard.Name = "Hard";
            Hard.SetColor(1.0f, 0.0f, 0.0f);
            Hard.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Hard);

            HUDObjectText Tutorial = new HUDObjectText("Tutorial");
            Tutorial.SetPosition(160f, 450f);
            Tutorial.Name = "Tutorial";
            Tutorial.SetColor(1.0f, 0.0f, 0.0f);
            Tutorial.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Tutorial);

            Normal.SetText("Normal");
            Infinit.SetText("Infinit");
            Peacefull.SetText("Peacefull");
            Hard.SetText("Hard");
            Tutorial.SetText("Tutorial");

            if(!Globals.TutorialComplete)
            {
                Hard.SetOpacity(0.7f);
                Normal.SetOpacity(0.7f);
                Infinit.SetOpacity(0.7f);
                Peacefull.SetOpacity(0.7f);
            }
                
        }
        public static void gamemodePrepare()
        {
            if (Globals.choseGamemode == "Infinit") { }
            if (Globals.choseGamemode == "Normal") { }
            if (Globals.choseGamemode == "Peacefull") { }
            if (Globals.choseGamemode == "Hard") { }
            if (Globals.choseGamemode == "Tutorial") { }
        }
        private static void functionGamemodeChose(HUDObject i, string gamemode)
        {
            if (i != null)
            {
                if (i.IsMouseCursorOnMe() == true)
                {
                    if (Globals.TutorialComplete)
                        i.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    i.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && i.IsMouseCursorOnMe() == true)
                {
                    if (Globals.TutorialComplete)
                        Globals.choseGamemode = gamemode;
                }
            }
        }
    }
}