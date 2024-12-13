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
    public class scoreboardMenu : World
    {
        bool delete = false;
        bool deleted = false;
        int pos = 120;
        public override void Act()
        {
            HUDObjectText clear = GetHUDObjectTextByName("clear");
            HUDObjectText text1 = GetHUDObjectTextByName("text1");
            HUDObjectText text2 = GetHUDObjectTextByName("text2");
            HUDObjectText bgSpeed = GetHUDObjectTextByName("bgSpeed");
            HUDObjectText scoreMultiplier = GetHUDObjectTextByName("scoreMultiplier");
            HUDObjectText deathReal = GetHUDObjectTextByName("deathReal");
            HUDObjectText bgCollectable = GetHUDObjectTextByName("bgCollectable");
            HUDObjectText bgAnimation = GetHUDObjectTextByName("bgAnimation");
            HUDObjectText completeTutorial = GetHUDObjectTextByName("completeTutorial");
            HUDObjectText back = GetHUDObjectTextByName("leave");
            if (back != null)
            {
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
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/click.wav", false, 0.2f);
                    GameWorldStartMenu gm = new GameWorldStartMenu();
                    Window.SetWorld(gm);
                }
            }
            if (clear != null)
            {
                if (delete && !deleted)
                {
                    clear.SetColor(1, 1, 1);
                    clear.SetColorEmissiveIntensity(0.0f);
                    clear.SetText("Are you Sure you want to delete all Scores ?");
                }
                else if (delete && deleted)
                {
                    clear.SetColor(1, 0, 0);
                    clear.SetColorEmissiveIntensity(0.0f);
                }
                else if (clear.IsMouseCursorOnMe() == true && delete)
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
                    if (deleted)
                    {
                        GameWorldStartMenu gm = new GameWorldStartMenu();
                        Window.SetWorld(gm);
                        return;
                    }
                    if (delete)
                    {
                        string filePath = @"./App/data/data.txt";
                        string filePathTime = @"./App/data/time.txt";

                        StreamWriter writer = new StreamWriter(filePath);
                        writer.Close();
                        // Datei löschen, falls sie existiert
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        File.WriteAllText(filePath, "");

                        StreamWriter writer1 = new StreamWriter(filePathTime);
                        writer1.Close();
                        if (File.Exists(filePathTime))
                        {
                            File.Delete(filePathTime);
                        }
                        File.WriteAllText(filePathTime, "");
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
                    if (Globals.moveCameraMultiplier == 1)
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
            if (deathReal != null)
            {
                if (deathReal.IsMouseCursorOnMe() == true)
                {
                    deathReal.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    deathReal.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && deathReal.IsMouseCursorOnMe() == true)
                {
                    if(Globals.deathreal)
                    {
                        deathReal.SetText("Death: " + Globals.enabledText);
                    }
                    else
                    {
                        deathReal.SetText("Death: " + Globals.disabledText);

                    }
                    Globals.deathreal = !Globals.deathreal;
                }
            }
            if (bgCollectable != null)
            {
                if (bgCollectable.IsMouseCursorOnMe() == true)
                {
                    bgCollectable.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    bgCollectable.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && bgCollectable.IsMouseCursorOnMe() == true)
                {
                    if (Globals.bgAnimation)
                    {
                        bgCollectable.SetText("Collectable: " + Globals.enabledText);
                    }
                    else
                    {
                        bgCollectable.SetText("Collectable: " + Globals.disabledText);

                    }
                    Globals.bgAnimation = !Globals.bgAnimation;
                }
            }
            if (bgAnimation != null) 
            {
                if (bgAnimation.IsMouseCursorOnMe() == true)
                {
                    bgAnimation.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    bgAnimation.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && bgAnimation.IsMouseCursorOnMe() == true)
                {
                    if (Globals.bgAnimation)
                    {
                        bgAnimation.SetText("Animation: " + Globals.enabledText);
                    }
                    else
                    {
                        bgAnimation.SetText("Animation: " + Globals.disabledText);

                    }
                    Globals.bgAnimation = !Globals.bgAnimation;
                }           
            }
            if (completeTutorial != null)
            {
                if (completeTutorial.IsMouseCursorOnMe() == true)
                {
                    completeTutorial.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    completeTutorial.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && completeTutorial.IsMouseCursorOnMe() == true)
                {
                    if (Globals.TutorialComplete)
                    {
                        completeTutorial.SetText("Must Complete Tutorial: " + Globals.enabledText);
                    }
                    else
                    {
                        completeTutorial.SetText("Must Complete Tutorial: " + Globals.disabledText);

                    }
                    Globals.TutorialComplete = !Globals.TutorialComplete;
                }
            }

            if (Globals.moveCameraMultiplier == 1f) { bgSpeed.SetText("Background Speed: x1"); }
            if (Globals.moveCameraMultiplier == 2f) { bgSpeed.SetText("Background Speed: x2"); }
            if (Globals.moveCameraMultiplier == 4f) { bgSpeed.SetText("Background Speed: x4"); }
            if (Globals.moveCameraMultiplier == 0.25f) { bgSpeed.SetText("Background Speed: x0.25"); }
            if (Globals.moveCameraMultiplier == 0.5f) { bgSpeed.SetText("Background Speed: x0.5"); }

            if (Globals.multiplikator == 1f) { scoreMultiplier.SetText("Score Multiplier: x1"); }
            if (Globals.multiplikator == 2f) { scoreMultiplier.SetText("Score Multiplier: x2"); }
            if (Globals.multiplikator == 5f) { scoreMultiplier.SetText("Score Multiplier: x5"); }
            if (Globals.multiplikator == 10f) { scoreMultiplier.SetText("Score Multiplier: x10"); }
            if (Globals.multiplikator == 0.1f) { scoreMultiplier.SetText("Score Multiplier: x0.1"); }
            if (Globals.multiplikator == 0.05f) { scoreMultiplier.SetText("Score Multiplier: x0.05"); }
            if (Globals.multiplikator == 0.01f) { scoreMultiplier.SetText("Score Multiplier: x0.01"); }

            if (Globals.deathreal) { deathReal.SetText("Death: " + Globals.enabledText); } else { deathReal.SetText("Death: " + Globals.disabledText); }
            if (Globals.bgAnimation) { bgAnimation.SetText("Animation: " + Globals.enabledText); } else { bgAnimation.SetText("Animation: " + Globals.disabledText); }            
            if (Globals.TutorialComplete) { completeTutorial.SetText("Must Complete Tutorial: " + Globals.disabledText); } else { completeTutorial.SetText("Must Complete Tutorial: " + Globals.enabledText); }
        }
        public override void Prepare()
        {
            HUDObjectText h1 = new HUDObjectText(Globals.backText);
            h1.SetPosition(50f, 80f);
            h1.Name = "leave";
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(h1);

            HUDObjectText sbTitle = new HUDObjectText("Scoreboard Settings");
            sbTitle.SetPosition(130f, pos);
            sbTitle.SetColor(1.0f, 0.0f, 0.0f);
            sbTitle.SetScale(30.0f);
            AddHUDObject(sbTitle);

            pos += 50;
            HUDObjectText clear = new HUDObjectText("clear");
            clear.SetPosition(160f, pos);
            clear.Name = "clear";
            clear.SetColor(1.0f, 0.0f, 0.0f);
            clear.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(clear);

            pos += 70;
            HUDObjectText bgTitle = new HUDObjectText("Background Settings");
            bgTitle.SetPosition(130f, pos);
            bgTitle.SetColor(1.0f, 0.0f, 0.0f);
            bgTitle.SetScale(30.0f);
            AddHUDObject(bgTitle);

            pos += 50;
            HUDObjectText bgSpeed = new HUDObjectText("Background Speed:");
            bgSpeed.SetPosition(160f, pos);
            bgSpeed.Name = "bgSpeed";
            bgSpeed.SetColor(1.0f, 0.0f, 0.0f);
            bgSpeed.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(bgSpeed);

            pos += 50;
            HUDObjectText bgAnimation = new HUDObjectText("Animation:");
            bgAnimation.SetPosition(160f, pos);
            bgAnimation.Name = "bgAnimation";
            bgAnimation.SetColor(1.0f, 0.0f, 0.0f);
            bgAnimation.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(bgAnimation);

            pos += 70;
            HUDObjectText gameSettings = new HUDObjectText("Game Settings");
            gameSettings.SetPosition(130f, pos);
            gameSettings.SetColor(1.0f, 0.0f, 0.0f);
            gameSettings.SetScale(30.0f);
            AddHUDObject(gameSettings);

            pos += 50;
            HUDObjectText scoreM = new HUDObjectText("Score Multiplier:");
            scoreM.SetPosition(160f, pos);
            scoreM.Name = "scoreMultiplier";
            scoreM.SetColor(1.0f, 0.0f, 0.0f);
            scoreM.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(scoreM);

            pos += 50;
            HUDObjectText deathReal = new HUDObjectText("Death:");
            deathReal.SetPosition(160f, pos);
            deathReal.Name = "deathReal";
            deathReal.SetColor(1.0f, 0.0f, 0.0f);
            deathReal.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(deathReal);

            pos += 50;
            HUDObjectText completeTutorial = new HUDObjectText("Must Complete Tutorial: ");
            completeTutorial.SetPosition(160f, pos);
            completeTutorial.Name = "completeTutorial";
            completeTutorial.SetColor(1.0f, 0.0f, 0.0f);
            completeTutorial.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(completeTutorial);
        }
    }
}