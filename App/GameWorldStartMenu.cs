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

namespace Gruppenprojekt.App
{
    public class GameWorldStartMenu : World
    {
        
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
                    GameWorldStart gws = new GameWorldStart();
                    Window.SetWorld(gws);
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
            

        }

        
        public override void Prepare()
        {
            HUDObjectText hName = new HUDObjectText("ITS STOLEN | by PLUG-INC");
            hName.SetPosition(400f, 50f);
            hName.Name = "GameText";
            hName.SetCharacterDistanceFactor(1.0f);
            hName.SetColor(1.0f, 0.0f, 0.0f);
            
            AddHUDObject(hName);


            HUDObjectText h1 = new HUDObjectText("START GAME");
            h1.SetPosition(160f, 200f);                                                              
            h1.Name = "MyHUDObject1";                                                  
            h1.SetCharacterDistanceFactor(1.0f);   
            h1.SetColor(1.0f, 0.0f, 0.0f);         
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f); 

            AddHUDObject(h1);

            
            HUDObjectText h2 = new HUDObjectText("OPTION");
            h2.SetPosition(160f, 250f);             
            h2.Name = "MyHUDObject2";             
            h2.SetCharacterDistanceFactor(1.0f);
            h2.SetColor(1.0f, 0.0f, 0.0f);
            h2.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(h2);


            HUDObjectText credits = new HUDObjectText("CREDITS");
            credits.SetPosition(160f, 300f);
            credits.Name = "credits";
            credits.SetCharacterDistanceFactor(1.0f);
            credits.SetColor(1.0f, 0.0f, 0.0f);
            credits.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(credits);


            HUDObjectText leave = new HUDObjectText("LEAVE");
            leave.SetPosition(160f, 350f);
            leave.Name = "MyHUDObject3";
            leave.SetCharacterDistanceFactor(1.0f);
            leave.SetColor(1.0f, 0.0f, 0.0f);
            leave.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(leave);


            HUDObjectText sb = new HUDObjectText("SCORE BOARD");
            sb.SetPosition(750f, 170f);
            sb.Name = "scoreboard";
            sb.SetCharacterDistanceFactor(1.0f);
            sb.SetColor(1.0f, 0.0f, 0.0f);
            
            AddHUDObject(sb);


            HUDObjectText s1 = new HUDObjectText("1#");
            s1.SetPosition(700f, 220f);
            s1.Name = "score1";
            s1.SetCharacterDistanceFactor(1.0f);
            s1.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s2 = new HUDObjectText("2#");
            s2.SetPosition(700f, 260f);
            s2.Name = "score2";
            s2.SetCharacterDistanceFactor(1.0f);
            s2.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s3 = new HUDObjectText("3#");
            s3.SetPosition(700f, 300f);
            s3.Name = "score3";
            s3.SetCharacterDistanceFactor(1.0f);
            s3.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s4 = new HUDObjectText("4#");
            s4.SetPosition(700f, 340f);
            s4.Name = "score4";
            s4.SetCharacterDistanceFactor(1.0f);
            s4.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s5 = new HUDObjectText("5#");
            s5.SetPosition(700f, 380f);
            s5.Name = "score5";
            s5.SetCharacterDistanceFactor(1.0f);
            s5.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s6 = new HUDObjectText("6#");
            s6.SetPosition(700f, 420f);
            s6.Name = "score6";
            s6.SetCharacterDistanceFactor(1.0f);
            s6.SetColor(1.0f, 0.0f, 0.0f);            

            HUDObjectText s7 = new HUDObjectText("7#");
            s7.SetPosition(700f, 460f);
            s7.Name = "scpre7";
            s7.SetCharacterDistanceFactor(1.0f);
            s7.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s8 = new HUDObjectText("8#");
            s8.SetPosition(700f, 500f);
            s8.Name = "score8";
            s8.SetCharacterDistanceFactor(1.0f);
            s8.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s9 = new HUDObjectText("9#");
            s9.SetPosition(700f, 540f);
            s9.Name = "score9";
            s9.SetCharacterDistanceFactor(1.0f);
            s9.SetColor(1.0f, 0.0f, 0.0f);

            HUDObjectText s10 = new HUDObjectText("1O#");
            s10.SetPosition(678f, 580f);
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



            
            

        }
        
        
        

    }
}
