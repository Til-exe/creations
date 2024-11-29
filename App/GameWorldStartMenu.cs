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
        int l = 0;
        public override void Act()
        {            
            HUDObjectText h1 = GetHUDObjectTextByName("MyHUDObject1");
            HUDObjectText h2 = GetHUDObjectTextByName("MyHUDObject2");
            HUDObjectText h3 = GetHUDObjectTextByName("MyHUDObject3");
            HUDObjectText credits = GetHUDObjectTextByName("credits");
            HUDObjectText s1 = GetHUDObjectTextByName("score1");
            HUDObjectText s2 = GetHUDObjectTextByName("score2");
            HUDObjectText s3 = GetHUDObjectTextByName("score3");
            HUDObjectText s4 = GetHUDObjectTextByName("score4");
            HUDObjectText s5 = GetHUDObjectTextByName("score5");
            HUDObjectText s6 = GetHUDObjectTextByName("score6");
            HUDObjectText s7 = GetHUDObjectTextByName("score7");
            HUDObjectText s8 = GetHUDObjectTextByName("score8");
            HUDObjectText s9 = GetHUDObjectTextByName("score9");
            HUDObjectText s10 = GetHUDObjectTextByName("score10");
            HUDObjectImage bg = GetHUDObjectImageByName("./App/Textures/MenuHintergrund.jpg");
            //penisTest
            if (h1 != null)
            {
                if (h1.IsMouseCursorOnMe() == true)
                {
                    h1.SetColor(1, 1, 1);
                    h1.SetColorEmissiveIntensity(0.5f);
                }
                else
                {
                    h1.SetColor(1, 0, 0);
                    h1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && h1.IsMouseCursorOnMe() == true)
                {
                    GameWorldStart gws = new GameWorldStart();
                    Window.SetWorld(gws);
                    Globals.Score = 0;
                }
            }
            if (h2 != null)
            {
                if (h2.IsMouseCursorOnMe() == true)
                {
                    h2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    h2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && h2.IsMouseCursorOnMe() == true)
                {                                                        
                    GwStartMenuOption GwSmOption = new GwStartMenuOption();
                    Window.SetWorld(GwSmOption);                                 
                }
            }
            if (h3 != null)
            {
                    if (h3.IsMouseCursorOnMe() == true)
                {
                    h3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    h3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && h3.IsMouseCursorOnMe() == true) 
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
            
            SetCameraPosition(Globals.moveCameraX, 4, Globals.moveCameraY);
            SetCameraTarget(CameraPosition.X, CameraPosition.Y + 2, CameraPosition.Z);

            do
            {
                SetCameraPosition(CameraPosition.X - 400, CameraPosition.Y, CameraPosition.Z);
                
            }
            while(CameraPosition.X > 130);
            
                
            
            
            Globals.moveCameraX += 0.02f;
            if (l == 240*5)
            {
                
            }
            else if(l < 240*5)
            {
                l++;
            }
            else
            {
                l = 0;
            }
        }

        
        public override void Prepare()
        {
            Wall w1 = new Wall("1", 0f, 4f, 5f);
            Wall w2 = new Wall("2", 0f, 4f, 0f);
            w1.SetTexture("./app/Textures/wood1.png");
            w1.SetTextureRepeat(500f, 5f);
            w1.SetScale(1000,10,1);
            w2.SetTexture("./app/Textures/wood1.png");
            w2.SetTextureRepeat(500f, 5f);
            w2.SetScale(1000,10,1);
            

            Floor f = new Floor("floor", 1f, 1f, 1f); 
            f.SetTexture("./app/Textures/wood1.png");
            f.SetTextureRepeat(500f, 5f);
            f.SetScale(1000,1,10);
            Floor f1 = new Floor("floor", 1f, 10f, 1f);
            f1.SetTexture("./app/Textures/wood1.png");
            f1.SetTextureRepeat(500f, 5f);
            f1.SetScale(1000,1,10);
            SetCameraPosition(0.0f, 5.0f, 15.0f);

            LightObject light = new LightObject(LightType.Sun, ShadowQuality.Low);
            light.Name = ("scheiß auf den Namen");
            light.SetNearFar(10000f, 2500f);
            light.SetPosition(1f, 1f, 1);
            AddLightObject(light);

            Collectable c1 = new Collectable("1", 100f, 2.5f, 2.5f);
            AddGameObject(c1);
            AddGameObject(w1);
            AddGameObject(w2);
            AddGameObject(f);
            AddGameObject(f1);

            HUDObjectImage bbg = new HUDObjectImage("./App/Textures/blackscreen.png");
            bbg.Name = "background";
            bbg.SetScale(Window.Width, Window.Height);
            bbg.SetColor(0, 0, 0);
            bbg.CenterOnScreen();
            bbg.SetZIndex(-100);
            bbg.SetOpacity(0.75f);
            AddHUDObject(bbg);


            /*File.WriteAllText(Globals.Cpath, "true");
            if (Globals.Clines[0] == "true")
            {
                Globals.DisplayCreditsButton = true;
            }
            else if (Globals.Clines[0] == "false")
            {
                Globals.DisplayCreditsButton = false;
            }*/
            if (true) {
                HUDObjectText hTitle = new HUDObjectText("ITS STOLEN");
                hTitle.SetPosition(200f, 50f);
                hTitle.Name = "GameTitle";
                hTitle.SetCharacterDistanceFactor(1.0f);
                hTitle.SetColor(1.0f, 0.0f, 0.0f);
                hTitle.SetScale(80.0f);

                AddHUDObject(hTitle);
            }
            

            HUDObjectText hSubtitle = new HUDObjectText("By PLUG-INC");
            hSubtitle.SetPosition(500f, 100f);
            hSubtitle.Name = "GameSubTitle";
            hSubtitle.SetCharacterDistanceFactor(1.0f);
            hSubtitle.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(hSubtitle);

            HUDObjectImage bg = new HUDObjectImage("./App/Textures/MenuHintergrund.jpg");
            bg.Name = "background";
            bg.SetScale(Window.Width, Window.Height);            
            bg.CenterOnScreen();
            bg.SetZIndex(-100);
            bg.SetOpacity(0.65f);
            //AddHUDObject(bg);





            Globals.posWert = 10;
            Globals.posYWert = 100;
            
            HUDObjectText h1 = new HUDObjectText("START");
            h1.SetPosition(Globals.posYWert, 200f);                                                              
            h1.Name = "MyHUDObject1";                                                  
            h1.SetCharacterDistanceFactor(1.0f);   
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            h1.SetScale(50.0f);

            if (Globals.DisplayStartGameButton) { Globals.posWert += 50; }


            HUDObjectText h2 = new HUDObjectText("OPTION");
            h2.SetPosition(Globals.posYWert, 200f + Globals.posWert);             
            h2.Name = "MyHUDObject2";             
            h2.SetCharacterDistanceFactor(1.0f);
            h2.SetColor(1.0f, 0.0f, 0.0f);
            h2.SetColorEmissive(1.0f, 1.0f, 1.0f);

            if (Globals.DisplayOptionButton) { Globals.posWert += 50; }


            HUDObjectText credits = new HUDObjectText("CREDITS");
            credits.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            credits.Name = "credits";
            credits.SetCharacterDistanceFactor(1.0f);
            credits.SetColor(1.0f, 0.0f, 0.0f);
            credits.SetColorEmissive(1.0f, 1.0f, 1.0f);

            if (Globals.DisplayCreditsButton) { Globals.posWert += 50; }
            

            HUDObjectText leave = new HUDObjectText("LEAVE");
            leave.SetPosition(Globals.posYWert, 200f + Globals.posWert);
            leave.Name = "MyHUDObject3";
            leave.SetCharacterDistanceFactor(1.0f);
            leave.SetColor(1.0f, 0.0f, 0.0f);
            leave.SetColorEmissive(1.0f, 1.0f, 1.0f);

            
            if (Globals.DisplayStartGameButton) { AddHUDObject(h1); } 
            if (Globals.DisplayOptionButton) { AddHUDObject(h2); }
            if (Globals.DisplayCreditsButton) { AddHUDObject(credits); }
            if (Globals.DisplayLeaveButton) { AddHUDObject(leave); }

            HUDObjectText sb = new HUDObjectText("SCORE BOARD");
            sb.SetPosition(750f, 200f);
            sb.Name = "scoreboard";
            sb.SetCharacterDistanceFactor(1.0f);
            sb.SetColor(1.0f, 0.0f, 0.0f);
            
            AddHUDObject(sb);


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

            string dateiPfad = @"F:\.Programming\Repositys\Gruppenprojekt\App\data\data.txt";   //Zuhause
            dateiPfad = @"C:\Users\Til.Stuckenberg\source\GAME\App\data\data.txt";              //Schule
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
                    string path = @"F:\.Programming\Repositys\Gruppenprojekt\App\data\data.txt";
                    path = @"C:\Users\Til.Stuckenberg\source\GAME\App\data\data.txt";
                    string appendText = Convert.ToString(Globals.Score) + "\n";
                    File.AppendAllText(path, appendText);
                }
                
            }
            
            Array.Sort(allNumbers);

            try
            {
                s1.SetText("1# " + Convert.ToString(allNumbers[allNumbers.Length - 1]));
                if (allNumbers[allNumbers.Length - 1] >= 1000)
                {
                    s1.SetColor(1.0f, 1.0f, 1.0f);
                }
                else if (allNumbers[allNumbers.Length-1] >= 500)
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

    }
        
}

