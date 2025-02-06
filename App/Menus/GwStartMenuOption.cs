using OpenTK.Windowing.GraphicsLibraryFramework;
using static System.Net.Mime.MediaTypeNames;
using Gruppenprojekt.App.Classes;
using System.Linq.Expressions;
using static Assimp.Metadata;
using KWEngine3.GameObjects;
using OpenTK.Mathematics;
using KWEngine3.Audio;
using System.IO;
using KWEngine3;
using System;

namespace Gruppenprojekt.App.Menus
{
    public class GwStartMenuOption : World
    {
        int value1 = 0;
        int value2 = 0;
        int value3 = 0;
        int counter = 0;
        bool codeEnterd = true;
        public override void Act()
        {
            
            HUDObjectText back = GetHUDObjectTextByName("back");
            HUDObjectText enter = GetHUDObjectTextByName("Enter");
            HUDObjectText reset = GetHUDObjectTextByName("Reset");
            HUDObjectText plus1 = GetHUDObjectTextByName("plus1");
            HUDObjectText minus1 = GetHUDObjectTextByName("minus1");
            HUDObjectText score1 = GetHUDObjectTextByName("score1");

            HUDObjectText plus2 = GetHUDObjectTextByName("plus2");
            HUDObjectText minus2 = GetHUDObjectTextByName("minus2");
            HUDObjectText score2 = GetHUDObjectTextByName("score2");

            HUDObjectText plus3 = GetHUDObjectTextByName("plus3");
            HUDObjectText minus3 = GetHUDObjectTextByName("minus3");
            HUDObjectText score3 = GetHUDObjectTextByName("score3");

            HUDObjectText code = GetHUDObjectTextByName("code");
            HUDObjectText EnableCredits = GetHUDObjectTextByName("EnableCredits");
            HUDObjectText EnableLanguage = GetHUDObjectTextByName("EnableLanguage");
            HUDObjectText EnableScoreboard = GetHUDObjectTextByName("EnableScoreboard");
            HUDObjectText EnableInfo = GetHUDObjectTextByName("EnableInfo");
            HUDObjectText gamemode = GetHUDObjectTextByName("gamemode");
            HUDObjectText intro = GetHUDObjectTextByName("intro");
            HUDObjectText infoMenu = GetHUDObjectTextByName("info");
            HUDObjectText admin = GetHUDObjectTextByName("admin");
            HUDObjectText language = GetHUDObjectTextByName("language");
            if (back != null)
            {
                //BACK

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
            if (enter != null)
            {
                //Leave game

                if (enter.IsMouseCursorOnMe() == true)
                {
                    enter.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    enter.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && enter.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    if (value1 == 14 && 
                        value2 == 26 && 
                        value3 == 30 && 
                        codeEnterd)
                    { 
                        code.SetText("CODE AKTIVIERT"); codeEnterd = false;
                        Globals.ReturnCode = 1;
                    }                       
                }
            }
            if (reset != null)
            {
                if (reset.IsMouseCursorOnMe() == true)
                {
                    reset.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    reset.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && reset.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    code.SetText("");
                    value1 = 0;
                    value2 = 0;
                    value3 = 0;
                }
            }
            if (plus1 != null)
            {
                //Option

                if (plus1.IsMouseCursorOnMe() == true)
                {
                    plus1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    plus1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && plus1.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);
                    value1++;
                }
            }
            if (plus2 != null)
            {
                //Option

                if (plus2.IsMouseCursorOnMe() == true)
                {
                    plus2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    plus2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && plus2.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);
                    value2++;

                }
            }
            if (plus3 != null)
            {
                //Option

                if (plus3.IsMouseCursorOnMe() == true)
                {
                    plus3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    plus3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && plus3.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);
                    value3++;

                }
            }
            if (minus1 != null)
            {
                //Leave game

                if (minus1.IsMouseCursorOnMe() == true)
                {
                    minus1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    minus1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && minus1.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);

                    if (value1 == 0)
                    {
                        value1 = 37;
                    }
                    if (value1 >= 1)
                    {
                        value1--;
                    }

                }
            }
            if (minus2 != null)
            {
                //Leave game

                if (minus2.IsMouseCursorOnMe() == true)
                {
                    minus2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    minus2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && minus2.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);

                    if (value2 == 0)
                    {
                        value2 = 37;
                    }
                    if (value2 >= 1)
                    {
                        value2--;
                    }

                }
            }
            if (minus3 != null)
            {
                if (minus3.IsMouseCursorOnMe() == true)
                {
                    minus3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    minus3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && minus3.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);

                    if (value3 == 0)
                    {
                        value3 = 37;
                    }
                    if (value3 >= 1)
                    {
                        value3--;
                    }

                }
            }
            if (EnableCredits != null)
            {
                if (EnableCredits.IsMouseCursorOnMe() == true)
                {
                    EnableCredits.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    EnableCredits.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && EnableCredits.IsMouseCursorOnMe() == true)
                {

                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    if (Globals.DisplayCreditsButton)
                    {
                        EnableCredits.SetText("CREDITS: " + Globals.disabledText);

                    }
                    else
                    {
                        EnableCredits.SetText("CREDITS: " + Globals.enabledText);

                    }
                    Globals.DisplayCreditsButton = !Globals.DisplayCreditsButton;
                }
            }
            if (EnableLanguage != null)
            {
                if (EnableLanguage.IsMouseCursorOnMe() == true)
                {
                    EnableLanguage.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    EnableLanguage.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && EnableLanguage.IsMouseCursorOnMe() == true)
                {

                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    if (Globals.DisplayLanguageButton)
                    {
                        EnableLanguage.SetText("LANGUAGE: " + Globals.disabledText);
                    }
                    else
                    {
                        EnableLanguage.SetText("LANGUAGE: " + Globals.enabledText);
                    }
                    Globals.DisplayLanguageButton = !Globals.DisplayLanguageButton;
                }
            }
            if (EnableScoreboard != null)
            {
                if (EnableScoreboard.IsMouseCursorOnMe() == true)
                {
                    EnableScoreboard.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    EnableScoreboard.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && EnableScoreboard.IsMouseCursorOnMe() == true)
                {

                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    if (Globals.DisplayScoreboardButton) {
                        EnableScoreboard.SetText("ADMIN: " + Globals.disabledText);                        
                    }
                    else {
                        EnableScoreboard.SetText("ADMIN: " + Globals.enabledText);                        
                    }
                    Globals.DisplayScoreboardButton = !Globals.DisplayScoreboardButton;

                }
            }
            if (EnableInfo != null)
            {
                if (EnableInfo.IsMouseCursorOnMe() == true)
                {
                    EnableInfo.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    EnableInfo.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && EnableInfo.IsMouseCursorOnMe() == true)
                {

                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    if (Globals.DisplayInfoButton)
                    {
                        EnableInfo.SetText("INFO: " + Globals.disabledText);

                    }
                    else
                    {
                        EnableInfo.SetText("INFO: " + Globals.enabledText);

                    }
                    Globals.DisplayInfoButton = !Globals.DisplayInfoButton;
                }
            }
            if (gamemode != null)
            {
                if (gamemode.IsMouseCursorOnMe() == true)
                {
                    gamemode.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    gamemode.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && gamemode.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    choseGamemode cGm = new choseGamemode();
                    Window.SetWorld(cGm);
                }
            }
            if (intro != null)
            {
                //BACK

                if (intro.IsMouseCursorOnMe() == true)
                {
                    intro.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    intro.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && intro.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    IntroScreen i = new IntroScreen();
                    Window.SetWorld(i);
                }
            }
            if (infoMenu != null)
            {
                if (infoMenu.IsMouseCursorOnMe() == true)
                {
                    infoMenu.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    infoMenu.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && infoMenu.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    InfoMenu infomenu = new InfoMenu();
                    Window.SetWorld(infomenu);
                }
            }
            if(GameWorldStartMenu.AdminMode)
            {
                if (admin != null)
                {
                    if (admin.IsMouseCursorOnMe() == true)
                    {
                        admin.SetColorEmissiveIntensity(1.5f);
                    }
                    else
                    {
                        admin.SetColorEmissiveIntensity(0.0f);
                    }
                    if (Mouse.IsButtonPressed(MouseButton.Left) && admin.IsMouseCursorOnMe() == true)
                    {
                        KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                        AdminMenu adminM = new AdminMenu();
                        Window.SetWorld(adminM);
                    }
                }
            }
            else
            {
                admin.SetOpacity(0.7f);
                admin.SetColorEmissiveIntensity(0.0f);
            }
            
            if (language != null)
            {
                if (language.IsMouseCursorOnMe() == true)
                {
                    language.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    language.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && language.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    languageMenu languageM = new languageMenu();
                    Window.SetWorld(languageM);
                }
            }
            string text1 = translateCode(Convert.ToString(value1));
            string text2 = translateCode(Convert.ToString(value2));
            string text3 = translateCode(Convert.ToString(value3));
            if (value1 == 37) { value1 = 0; }
            if (value2 == 37) { value2 = 0; }
            if (value3 == 37) { value3 = 0; }
            score1.SetText("| " + text1 + " |", true);  //update shown Value
            score2.SetText("| " + text2 + " |", true);  //update shown Value
            score3.SetText("| " + text3 + " |", true);  //update shown Value
        }
        public override void Prepare()
        {

            languageMenu.ChangeLanguage();
            //Console.WriteLine("[CONSOLE] World: GwStartMenuOption");
            HUDObjectText h1 = new HUDObjectText(Globals.backText);
            h1.SetPosition(50f, 80f);
            h1.Name = "back";
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(h1);

            HUDObjectText credits = new HUDObjectText("CREDITS:");
            credits.SetPosition(700f, 200f);
            credits.Name = "EnableCredits";
            credits.SetColor(1.0f, 0.0f, 0.0f);
            credits.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //AddHUDObject(credits);

            HUDObjectText language = new HUDObjectText("LANGUAGE:");
            language.SetPosition(700f, 250f);
            language.Name = "EnableLanguage";
            language.SetColor(1.0f, 0.0f, 0.0f);
            language.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //AddHUDObject(language);

            HUDObjectText scoreboard = new HUDObjectText("ADMIN:");
            scoreboard.SetPosition(700f, 300f);
            scoreboard.Name = "EnableScoreboard";
            scoreboard.SetColor(1.0f, 0.0f, 0.0f);
            scoreboard.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //AddHUDObject(scoreboard);

            HUDObjectText EnableInfo = new HUDObjectText("INFO:");
            EnableInfo.SetPosition(700f, 350f);
            EnableInfo.Name = "EnableInfo";
            EnableInfo.SetColor(1.0f, 0.0f, 0.0f);
            EnableInfo.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //AddHUDObject(EnableInfo);

            HUDObjectText admin = new HUDObjectText("ADMIN");
            admin.SetPosition(600f, Globals.fensterHoehe/2 + Globals.fensterHoehe /4 + Globals.fensterHoehe /10);
            admin.Name = "admin";
            admin.SetColor(1.0f, 0.0f, 0.0f);
            admin.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(admin);

            HUDObjectText languagee = new HUDObjectText(Globals.LanguageButtonText.ToUpper());
            languagee.SetPosition(800f, Globals.fensterHoehe / 2 + Globals.fensterHoehe / 4 + Globals.fensterHoehe / 10);
            languagee.Name = "language";
            languagee.SetColor(1.0f, 0.0f, 0.0f);
            languagee.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(languagee);

            if (Globals.DisplayCreditsButton == false)
            {
                credits.SetText("CREDITS: " + Globals.disabledText);                
            }
            else
            {
                credits.SetText("CREDITS: " + Globals.enabledText);
                Globals.DisplayCreditsButton = true;
            }

            if (Globals.DisplayLanguageButton == false)
            {
                language.SetText("LANGUAGE: " + Globals.disabledText);                
            }
            else
            {
                language.SetText("LANGUAGE: " + Globals.enabledText);
                Globals.DisplayLanguageButton = true;
            }

            if (Globals.DisplayScoreboardButton == false)
            {
                scoreboard.SetText("ADMIN: " + Globals.disabledText);                
            }
            else
            {
                scoreboard.SetText("ADMIN: " + Globals.enabledText);
                Globals.DisplayScoreboardButton = true;
            }


            if (Globals.DisplayInfoButton == false)
            {
                EnableInfo.SetText("INFO: " + Globals.disabledText);
            }
            else
            {
                EnableInfo.SetText("INFO: " + Globals.enabledText);
                Globals.DisplayInfoButton = true;
            }

            HUDObjectText Enter = new HUDObjectText(Globals.EnterCodeText);
            Enter.SetPosition(160f, 200f);
            Enter.Name = "Enter";
            Enter.SetColor(1.0f, 0.0f, 0.0f);
            Enter.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Enter);

            HUDObjectText Reset = new HUDObjectText(Globals.ResetCodeText);
            Reset.SetPosition(160f, 150f);
            Reset.Name = "Reset";
            Reset.SetColor(1.0f, 0.0f, 0.0f);
            Reset.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Reset);

            HUDObjectText code = new HUDObjectText("");
            code.SetPosition(160f, 400f);
            code.Name = "code";
            code.SetColor(1.0f, 1.0f, 1.0f);
            AddHUDObject(code);

            HUDObjectText minus1 = new HUDObjectText("| - |");
            minus1.SetPosition(160f, 350f);
            minus1.Name = "minus1";
            minus1.SetColor(1.0f, 0.0f, 0.0f);
            minus1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(minus1);

            HUDObjectText score1 = new HUDObjectText("| " + value1 + " |");
            score1.SetPosition(160f, 300f);
            score1.Name = "score1";
            score1.SetColor(1.0f, 0.0f, 0.0f);
            score1.SetColorEmissive(0.0f, 0.0f, 0.0f);
            AddHUDObject(score1);


            HUDObjectText plus1 = new HUDObjectText("| + |");
            plus1.SetPosition(160f, 250f);
            plus1.Name = "plus1";
            plus1.SetColor(1.0f, 0.0f, 0.0f);
            plus1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(plus1);

            HUDObjectText minus2 = new HUDObjectText("| - |");
            minus2.SetPosition(310f, 350f);
            minus2.Name = "minus2";
            minus2.SetColor(1.0f, 0.0f, 0.0f);
            minus2.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(minus2);

            HUDObjectText score2 = new HUDObjectText("| " + value2 + " |");
            score2.SetPosition(310f, 300f);
            score2.Name = "score2";
            score2.SetColor(1.0f, 0.0f, 0.0f);
            score2.SetColorEmissive(0.0f, 0.0f, 0.0f);
            AddHUDObject(score2);

            HUDObjectText plus2 = new HUDObjectText("| + |");
            plus2.SetPosition(310f, 250f);
            plus2.Name = "plus2";
            plus2.SetColor(1.0f, 0.0f, 0.0f);
            plus2.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(plus2);

            HUDObjectText minus3 = new HUDObjectText("| - |");
            minus3.SetPosition(460f, 350f);
            minus3.Name = "minus3";
            minus3.SetColor(1.0f, 0.0f, 0.0f);
            minus3.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(minus3);


            HUDObjectText score3 = new HUDObjectText("| " + value3 + " |");
            score3.SetPosition(460f, 300f);
            score3.Name = "score3";
            score3.SetColor(1.0f, 0.0f, 0.0f);
            score3.SetColorEmissive(0.0f, 0.0f, 0.0f);
            AddHUDObject(score3);

            HUDObjectText plus3 = new HUDObjectText("| + |");
            plus3.SetPosition(460f, 250f);
            plus3.Name = "plus3";
            plus3.SetColor(1.0f, 0.0f, 0.0f);
            plus3.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(plus3);

            HUDObjectText gamemode = new HUDObjectText(Globals.choseGamemodeText);
            gamemode.SetPosition(160f, Globals.fensterHoehe / 2 + Globals.fensterHoehe / 4 + Globals.fensterHoehe / 10);
            gamemode.Name = "gamemode";
            gamemode.SetColor(1.0f, 0.0f, 0.0f);
            gamemode.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(gamemode);

            HUDObjectText intro = new HUDObjectText("INTRO");
            intro.SetPosition(160f, Globals.fensterHoehe / 2 + Globals.fensterHoehe / 4 + Globals.fensterHoehe / 10 - 50);
            intro.Name = "intro";
            intro.SetColor(1.0f, 0.0f, 0.0f);
            intro.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //AddHUDObject(intro);

            HUDObjectText info = new HUDObjectText("INFO");
            info.SetPosition(420f, Globals.fensterHoehe / 2 + Globals.fensterHoehe / 4 + Globals.fensterHoehe / 10);
            info.Name = "info";
            info.SetColor(1.0f, 0.0f, 0.0f);
            info.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(info);
        }
        public string translateCode(string text)
        {
            switch (text)
            {
                case "1": return "1";
                case "2": return "2";
                case "3": return "3";
                case "4": return "4";
                case "5": return "5";
                case "6": return "6";
                case "7": return "7";
                case "8": return "8";
                case "9": return "9";
                case "10": return "0";
                case "11": return "A";
                case "12": return "B";
                case "13": return "C";
                case "14": return "D";
                case "15": return "E";
                case "16": return "F";
                case "17": return "G";
                case "18": return "H";
                case "19": return "I";
                case "20": return "J";
                case "21": return "K";
                case "22": return "L";
                case "23": return "M";
                case "24": return "N";
                case "25": return "O";
                case "26": return "P";
                case "27": return "Q";
                case "28": return "R";
                case "29": return "S";
                case "30": return "T";
                case "31": return "U";
                case "32": return "V";
                case "33": return "W";
                case "34": return "X";
                case "35": return "Y";
                case "36": return "Z";
                default: return text; // Falls keine Übereinstimmung gefunden wird, bleibt der Text unverändert.
            }
        }

    }
}