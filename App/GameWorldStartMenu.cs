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
            if (Keyboard.IsKeyPressed(Keys.W)) {
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
                  

            SetCameraPosition(Globals.moveCameraX, 4, Globals.moveCameraY);
            SetCameraTarget(CameraPosition.X, CameraPosition.Y + 2, CameraPosition.Z);

            do { SetCameraPosition(CameraPosition.X - 400, CameraPosition.Y, CameraPosition.Z); }
            while(CameraPosition.X > 130);         
            if(Globals.moveCameraMultiplier == 1) { Globals.moveCameraX += 0.02f; }
            if(Globals.moveCameraMultiplier == 2) { Globals.moveCameraX += 0.04f; }
            if(Globals.moveCameraMultiplier == 4) { Globals.moveCameraX += 0.08f; }
            if(Globals.moveCameraMultiplier == 0.5) { Globals.moveCameraX += 0.01f; }
            if(Globals.moveCameraMultiplier == 0.25) { Globals.moveCameraX += 0.005f; }

        }

        
        public override void Prepare()
        {
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
            
            bbg.Name = "background";
            bbg.SetScale(Window.Width, Window.Height);
            bbg.SetColor(0, 0, 0);
            bbg.CenterOnScreen();
            bbg.SetZIndex(-100);
            bbg.SetOpacity(0.75f);

            hSubtitle.SetPosition(500f, 100f);
            hSubtitle.Name = "a";
            hSubtitle.SetCharacterDistanceFactor(1.0f);
            hSubtitle.SetColor(1.0f, 0.0f, 0.0f);            
            
            hTitle.SetPosition(200f, 50f);
            hTitle.Name = "GameTitle";
            hTitle.SetCharacterDistanceFactor(1.0f);
            hTitle.SetColor(1.0f, 0.0f, 0.0f);
            hTitle.SetScale(80.0f);         

            Globals.posWert = 10;
            Globals.posYWert = 100;
            languageMenu.ChangeLanguage();

            displayClickableButtons();


            HUDObjectText sb = new HUDObjectText("SCORE BOARD");
            sb.SetPosition(750f, 200f);            
            sb.SetCharacterDistanceFactor(1.0f);
            sb.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s1 = new HUDObjectText("1#");
            s1.SetPosition(700f, 250f);
            s1.Name = "score1";
            s1.SetCharacterDistanceFactor(1.0f);
            s1.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s2 = new HUDObjectText("2#");
            s2.SetPosition(700f, 290f);
            s2.Name = "score2";
            s2.SetCharacterDistanceFactor(1.0f);
            s2.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s3 = new HUDObjectText("3#");
            s3.SetPosition(700f, 330f);
            s3.Name = "score3";
            s3.SetCharacterDistanceFactor(1.0f);
            s3.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s4 = new HUDObjectText("4#");
            s4.SetPosition(700f, 370f);
            s4.Name = "score4";
            s4.SetCharacterDistanceFactor(1.0f);
            s4.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s5 = new HUDObjectText("5#");
            s5.SetPosition(700f, 410f);
            s5.Name = "score5";
            s5.SetCharacterDistanceFactor(1.0f);
            s5.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s6 = new HUDObjectText("6#");
            s6.SetPosition(700f, 450f);
            s6.Name = "score6";
            s6.SetCharacterDistanceFactor(1.0f);
            s6.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s7 = new HUDObjectText("7#");
            s7.SetPosition(700f, 490f);
            s7.Name = "scpre7";
            s7.SetCharacterDistanceFactor(1.0f);
            s7.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s8 = new HUDObjectText("8#");
            s8.SetPosition(700f, 530f);
            s8.Name = "score8";
            s8.SetCharacterDistanceFactor(1.0f);
            s8.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s9 = new HUDObjectText("9#");
            s9.SetPosition(700f, 570f);
            s9.Name = "score9";
            s9.SetCharacterDistanceFactor(1.0f);
            s9.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s10 = new HUDObjectText("1O#");
            s10.SetPosition(678f, 610f);
            s10.Name = "score10";
            s10.SetCharacterDistanceFactor(1.0f);
            s10.SetColor(1.0f, 0.0f, 0.0f);


            Globals.scores[0] = Globals.Score;
            s1.SetText(s1.Text + " " + Globals.scores[0]);



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
            string content = File.ReadAllText(dateiPfad);

            if (string.IsNullOrWhiteSpace(content))
            {
                for(int i = 0; i < 10; i++)
                {
                    File.AppendAllText(dateiPfad, "0" + Environment.NewLine);
                }
            }

            string[] readText = File.ReadAllLines(dateiPfad);
            int[] allNumbers = new int[readText.Length] ;            
            for(int  i = 0; i < readText.Length; i++)
            {
                try
                { 
                    allNumbers[i] = Convert.ToInt32(readText[i]);
                }
                catch                 
                {
                    string path = @"./App/data/data.txt";
                    //path = @"C:\Users\Til.Stuckenberg\source\GAME\App\data\data.txt";
                    string appendText = Convert.ToString(Globals.Score) + "\n";
                    File.AppendAllText(path, appendText);
                }                
            }    
            
            Array.Sort(allNumbers);
            try
            {
                s1.SetText("1# " + Convert.ToString(allNumbers[allNumbers.Length - 1]));
                if (allNumbers[allNumbers.Length - 1] >= 2500)
                {
                    s1.SetColor(1.0f, 1.0f, 1.0f);
                }
                else if (allNumbers[allNumbers.Length-1] >= 1000)
                {
                    s1.SetColor(1.0f, 1.0f, 0.2f);
                }
                
            }
            catch
            {
                s1.SetText("1# 0" );
            }
            try { s2.SetText("2# " + Convert.ToString(allNumbers[allNumbers.Length - 2]));
            }
            catch { s2.SetText("2# 0"); }
            try { s3.SetText("3# " + Convert.ToString(allNumbers[allNumbers.Length - 3]));
            }
            catch { s3.SetText("3# 0"); }
            try { s4.SetText("4# " + Convert.ToString(allNumbers[allNumbers.Length - 4])); 
            }
            catch { s4.SetText("4# 0"); }
            try { s5.SetText("5# " + Convert.ToString(allNumbers[allNumbers.Length - 5])); 
            }
            catch {s5.SetText("5# 0"); }
            try { s6.SetText("6# " + Convert.ToString(allNumbers[allNumbers.Length - 6])); 
            }
            catch { s6.SetText("6# 0"); }
            try { s7.SetText("7# " + Convert.ToString(allNumbers[allNumbers.Length - 7])); 
            }
            catch { s7.SetText("7# 0"); }
            try { s8.SetText("8# " + Convert.ToString(allNumbers[allNumbers.Length - 8]));
            }
            catch { s8.SetText("8# 0"); }
            try { s9.SetText("9# " + Convert.ToString(allNumbers[allNumbers.Length - 9]));
            }
            catch { s9.SetText("9# 0"); }
            try { s10.SetText("10# " + Convert.ToString(allNumbers[allNumbers.Length - 10]));
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

    }
        
}

