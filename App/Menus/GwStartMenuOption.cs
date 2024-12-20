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
            HUDObjectText EnableLevel = GetHUDObjectTextByName("EnableLevel");
            HUDObjectText gamemode = GetHUDObjectTextByName("gamemode");
            HUDObjectText shop = GetHUDObjectTextByName("shop");
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
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click1.wav", false, 0.2f);
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
                    if (value1 == 1 && 
                        value2 == 1 && 
                        value3 == 1 && 
                        codeEnterd)
                    { 
                        code.SetText("CODE AKTIVIERT"); codeEnterd = false;
                    }                       
                    Globals.ReturnCode = 1;
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
            if (EnableLevel != null)
            {
                if (EnableLevel.IsMouseCursorOnMe() == true)
                {
                    EnableLevel.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    EnableLevel.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && EnableLevel.IsMouseCursorOnMe() == true)
                {

                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    if (Globals.DisplayLevelButton)
                    {
                        EnableLevel.SetText("LEVEL: " + Globals.disabledText);

                    }
                    else
                    {
                        EnableLevel.SetText("LEVEL: " + Globals.enabledText);

                    }
                    Globals.DisplayLevelButton = !Globals.DisplayLevelButton;
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
                    choseGamemode cGm = new choseGamemode();
                    Window.SetWorld(cGm);
                }
            }
            if (shop != null)
            {
                if (shop.IsMouseCursorOnMe() == true)
                {
                    shop.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    shop.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && shop.IsMouseCursorOnMe() == true)
                {
                    shopMenu shopmenu = new shopMenu();
                    Window.SetWorld(shopmenu);
                }
            }
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
                    AdminMenu adminM= new AdminMenu();
                    Window.SetWorld(adminM);
                }
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
                    languageMenu languageM = new languageMenu();
                    Window.SetWorld(languageM);
                }
            }

            string text1 = transelateCode(Convert.ToString(value1));
            string text2 = transelateCode(Convert.ToString(value2));
            string text3 = transelateCode(Convert.ToString(value3));
            if (value1 == 37) { value1 = 0; }
            if (value2 == 37) { value2 = 0; }
            if (value3 == 37) { value3 = 0; }
            score1.SetText("| " + text1 + " |", true);  //update shown Value
            score2.SetText("| " + text2 + " |", true);  //update shown Value
            score3.SetText("| " + text3 + " |", true);  //update shown Value
        }
        public override void Prepare()
        {

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
            AddHUDObject(credits);

            HUDObjectText language = new HUDObjectText("LANGUAGE:");
            language.SetPosition(700f, 250f);
            language.Name = "EnableLanguage";
            language.SetColor(1.0f, 0.0f, 0.0f);
            language.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(language);

            HUDObjectText scoreboard = new HUDObjectText("ADMIN:");
            scoreboard.SetPosition(700f, 300f);
            scoreboard.Name = "EnableScoreboard";
            scoreboard.SetColor(1.0f, 0.0f, 0.0f);
            scoreboard.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(scoreboard);

            HUDObjectText levelB = new HUDObjectText("LEVEL:");
            levelB.SetPosition(700f, 350f);
            levelB.Name = "EnableLevel";
            levelB.SetColor(1.0f, 0.0f, 0.0f);
            levelB.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(levelB);

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


            if (Globals.DisplayLevelButton == false)
            {
                levelB.SetText("LEVEL: " + Globals.disabledText);
            }
            else
            {
                levelB.SetText("LEVEL: " + Globals.enabledText);
                Globals.DisplayLevelButton = true;
            }

            HUDObjectText Enter = new HUDObjectText("ENTER CODE");
            Enter.SetPosition(160f, 200f);
            Enter.Name = "Enter";
            Enter.SetColor(1.0f, 0.0f, 0.0f);
            Enter.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Enter);

            HUDObjectText Reset = new HUDObjectText("RESET");
            Reset.SetPosition(460f, 200f);
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

            HUDObjectText shop = new HUDObjectText("SHOP");
            shop.SetPosition(420f, Globals.fensterHoehe / 2 + Globals.fensterHoehe / 4 + Globals.fensterHoehe / 10);
            shop.Name = "shop";
            shop.SetColor(1.0f, 0.0f, 0.0f);
            shop.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(shop);
        }
        public string transelateCode(string text)
        {
            if (text == "1") { text = "1"; }
            if (text == "2") { text = "2"; }
            if (text == "3") { text = "3"; }
            if (text == "4") { text = "4"; }
            if (text == "5") { text = "5"; }
            if (text == "6") { text = "6"; }
            if (text == "7") { text = "7"; }
            if (text == "8") { text = "8"; }
            if (text == "9") { text = "9"; }
            if (text == "10") { text = "0"; }

            if (text == "11") { text = "A"; }
            if (text == "12") { text = "B"; }
            if (text == "13") { text = "C"; }
            if (text == "14") { text = "D"; }
            if (text == "15") { text = "E"; }
            if (text == "16") { text = "F"; }
            if (text == "17") { text = "G"; }
            if (text == "18") { text = "H"; }
            if (text == "19") { text = "I"; }
            if (text == "20") { text = "J"; }
            if (text == "21") { text = "K"; }
            if (text == "22") { text = "L"; }
            if (text == "23") { text = "M"; }
            if (text == "24") { text = "N"; }
            if (text == "25") { text = "O"; }
            if (text == "26") { text = "P"; }
            if (text == "27") { text = "Q"; }
            if (text == "28") { text = "R"; }
            if (text == "29") { text = "S"; }
            if (text == "30") { text = "T"; }
            if (text == "31") { text = "U"; }
            if (text == "32") { text = "V"; }
            if (text == "33") { text = "W"; }
            if (text == "34") { text = "X"; }
            if (text == "35") { text = "Y"; }
            if (text == "36") { text = "Z"; }
            return text;
        }
    }
}