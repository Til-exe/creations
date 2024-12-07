using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Linq;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Metrics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Xml.Linq;

namespace Gruppenprojekt.App
{
    public class GameWorldStartMenu : World
    {
        public override void Act()
        {
            HUDObjectText start = GetHUDObjectTextByName("start");
            HUDObjectText option = GetHUDObjectTextByName("option");
            HUDObjectText leave = GetHUDObjectTextByName("leave");
            HUDObjectText credits = GetHUDObjectTextByName("credits");
            HUDObjectText language = GetHUDObjectTextByName("language");
            HUDObjectText AdminSB = GetHUDObjectTextByName("AdminSB");
            HUDObjectImage bg = GetHUDObjectImageByName("./App/Textures/MenuHintergrund.jpg");

            if (start != null)
            {
                if (start.IsMouseCursorOnMe() == true)
                {
                    start.SetColor(1, 1, 1);
                    start.SetColorEmissiveIntensity(0.5f);
                }
                else
                {
                    start.SetColor(1, 0, 0);
                    start.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && start.IsMouseCursorOnMe() == true)
                {
                    GameWorldStart gws = new GameWorldStart();
                    Window.SetWorld(gws);
                    Globals.Score = 0;
                }
            }
            if (option != null)
            {
                if (option.IsMouseCursorOnMe() == true)
                {
                    option.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    option.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && option.IsMouseCursorOnMe() == true)
                {
                    GwStartMenuOption GwSmOption = new GwStartMenuOption();
                    Window.SetWorld(GwSmOption);
                }
            }
            if (leave != null)
            {
                if (leave.IsMouseCursorOnMe() == true)
                {
                    leave.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    leave.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && leave.IsMouseCursorOnMe() == true)
                {
                    Window.Close();
                }
            }
            if (credits != null)
            {
                if (credits.IsMouseCursorOnMe() == true)
                {
                    credits.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    credits.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && credits.IsMouseCursorOnMe() == true)
                {
                    CreditsMenu creditsMenu = new CreditsMenu();
                    Window.SetWorld(creditsMenu);
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
                    languageMenu languageMenu = new languageMenu();
                    Window.SetWorld(languageMenu);
                }
            }
            if (AdminSB != null)
            {
                if (AdminSB.IsMouseCursorOnMe() == true)
                {
                    AdminSB.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    AdminSB.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && AdminSB.IsMouseCursorOnMe() == true)
                {
                    scoreboardMenu scoreboardMenu = new scoreboardMenu();
                    Window.SetWorld(scoreboardMenu);
                }
            }

            if (Keyboard.IsKeyPressed(Keys.W))
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
            }                   //Display all Sections Button
            if (Keyboard.IsKeyPressed(Keys.Enter))
            {
                GameWorldStart gws = new GameWorldStart();
                Window.SetWorld(gws);
                Globals.Score = 0;
            }               //Start Button
            SetCameraPosition(Globals.moveCameraX, 4, Globals.moveCameraY);
            SetCameraTarget(CameraPosition.X, CameraPosition.Y + 2, CameraPosition.Z);

