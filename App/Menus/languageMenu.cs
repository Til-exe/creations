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
    public class languageMenu : World
    {
        public override void Act()
        {
            HUDObjectText h1 = GetHUDObjectTextByName("MyHUDObject1");
            HUDObjectText Deutsch = GetHUDObjectTextByName("Deutsch");
            HUDObjectText English = GetHUDObjectTextByName("English");
            HUDObjectText Spanisch = GetHUDObjectTextByName("Spanisch");
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
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }
            if (Deutsch != null)
            {
                if (Deutsch.IsMouseCursorOnMe() == true)
                {
                    Deutsch.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    Deutsch.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && Deutsch.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    Deutsch.SetText("Deutsch");
                    English.SetText("English");
                    Spanisch.SetText("Spanisch");
                    Globals.SetLanguage = "Deutsch";
                }
            }
            if (English != null)
            {
                if (English.IsMouseCursorOnMe() == true)
                {
                    English.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    English.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && English.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);

                    Deutsch.SetText("Deutsch");
                    English.SetText("English");
                    Spanisch.SetText("Spanisch");
                    Globals.SetLanguage = "English";
                }
            }
            if (Spanisch != null)
            {
                if (Spanisch.IsMouseCursorOnMe() == true)
                {
                    Spanisch.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    Spanisch.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && Spanisch.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);

                    Deutsch.SetText("Deutsch");
                    English.SetText("English");
                    Spanisch.SetText("Spanisch");
                    Globals.SetLanguage = "Spanisch";
                }
            }
            if (Globals.SetLanguage == "Deutsch") { Deutsch.SetText("> Deutsch"); }
            if (Globals.SetLanguage == "English") { English.SetText("> English"); }
            if (Globals.SetLanguage == "Spanisch") { Spanisch.SetText("> Spanisch"); }
        }
        public override void Prepare()
        {
            //Console.WriteLine("[CONSOLE] World: LanguageMenu");
            HUDObjectText h1 = new HUDObjectText(Globals.backText);
            h1.SetPosition(50f, 80f);
            h1.Name = "MyHUDObject1";
            h1.SetCharacterDistanceFactor(1.0f);
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(h1);

            HUDObjectText Deutsch = new HUDObjectText("Deutsch");
            Deutsch.SetPosition(160f, 250f);
            Deutsch.Name = "Deutsch";
            Deutsch.SetCharacterDistanceFactor(1.0f);
            Deutsch.SetColor(1.0f, 0.0f, 0.0f);
            Deutsch.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Deutsch);

            HUDObjectText English = new HUDObjectText("English");
            English.SetPosition(160f, 300f);
            English.Name = "English";
            English.SetCharacterDistanceFactor(1.0f);
            English.SetColor(1.0f, 0.0f, 0.0f);
            English.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(English);

            HUDObjectText Spanisch = new HUDObjectText("Spanisch");
            Spanisch.SetPosition(160f, 350f);
            Spanisch.Name = "Spanisch";
            Spanisch.SetCharacterDistanceFactor(1.0f);
            Spanisch.SetColor(1.0f, 0.0f, 0.0f);
            Spanisch.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Spanisch);

            Deutsch.SetText("Deutsch");
            English.SetText("English");
            Spanisch.SetText("Spanisch");
        }
        public static void ChangeLanguage()
        {
            if (Globals.SetLanguage == "Deutsch")
            {
                Globals.StartButtonText = "Start";
                Globals.OptionButtonText = "Optionen";
                Globals.LanguageButtonText = "Sprache";
                Globals.CreditsButtonText = "Danksage";
                Globals.ScoreboardButtonText = "Admin";
                Globals.InfoButtonText = "Info"; 
                Globals.LeaveButtonText = "Verlassen";
                Globals.ActualScoreboardText = "PUNKTETAFEL";
                Globals.choseGamemodeText = "SPIELMODUS";
                Globals.enabledText = "AKTIVIERT";
                Globals.disabledText = "DEAKTIVIERT";
                Globals.backText = "Zurück";
            }
            if (Globals.SetLanguage == "English")
            {
                Globals.StartButtonText = "Start";
                Globals.OptionButtonText = "Options";
                Globals.LanguageButtonText = "Language";
                Globals.CreditsButtonText = "Credits";
                Globals.ScoreboardButtonText = "Admin";
                Globals.InfoButtonText = "Info";
                Globals.LeaveButtonText = "Leave";
                Globals.ActualScoreboardText = "SCOREBOARD";
                Globals.choseGamemodeText = "GAMEMODE";
                Globals.enabledText = "ENABLED";
                Globals.disabledText = "DISABLED";
                Globals.backText = "Back";


            }
            if (Globals.SetLanguage == "Spanisch")
            {
                Globals.StartButtonText = "Comenzar";
                Globals.OptionButtonText = "Opciones";
                Globals.LanguageButtonText = "Idioma";
                Globals.CreditsButtonText = "Créditos";
                Globals.ScoreboardButtonText = "Admin";
                Globals.InfoButtonText = "Info oder so";
                Globals.LeaveButtonText = "Dejar";
                Globals.ActualScoreboardText = "MARCADOR"; 
                Globals.enabledText = "activades";
                Globals.disabledText = "deactivades";
                Globals.backText = "Baguette";


            }
        }
    }
}