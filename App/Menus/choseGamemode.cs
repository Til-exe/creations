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

            HUDObjectText h1 = GetHUDObjectTextByName("MyHUDObject1");
            HUDObjectText normal = GetHUDObjectTextByName("Normal");
            HUDObjectText infinit = GetHUDObjectTextByName("Infinit");
            HUDObjectText peacefull = GetHUDObjectTextByName("Peacefull");
            HUDObjectText hard = GetHUDObjectTextByName("Hard");
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
                    GwStartMenuOption gwo = new GwStartMenuOption();
                    Window.SetWorld(gwo);
                }
            }
            if (normal != null)
            {
                if (normal.IsMouseCursorOnMe() == true)
                {
                    normal.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    normal.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && normal.IsMouseCursorOnMe() == true)
                {
                    Globals.choseGamemode = "Normal";
                }
            }
            if (infinit != null)
            {
                if (infinit.IsMouseCursorOnMe() == true)
                {
                    infinit.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    infinit.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && infinit.IsMouseCursorOnMe() == true)
                {
                    Globals.choseGamemode = "Infinit";
                }
            }
            if (peacefull != null)
            {
                if (peacefull.IsMouseCursorOnMe() == true)
                {
                    peacefull.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    peacefull.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && peacefull.IsMouseCursorOnMe() == true)
                {
                    Globals.choseGamemode = "Peacefull";
                }

            }
            if (hard != null)
            {
                if (hard.IsMouseCursorOnMe() == true)
                {
                    hard.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    hard.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && hard.IsMouseCursorOnMe() == true)
                {

                    Globals.choseGamemode = "Hard";
                }
            }
            infinit.SetText("Infinit");
            normal.SetText("Normal");
            peacefull.SetText("Friedlich");
            hard.SetText("Schwer");
            if (Globals.choseGamemode == "Infinit") { infinit.SetText("> Infinit"); }
            if (Globals.choseGamemode == "Normal") { normal.SetText("> Normal"); }
            if (Globals.choseGamemode == "Peacefull") { peacefull.SetText("> Friedlich"); }
            if (Globals.choseGamemode == "Hard") { hard.SetText("> Schwer"); }
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

            Normal.SetText("Normal");
            Infinit.SetText("Infinit");
            Peacefull.SetText("Peacefull");
            Hard.SetText("Hard");
        }
        public static void gamemodePrepare()
        {
            if (Globals.choseGamemode == "Infinit") { }
            if (Globals.choseGamemode == "Normal") { }
            if (Globals.choseGamemode == "Peacefull") { }
            if (Globals.choseGamemode == "Hard") { }
        }
    }
}