            do { SetCameraPosition(CameraPosition.X - 400, CameraPosition.Y, CameraPosition.Z); }
            while (CameraPosition.X > 130);
            if (Globals.moveCameraMultiplier == 1) { Globals.moveCameraX += 0.02f; }
            if (Globals.moveCameraMultiplier == 2) { Globals.moveCameraX += 0.04f; }
            if (Globals.moveCameraMultiplier == 4) { Globals.moveCameraX += 0.08f; }
            if (Globals.moveCameraMultiplier == 0.5) { Globals.moveCameraX += 0.01f; }
            if (Globals.moveCameraMultiplier == 0.25) { Globals.moveCameraX += 0.005f; }
        }                
        public override void Prepare()
        {
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

            w1.SetTexture("./app/Textures/wood1.png");
            w1.SetTextureRepeat(500f, 5f);
            w1.SetScale(1000,10,1);

            w2.SetTexture("./app/Textures/wood1.png");
            w2.SetTextureRepeat(500f, 5f);
            w2.SetScale(1000,10,1);
            
            f.SetTexture("./app/Textures/wood1.png");
            f.SetTextureRepeat(500f, 5f);
            f.SetScale(1000,1,10);
            
            f1.SetTexture("./app/Textures/wood1.png");
            f1.SetTextureRepeat(500f, 5f);
            f1.SetScale(1000,1,10);            
            
            light.Name = ("scheiß auf den Namen");
            light.SetNearFar(10000f, 2500f);
            light.SetPosition(1f, 1f, 1);
            
            bbg.SetScale(Window.Width, Window.Height);
            bbg.SetColor(0, 0, 0);
            bbg.CenterOnScreen();
            bbg.SetZIndex(-100);
            bbg.SetOpacity(0.75f);

            int fb = Globals.fensterBreite;
            int fh = Globals.fensterHoehe;

            hSubtitle.SetPosition(fb/2, 100f);
            hSubtitle.SetTextAlignment(TextAlignMode.Center);
            hSubtitle.SetColor(1.0f, 0.0f, 0.0f);

            hTitle.SetPosition(fb/2, 50f);
            hTitle.SetTextAlignment(TextAlignMode.Center);
            hTitle.SetColor(1.0f, 0.0f, 0.0f);
            hTitle.SetScale(80.0f);         

            Globals.posWert = 10;
            Globals.posYWert = 100;

            languageMenu.ChangeLanguage();
            displayClickableButtons();

            HUDObjectText sb = new HUDObjectText(Globals.ActualScoreboardText);
            sb.SetPosition(fb/2 + fb/6, 200f);     
            sb.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s1 = new HUDObjectText("1#");
            s1.SetPosition(fb / 2 + fb / 6, 250f);
            s1.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s2 = new HUDObjectText("2#");
            s2.SetPosition(fb / 2 + fb / 6, 290f);
            s2.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s3 = new HUDObjectText("3#");
            s3.SetPosition(fb / 2 + fb / 6, 330f);
            s3.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s4 = new HUDObjectText("4#");
            s4.SetPosition(fb / 2 + fb / 6, 370f);
            s4.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s5 = new HUDObjectText("5#");
            s5.SetPosition(fb / 2 + fb / 6, 410f);
            s5.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s6 = new HUDObjectText("6#");
            s6.SetPosition(fb / 2 + fb / 6, 450f);
            s6.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s7 = new HUDObjectText("7#");
            s7.SetPosition(fb / 2 + fb / 6, 490f);
            s7.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s8 = new HUDObjectText("8#");
            s8.SetPosition(fb / 2 + fb / 6, 530f);
            s8.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s9 = new HUDObjectText("9#");
            s9.SetPosition(fb / 2 + fb / 6, 570f);
            s9.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s10 = new HUDObjectText("1O#");
            s10.SetPosition(fb / 2 + fb /6 - 23, 610f);
            s10.SetColor(1.0f, 0.0f, 0.0f);

            AddLightObject(light);
            AddGameObject(c1);
            AddGameObject(w1);
            AddGameObject(w2);
            AddGameObject(f);
            AddGameObject(f1);
            AddHUDObject(bbg);
            AddHUDObject(hSubtitle);
            AddHUDObject(hTitle);
            AddHUDObject(sb);

            AddHUDObject(s1);
            AddHUDObject(s2);
            AddHUDObject(s3);
            AddHUDObject(s3);
            AddHUDObject(s4);
            AddHUDObject(s5);
            AddHUDObject(s6);
            AddHUDObject(s7);
            AddHUDObject(s8);
            AddHUDObject(s9);
            AddHUDObject(s10);


            SetCameraPosition(0.0f, 5.0f, 15.0f);
            
            string dateiPfad = @"./App/data/data.txt";
            string timePfad = @"./App/data/time.txt";  
            
            double[] doubleWerte = File.ReadAllLines(timePfad)
                    .Select(line => double.Parse(line))
                    .ToArray();
            int[] intWerte = doubleWerte.Select(d => (int)d).ToArray();

            string[] readTime = intWerte.Select(i => i.ToString()).ToArray();
            string[] readScores = File.Exists(dateiPfad)  ? File.ReadAllLines(dateiPfad) : new string[0];

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
                    Console.WriteLine($"Ungültiger Wert in {dateiPfad}: '{readScores[i]}' wird ignoriert.");
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
                    Console.WriteLine($"Ungültiger Wert in {timePfad}: '{readTime[i]}' wird ignoriert.");
                }
            }
            
            List<Result> res = new List<Result>();
            for (int i = 0; i < allNumbers.Length; i++)
            {
                int time = i < allTime.Length ? allTime[i] : 0; // Falls Zeit fehlt, Standardwert 0
                res.Add(new Result() { Score = allNumbers[i], Time = time });
            }

            // Sortieren nach Score
            res.Sort((a, b) => a.Score.CompareTo(b.Score));

            try { s1.SetText(displayValues(1, res));                
            }
            catch{//                                                                                                                                                                                                                                                                                    Ich hab hier drin gearbeitet und nun hat mir Pia erzählt das als ich vor ein paar monaten eine Freundin von ihr geil fand, sie ja nur nichts gemacht hat weil ich ihr bruder bin und wäre sie mit mir alleien gewesen sie nichts hätte garantieren können :O              
                s1.SetText("1# 0" );
            }
            try { s2.SetText(displayValues(2,res));
                //                                                                                                                                                                                                                              Ich hab hier drin gearbeitet und nun hat mir Pia erzählt das als ich vor ein paar monaten eine Freundin von ihr geil fand, sie ja nur nichts gemacht hat weil ich ihr bruder bin und wäre sie mit mir alleien gewesen sie nichts hätte garantieren können :O              
            }
            catch { s2.SetText("2# 0"); }
            try { s3.SetText(displayValues(3, res));
            } 
            catch { s3.SetText("3# 0"); }
            try { s4.SetText(displayValues(4, res));
            }                                                    
            catch { s4.SetText("4# 0"); }                        
            try { s5.SetText(displayValues(5, res));
            }                                                    
            catch {s5.SetText("5# 0"); }                         
            try { s6.SetText(displayValues(6, res));
            }                                                    
            catch { s6.SetText("6# 0"); }                        
            try { s7.SetText(displayValues(7, res));
            }                                                    
            catch { s7.SetText("7# 0"); }                        
            try { s8.SetText(displayValues(8, res));
            }                                                    
            catch { s8.SetText("8# 0"); }                        
            try { s9.SetText(displayValues(9, res));
            }
            catch { s9.SetText("9# 0"); }
            try { s10.SetText(displayValues(10, res));
            }
            catch { s10.SetText("10# 0"); }
        }       
        public void displayClickableButtons()
        {
            
            HUDObjectText start = new HUDObjectText(Globals.StartButtonText);
            HUDObjectText option = new HUDObjectText(Globals.OptionButtonText);
            HUDObjectText language = new HUDObjectText(Globals.LanguageButtonText);
            HUDObjectText credits = new HUDObjectText(Globals.CreditsButtonText);
            HUDObjectText AdminSB = new HUDObjectText(Globals.ScoreboardButtonText);
            HUDObjectText leave = new HUDObjectText(Globals.LeaveButtonText);

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
            if (Globals.DisplayLeaveButton) { AddHUDObject(leave); }

            
        }
        public static string leerstellen(int i)
        {
            string lS;

            if (i >= 10000)
            {
                lS = "\t";
            }
            else if (i >= 1000)
            {
                lS = "\t\t\t";
            }
            else if (i >= 100)
            {
                lS = "\t\t\t\t";
            }
            else if (i >= 10)
            {
                lS = "\t\t\t\t\t";
            }            
            else
            {
                lS = "\t\t\t\t\t\t";
            }
            return lS;
        }
        public static string displayValues(int i, List<Result> results)
        {
        string x;
            x = i + "# " + Convert.ToString(results[results.Count - i].Score + leerstellen(results[results.Count - i].Score) + results[results.Count - i].Time + "s");
            return x;
        }
    }
}