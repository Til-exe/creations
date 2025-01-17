using System.Security.Cryptography.X509Certificates;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Common.Input;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Gruppenprojekt.App.Classes;
using KWEngine3.GameObjects;
using OpenTK.Mathematics;
using System.Xml.Linq;
using KWEngine3.Audio;
using System.Linq;
using System.IO;
using KWEngine3;
using System;
using Assimp;
namespace Gruppenprojekt.App.Menus
{
    public class GameWorldStartMenu : World
    {
        bool startbool = false;
        float counter = 0.7f;
        private float timestampLastWalkSound = 0;
        bool isAPressed = false;
        bool isDPressed = false;
        bool isMPressed = false;
        bool isIressed = false;
        bool startsound = true;
        public override void Act()
        {            
            HUDObjectText start = GetHUDObjectTextByName("start");
            HUDObjectText option = GetHUDObjectTextByName("option");
            HUDObjectText leave = GetHUDObjectTextByName("leave");
            HUDObjectText credits = GetHUDObjectTextByName("credits");
            HUDObjectText language = GetHUDObjectTextByName("language");
            HUDObjectText AdminSB = GetHUDObjectTextByName("AdminSB");
            HUDObjectText LevelB = GetHUDObjectTextByName("LevelB");
            HUDObjectImage bbg = GetHUDObjectImageByName("bbg");
            HUDObjectText LevelScore = GetHUDObjectTextByName("LevelScore");
            HUDObjectText LevelNum = GetHUDObjectTextByName("LevelNum");
            if (startbool) {
                bbg.SetZIndex(0);
                if (counter != -1f) {
                    counter += 0.0005f;
                    if(counter > 0.75) {                        
                        bbg.SetOpacity(counter);                        
                    }
                }
                if(counter >= 1f) {                    
                    startGame();                    
                }                
            }
            else
            { if (Globals.bgAnimation) { bbg.SetOpacity(0.75f); } else { bbg.SetOpacity(1f); } }
            if(startsound) {
                Audio.StopAllSound();
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/ScaryMenuMusic1.wav", false, 0.1f);
                startsound = false;            
            }
            if (WorldTime - timestampLastWalkSound > 36f) {
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/ScaryMenuMusic1.wav", false, 0.1f);
                timestampLastWalkSound = WorldTime;
            }
            if (start != null)
            {
                if (start.IsMouseCursorOnMe() == true && !startbool)
                {
                    start.SetColor(1, 1, 1);
                    start.SetColorEmissiveIntensity(0.5f);
                }
                else
                {
                    start.SetColor(1, 0, 0);
                    start.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && start.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    startbool = true;
                }
            }
            if (option != null)
            {
                if (option.IsMouseCursorOnMe() == true && !startbool)
                {
                    option.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    option.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && option.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    GwStartMenuOption GwSmOption = new GwStartMenuOption();
                    Window.SetWorld(GwSmOption);
                }
            }
            if (leave != null)
            {
                if (leave.IsMouseCursorOnMe() == true && !startbool)
                {
                    leave.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    leave.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && leave.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    Window.Close();
                }
            }
            if (credits != null)
            {
                if (credits.IsMouseCursorOnMe() == true && !startbool)
                {
                    credits.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    credits.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && credits.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    CreditsMenu creditsMenu = new CreditsMenu();
                    Window.SetWorld(creditsMenu);
                }
            }
            if (language != null)
            {
                if (language.IsMouseCursorOnMe() == true && !startbool)
                {
                    language.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    language.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && language.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    languageMenu languageMenu = new languageMenu();
                    Window.SetWorld(languageMenu);
                }
            }
            if (AdminSB != null)
            {
                if (AdminSB.IsMouseCursorOnMe() == true && !startbool)
                {
                    AdminSB.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    AdminSB.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && AdminSB.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    AdminMenu scoreboardMenu = new AdminMenu();
                    Window.SetWorld(scoreboardMenu);
                }
            }
            if (LevelB != null)
            {
                if (LevelB.IsMouseCursorOnMe() == true && !startbool)
                {
                    LevelB.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    LevelB.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && LevelB.IsMouseCursorOnMe() == true && !startbool)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    LevelMenu levelMenu = new LevelMenu();  
                    Window.SetWorld(levelMenu);
                }
            }

