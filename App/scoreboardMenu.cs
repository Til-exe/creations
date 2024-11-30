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
    public class scoreboardMenu : World
    {
        bool delete = false;
        bool deleted = false;
        int speed = 0;
        public override void Act()
        {

            HUDObjectText leave = GetHUDObjectTextByName("leave");
            HUDObjectText clear = GetHUDObjectTextByName("clear");
            HUDObjectText text1 = GetHUDObjectTextByName("text1");
            HUDObjectText text2 = GetHUDObjectTextByName("text2");
            HUDObjectText bgSpeed = GetHUDObjectTextByName("bgSpeed"); 
            HUDObjectText scoreMultiplier = GetHUDObjectTextByName("scoreMultiplier");
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
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }
            if (clear != null)
            {
                if(delete && deleted)
                {
                    clear.SetColor(1, 0, 0);
                    clear.SetColorEmissiveIntensity(0.0f);
                }
                else if(clear.IsMouseCursorOnMe() == true && delete)
                {
                    clear.SetColorEmissiveIntensity(0.5f);
                    clear.SetColor(1, 1, 1);
                }
                else if (clear.IsMouseCursorOnMe() == true && !deleted)
                {
                    clear.SetColor(1, 0, 0);
                    clear.SetColorEmissiveIntensity(1.5f);
                    clear.SetText("clear Scores ?");
                }
                else
                {
                    clear.SetColor(1, 0, 0);
                    clear.SetColorEmissiveIntensity(0.0f);
                    clear.SetText("clear");

                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && clear.IsMouseCursorOnMe() == true)
                {
                    if(deleted)
                    {
                        GameWorldStartMenu gm = new GameWorldStartMenu();
                        Window.SetWorld(gm);
                        return;
                    }
                    if(delete)
                    {
                        string filePath = @"./App/data/data.txt";
                        
                        StreamWriter writer = new StreamWriter(filePath);
                        writer.Close();
                        // Datei löschen, falls sie existiert
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        File.Create(filePath);
                        clear.SetText("cleared file");
                        deleted = true;
                    }
                    else if (!delete)
                    {
                        clear.SetText("Are you Sure you want to delete all Scores ?");
                        delete = true;
                    }
                    
                    
                    
                }
            }
            if (text1 != null)
            {
                if (text1.IsMouseCursorOnMe() == true)
                {
                    text1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    text1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && text1.IsMouseCursorOnMe() == true)
                {
                    
                }
            }
            if (text2 != null)
            {
                if (text2.IsMouseCursorOnMe() == true)
                {
                    text2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    text2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && text2.IsMouseCursorOnMe() == true)
                {
                    
                }
            }
            if (bgSpeed != null)
            {
                if (bgSpeed.IsMouseCursorOnMe() == true)
                {
                    bgSpeed.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    bgSpeed.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && bgSpeed.IsMouseCursorOnMe() == true)
                {
                    if(Globals.moveCameraMultiplier == 1)
                    { 
                        Globals.moveCameraMultiplier = 2;
                    }
                    else if (Globals.moveCameraMultiplier == 2)
                    {
                        Globals.moveCameraMultiplier = 4;
                    }
                    else if (Globals.moveCameraMultiplier == 4) 
                    {
                        Globals.moveCameraMultiplier = 0.25f;
                    }
                    else if (Globals.moveCameraMultiplier == 0.25f) 
                    {
                        Globals.moveCameraMultiplier = 0.5f;
                    }
                    else if (Globals.moveCameraMultiplier == 0.5f) 
                    {
                        Globals.moveCameraMultiplier = 1;
                    }
                    
                    
                    
                    
                    
                }
            }
            if (scoreMultiplier != null)
            {
                if (scoreMultiplier.IsMouseCursorOnMe() == true)
                {
                    scoreMultiplier.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    scoreMultiplier.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && scoreMultiplier.IsMouseCursorOnMe() == true)
                {
                    if (Globals.multiplikator == 1)
                    {
                        Globals.multiplikator = 2;
                    }
                    else if (Globals.multiplikator == 2)
                    {
                        Globals.multiplikator = 5;
                    }
                    else if (Globals.multiplikator == 5)
                    {
                        Globals.multiplikator = 10;
                    }
                    else if (Globals.multiplikator == 10)
                    {
                        Globals.multiplikator = 0.1f;
                    }
                    else if (Globals.multiplikator == 0.1f)
                    {
                        Globals.multiplikator = 0.05f;
                    }
                    else if (Globals.multiplikator == 0.05f)
                    {
                        Globals.multiplikator = 0.01f;
                    }
                    else if (Globals.multiplikator == 0.01f)
                    {
                        Globals.multiplikator = 1f;
                    }
                }
            }


            if (Globals.moveCameraMultiplier == 1f) { bgSpeed.SetText("Scoreboard Settings: x1"); }
            if (Globals.moveCameraMultiplier == 2f) { bgSpeed.SetText("Scoreboard Settings: x2"); }
            if (Globals.moveCameraMultiplier == 4f) { bgSpeed.SetText("Scoreboard Settings: x4"); }
            if (Globals.moveCameraMultiplier == 0.25f) { bgSpeed.SetText("Scoreboard Settings: x0.25"); }
            if (Globals.moveCameraMultiplier == 0.5f) { bgSpeed.SetText("Scoreboard Settings: x0.5"); }

            if (Globals.multiplikator == 1f) { scoreMultiplier.SetText("Score Multiplier: x1"); }
            if (Globals.multiplikator == 2f) { scoreMultiplier.SetText("Score Multiplier: x2"); }
            if (Globals.multiplikator == 5f) { scoreMultiplier.SetText("Score Multiplier: x5"); }
            if (Globals.multiplikator == 10f) { scoreMultiplier.SetText("Score Multiplier: x10"); }
            if (Globals.multiplikator == 0.1f) { scoreMultiplier.SetText("Score Multiplier: x0.1"); }
            if (Globals.multiplikator == 0.05f) { scoreMultiplier.SetText("Score Multiplier: x0.05"); }
            if (Globals.multiplikator == 0.01f) { scoreMultiplier.SetText("Score Multiplier: x0.01"); }
        }


        public override void Prepare()
        {
            int pos = 120;


            HUDObjectText h1 = new HUDObjectText("BACK");
            h1.SetPosition(50f, 80f);
            h1.Name = "leave";
            h1.SetCharacterDistanceFactor(1.0f);
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(h1);  
            


            HUDObjectText sbTitle = new HUDObjectText("Scoreboard Settings");
            sbTitle.SetPosition(130f, pos);            
            sbTitle.SetCharacterDistanceFactor(1.0f);
            sbTitle.SetColor(1.0f, 0.0f, 0.0f);
            sbTitle.SetScale(30.0f);            

            AddHUDObject(sbTitle);

            pos += 50;
            HUDObjectText clear = new HUDObjectText("clear");
            clear.SetPosition(160f, pos);
            clear.Name = "clear";
            clear.SetCharacterDistanceFactor(1.0f);
            clear.SetColor(1.0f, 0.0f, 0.0f);
            clear.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(clear);

            //pos += 50;
            //HUDObjectText text1 = new HUDObjectText("");
            //text1.SetPosition(160f, pos + 100f);
            //text1.Name = "text1";
            //text1.SetCharacterDistanceFactor(1.0f);
            //text1.SetColor(1.0f, 0.0f, 0.0f);
            //text1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //
            //AddHUDObject(text1);

            //pos += 50;
            //HUDObjectText text2 = new HUDObjectText("");
            //text2.SetPosition(160f, pos + 150f);
            //text2.Name = "text2";
            //text2.SetCharacterDistanceFactor(1.0f);
            //text2.SetColor(1.0f, 0.0f, 0.0f);
            //text2.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //
            //AddHUDObject(text2);



            pos += 70;
            HUDObjectText bgTitle = new HUDObjectText("Background Settings");
            bgTitle.SetPosition(130f, pos);
            bgTitle.SetCharacterDistanceFactor(1.0f);
            bgTitle.SetColor(1.0f, 0.0f, 0.0f);
            bgTitle.SetScale(30.0f);

            AddHUDObject(bgTitle);

            pos += 50;
            HUDObjectText bgSpeed = new HUDObjectText("Background Speed:");
            bgSpeed.SetPosition(160f, pos);
            bgSpeed.Name = "bgSpeed";
            bgSpeed.SetCharacterDistanceFactor(1.0f);
            bgSpeed.SetColor(1.0f, 0.0f, 0.0f);
            bgSpeed.SetColorEmissive(1.0f, 1.0f, 1.0f);
            
            AddHUDObject(bgSpeed);

            pos += 70;
            HUDObjectText gameSettings = new HUDObjectText("Game Settings");
            gameSettings.SetPosition(130f, pos);
            gameSettings.SetCharacterDistanceFactor(1.0f);
            gameSettings.SetColor(1.0f, 0.0f, 0.0f);
            gameSettings.SetScale(30.0f);

            AddHUDObject(gameSettings);

            pos += 50;
            HUDObjectText scoreMultiplier = new HUDObjectText("Score Multiplier:");
            scoreMultiplier.SetPosition(160f, pos);
            scoreMultiplier.Name = "scoreMultiplier";
            scoreMultiplier.SetCharacterDistanceFactor(1.0f);
            scoreMultiplier.SetColor(1.0f, 0.0f, 0.0f);
            scoreMultiplier.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(scoreMultiplier);


            string filePath = @"./App/data/scoreboardSettings.txt";
            try
            {
                // Datei löschen, falls sie existiert
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Datei neu erstellen und beschreiben
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("Dies ist eine neu erstellte Datei.");
                    writer.WriteLine("Hier ist eine zweite Zeile Text.");
                }

                // Methode 1: Ganze Datei als Text einlesen
                string fileContent = File.ReadAllText(filePath);


                // Methode 2: Datei zeilenweise einlesen
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {

            }




        }        
    }
}