            if (Keyboard.IsKeyPressed(Keys.A) || isAPressed)
            {
                isAPressed = true;

                if (Keyboard.IsKeyPressed(Keys.D) || isDPressed)
                {
                    isDPressed = true;

                    if (Keyboard.IsKeyPressed(Keys.M) || isMPressed)
                    {
                        isMPressed = true;

                        if (Keyboard.IsKeyPressed(Keys.I) || isIressed)
                        {
                            isIressed = true;

                            if (Keyboard.IsKeyPressed(Keys.N))
                            {
                                Globals.DisplayStartGameButton = true;
                                Globals.DisplayOptionButton = true;
                                Globals.DisplayLanguageButton = true;
                                Globals.DisplayCreditsButton = true;
                                Globals.DisplayScoreboardButton = true;
                                Globals.DisplayLeaveButton = true;
                                RemoveHUDObject(start);
                                RemoveHUDObject(option);
                                RemoveHUDObject(leave);
                                RemoveHUDObject(credits);
                                RemoveHUDObject(language);
                                RemoveHUDObject(AdminSB);
                                Globals.posWert = 10;
                                displayClickableButtons();
                            }
                        }
                    }
                }
            }

            if (Keyboard.IsKeyPressed(Keys.Enter))
            {
                startGame();
            }                            
            SetCameraPosition(Globals.moveCameraX, 4, Globals.moveCameraY);
            SetCameraTarget(CameraPosition.X, CameraPosition.Y + 2, CameraPosition.Z);
            do { SetCameraPosition(CameraPosition.X - 400, CameraPosition.Y, CameraPosition.Z); }
            while (CameraPosition.X > 130);
            if (Globals.moveCameraMultiplier == 1) { Globals.moveCameraX += 0.02f; }
            if (Globals.moveCameraMultiplier == 2) { Globals.moveCameraX += 0.04f; }
            if (Globals.moveCameraMultiplier == 4) { Globals.moveCameraX += 0.08f; }
            if (Globals.moveCameraMultiplier == 0.5) { Globals.moveCameraX += 0.01f; }
            if (Globals.moveCameraMultiplier == 0.25) { Globals.moveCameraX += 0.005f; }
            if (Globals.Experience > 10) { Globals.Experience = 0; Globals.Level++; }
            if (Globals.Level == 6)
            {
                LevelNum.SetText("level #MAX");
                LevelNum.SetColor(0.855f, 0.647f, 0.125f);
                LevelScore.SetColor(0.855f, 0.647f, 0.125f); 
                LevelScore.SetText("|||||||||||");
            }
            else if (Globals.Level <= 5 && Globals.TutorialComplete)
            {
                LevelNum.SetText("level #" + Globals.Level);
                LevelScore.SetText(ErstellePunktestand(Globals.Experience, 11));
            }            
        }
        public override void Prepare()
        {
            Console.WriteLine("[CONSOLE] World: GameWorldStartMenu");
            //KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/ScaryMenuMusic1.wav", false, 0.5f);
            Globals.gameRunning = true;
            Wall w1 = new Wall("1", 0f, 4f, 5f);
            Wall w2 = new Wall("2", 0f, 4f, 0f);
            Floor f = new Floor("floor", 1f, 1f, 1f);
            Floor f1 = new Floor("floor", 1f, 10f, 1f);            
            LightObject light = new LightObject(LightType.Sun, ShadowQuality.Low);
            Collectable c1 = new Collectable("1", 100f, 2.5f, 2.5f);                      
            HUDObjectImage bbg = new HUDObjectImage("./App/Textures/blackscreen.png");
            HUDObjectText hSubtitle = new HUDObjectText("By PLUG-INC");
            HUDObjectText hTitle = new HUDObjectText("ITS STOLEN");
            Globals.posWert = 10;
            Globals.posYWert = 100;           
            w1.SetTexture("./app/Textures/wood1.png");
            w1.SetTextureRepeat(500f, 5f);
            w1.SetScale(1000, 10, 1);
            w2.SetTexture("./app/Textures/wood1.png");
            w2.SetTextureRepeat(500f, 5f);
            w2.SetScale(1000, 10, 1);
            f.SetTexture("./app/Textures/wood1.png");
            f.SetTextureRepeat(500f, 5f);
            f.SetScale(1000, 1, 10);
            f1.SetTexture("./app/Textures/wood1.png");
            f1.SetTextureRepeat(500f, 5f);
            f1.SetScale(1000, 1, 10);
            light.Name = "light";
            light.SetNearFar(10000f, 2500f);
            light.SetPosition(1f, 1f, 1);           
            bbg.SetScale(Globals.fensterBreite, Globals.fensterHoehe);
            bbg.Name = "bbg";
            bbg.SetColor(0, 0, 0);
            bbg.CenterOnScreen();
            bbg.SetZIndex(-100);
            bbg.SetOpacity(0.75f);
            hSubtitle.SetPosition(Globals.fensterBreite / 2, 100f);
            hSubtitle.SetTextAlignment(TextAlignMode.Center);
            hSubtitle.SetColor(1.0f, 0.0f, 0.0f);
            hTitle.SetPosition(Globals.fensterBreite / 2, 50f);
            hTitle.SetTextAlignment(TextAlignMode.Center);
            hTitle.SetColor(1.0f, 0.0f, 0.0f);
            hTitle.SetScale(80.0f);
            languageMenu.ChangeLanguage();
            displayClickableButtons();
            HUDObjectText sb = new HUDObjectText(Globals.ActualScoreboardText);
            sb.SetPosition(Globals.fensterBreite / 2 + Globals.fensterBreite / 6, 200f);
            sb.SetColor(1.0f, 0.0f, 0.0f);
            int posSX = 250;
            int pusSY = 0;
            List<HUDObjectText> scoreboardIndex = new List<HUDObjectText>();
            for(int i = 0; i < 10; i++) {
                if (i == 9) {
                    pusSY = 23;}
                HUDObjectText s = new HUDObjectText(i + "#");                   
                s.SetPosition(Globals.fensterBreite / 2 + Globals.fensterBreite / 6 - pusSY, posSX);
                s.SetColor(1.0f, 0.0f, 0.0f);
                posSX += 40;
                scoreboardIndex.Add(s);
            }
            if(Globals.TutorialComplete) 
            {
                AddHUDObject(sb);
                for (int i = 0; i < 10; i++)
                {
                    AddHUDObject(scoreboardIndex[i]);
                }
            }
            AddLightObject(light);
            AddGameObject(c1);
            AddGameObject(w1);
            AddGameObject(w2);
            AddGameObject(f);
            AddGameObject(f1);
            AddHUDObject(bbg);
            AddHUDObject(hSubtitle);
            AddHUDObject(hTitle);
            SetCameraPosition(0.0f, 5.0f, 15.0f);
            double[] doubleWerte = File.ReadAllLines(Globals.timePath)
                    .Select(line => double.Parse(line))
                    .ToArray();
            int[] intWerte = doubleWerte.Select(d => (int)d).ToArray();
            string[] readTime = intWerte.Select(i => i.ToString()).ToArray();
            string[] readScores = File.Exists(Globals.path) ? File.ReadAllLines(Globals.path) : new string[0];
            int[] allNumbers = new int[readScores.Length];
            int[] allTime = new int[readTime.Length];
            for (int i = 0; i < readScores.Length; i++)
            {
                if (int.TryParse(readScores[i], out int number))
                {
                    allNumbers[i] = number;
                }
                else
                {
                    Console.WriteLine($"Ungültiger Wert in {Globals.path}: '{readScores[i]}' wird ignoriert.");
                }
            }
            for (int i = 0; i < readTime.Length; i++)
            {
                if (int.TryParse(readTime[i], out int time))
                {
                    allTime[i] = time;
                }
                else
                {
                    Console.WriteLine($"Ungültiger Wert in {Globals.timePath}: '{readTime[i]}' wird ignoriert.");
                }
            }
            List<Result> res = new List<Result>();
            for (int i = 0; i < allNumbers.Length; i++)
            {
                int time = i < allTime.Length ? allTime[i] : 0; // Falls Zeit fehlt, Standardwert 0
                res.Add(new Result() { Score = allNumbers[i], Time = time });
            }
            res.Sort((a, b) => a.Score.CompareTo(b.Score));
            for (int i = 0; i < 10; i++) {
                try { scoreboardIndex[i].SetText(displayValues(i + 1, res)); }                
                catch { scoreboardIndex[i].SetText(i + 1 + "# 0"); }                
            }
        }
        public void displayClickableButtons()
        {
            if(Globals.TutorialComplete) { Globals.StartButtonText = "Start"; }  else { Globals.StartButtonText = "Tutorial"; }
            HUDObjectText start = new HUDObjectText(Globals.StartButtonText);
            HUDObjectText option = new HUDObjectText(Globals.OptionButtonText);
            HUDObjectText language = new HUDObjectText(Globals.LanguageButtonText);
            HUDObjectText credits = new HUDObjectText(Globals.CreditsButtonText);
            HUDObjectText AdminSB = new HUDObjectText(Globals.ScoreboardButtonText);
            HUDObjectText LevelB = new HUDObjectText(Globals.LevelButtonText);
            HUDObjectText leave = new HUDObjectText(Globals.LeaveButtonText);
            HUDObjectText LevelNum = new HUDObjectText("level #" + (Globals.Level) + "");
            HUDObjectText LevelScore = new HUDObjectText(Globals.Experience + "/10");
            LevelNum.SetPosition(10, Globals.fensterHoehe - 100);
            LevelNum.SetColor(1.0f, 0.0f, 0.0f);
            LevelNum.Name = "LevelNum";
            LevelScore.SetPosition(10, Globals.fensterHoehe - 50);
            LevelScore.SetColor(1.0f, 0.0f, 0.0f);
            LevelScore.Name = "LevelScore";
            if (Globals.Level >= 5 && Globals.Experience >= 10)
            {
                LevelNum.SetText("level #MAX");
                LevelNum.SetColor(0.855f, 0.647f, 0.125f);
                LevelScore.SetColor(0.855f, 0.647f, 0.125f);
                LevelScore.SetText(ErstellePunktestand(Globals.Experience, 11));
            }
            else if (Globals.Level <= 5 && Globals.TutorialComplete)
            {
                LevelNum.SetText("level #" + Globals.Level);
                LevelScore.SetText(ErstellePunktestand(Globals.Experience, 11));
            }
            start.SetPosition(Globals.posYWert, 200f);
            start.Name = "start";
            start.SetCharacterDistanceFactor(1.0f);
            start.SetColor(1.0f, 0.0f, 0.0f);
            start.SetColorEmissive(1.0f, 1.0f, 1.0f);
            start.SetScale(50.0f);
            if (Globals.DisplayStartGameButton) { Globals.posWert += 50; }
            option.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            option.Name = "option";
            option.SetCharacterDistanceFactor(1.0f);
            option.SetColor(1.0f, 0.0f, 0.0f);
            option.SetColorEmissive(1.0f, 1.0f, 1.0f);
            if (Globals.DisplayOptionButton) { Globals.posWert += 50; }
            language.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            language.Name = "language";
            language.SetCharacterDistanceFactor(1.0f);
            language.SetColor(1.0f, 0.0f, 0.0f);
            language.SetColorEmissive(1.0f, 1.0f, 1.0f);
            if (Globals.DisplayLanguageButton) { Globals.posWert += 50; }
            credits.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            credits.Name = "credits";
            credits.SetCharacterDistanceFactor(1.0f);
            credits.SetColor(1.0f, 0.0f, 0.0f);
            credits.SetColorEmissive(1.0f, 1.0f, 1.0f);
            if (Globals.DisplayCreditsButton) { Globals.posWert += 50; }
            AdminSB.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            AdminSB.Name = "AdminSB";
            AdminSB.SetCharacterDistanceFactor(1.0f);
            AdminSB.SetColor(1.0f, 0.0f, 0.0f);
            AdminSB.SetColorEmissive(1.0f, 1.0f, 1.0f);
            if (Globals.DisplayScoreboardButton) { Globals.posWert += 50; }
            LevelB.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            LevelB.Name = "LevelB";
            LevelB.SetCharacterDistanceFactor(1.0f);
            LevelB.SetColor(1.0f, 0.0f, 0.0f);
            LevelB.SetColorEmissive(1.0f, 1.0f, 1.0f);
            if (Globals.DisplayLevelButton) { Globals.posWert += 50; }
            leave.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            leave.Name = "leave";
            leave.SetCharacterDistanceFactor(1.0f);
            leave.SetColor(1.0f, 0.0f, 0.0f);
            leave.SetColorEmissive(1.0f, 1.0f, 1.0f);
            if (Globals.DisplayStartGameButton) { AddHUDObject(start); }
            if (Globals.DisplayOptionButton) { AddHUDObject(option); }
            if (Globals.DisplayLanguageButton) { AddHUDObject(language); }
            if (Globals.DisplayCreditsButton) { AddHUDObject(credits); }
            if (Globals.DisplayScoreboardButton) { AddHUDObject(AdminSB); }
            if (Globals.DisplayLevelButton) { 
                AddHUDObject(LevelB);
            }
            if(Globals.TutorialComplete) {
                AddHUDObject(LevelNum);
                AddHUDObject(LevelScore);
            }
            if (Globals.DisplayLeaveButton) { AddHUDObject(leave); }
        }
        public static string leerstellen(int i)
        {
            int length = i.ToString().Length;
            int tabs = 6 - length;
            return new string('\t', tabs);
        }
        public static string displayValues(int i, List<Result> results)
        {
            return i + "# " + results[results.Count - i].Score + leerstellen(results[results.Count - i].Score) + results[results.Count - i].Time + "s";
        }
        public static void functionBackButton(HUDObject leave)
        {
            if (leave == null) return;
            leave.SetColorEmissiveIntensity(leave.IsMouseCursorOnMe() ? 1.5f : 0.0f);
            if (leave.IsMouseCursorOnMe() && Mouse.IsButtonPressed(MouseButton.Left))
            {
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                var startMenu = new GwStartMenuOption();
                Window.SetWorld(startMenu);
            }
        }
        public static void startGame()
        {
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 0.2f);
            if (Globals.choseGamemode == "Tutorial") {
                GameWorldTutorial gwt = new GameWorldTutorial();
                Window.SetWorld(gwt);}
            else {
                GameWorldStart gws = new GameWorldStart();
                Window.SetWorld(gws);
                Globals.Score = 0;
            }
        }
        public static string ErstellePunktestand(int punkte, int maxPunkte)
        {
            try {
                string punkteTeil = new string('|', punkte);
                string leerTeil = new string('-', maxPunkte - punkte);
                return punkteTeil + (leerTeil);
            }
            catch
            {
                return "";
            }
        }
    }
}