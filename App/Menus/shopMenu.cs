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
    public class shopMenu : World
    {
        bool delete = false;
        bool deleted = false;
        int speed = 0;
        int pos = 200;
        public override void Act()
        {
            HUDObjectText leave = GetHUDObjectTextByName("leave");
            HUDObjectText buy1 = GetHUDObjectTextByName("buy1");
            HUDObjectText buy2 = GetHUDObjectTextByName("buy2");
            HUDObjectText buy3 = GetHUDObjectTextByName("buy3");
            HUDObjectText score = GetHUDObjectTextByName("score");
            /*
            HUDObjectText clear = GetHUDObjectTextByName("clear");
            HUDObjectText text1 = GetHUDObjectTextByName("text1");
            HUDObjectText text2 = GetHUDObjectTextByName("text2");
            HUDObjectText bgSpeed = GetHUDObjectTextByName("bgSpeed");
            HUDObjectText scoreMultiplier = GetHUDObjectTextByName("scoreMultiplier");
            HUDObjectText deathReal = GetHUDObjectTextByName("deathReal");
            HUDObjectText bgCollectable = GetHUDObjectTextByName("bgCollectable");
            HUDObjectText bgAnimation = GetHUDObjectTextByName("bgAnimation");
            */
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
                    GwStartMenuOption gm = new GwStartMenuOption();
                    Window.SetWorld(gm);
                }
            }
            if (buy1 != null)
            {
                if (buy1.IsMouseCursorOnMe() == true)
                {
                    buy1.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    buy1.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && buy1.IsMouseCursorOnMe() == true)
                {
                    
                }
            }
            if (buy2 != null)
            {
                if (buy2.IsMouseCursorOnMe() == true)
                {
                    buy2.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    buy2.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && buy2.IsMouseCursorOnMe() == true)
                {

                }
            }
            if (buy3 != null)
            {
                if (buy3.IsMouseCursorOnMe() == true)
                {
                    buy3.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    buy3.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && buy3.IsMouseCursorOnMe() == true)
                {

                }
            }
            score.SetText("Score: " + Globals.totalScore + " Punkte");
        }
        public override void Prepare()
        {
            float posY = 260f;
            HUDObjectText h1 = new HUDObjectText(Globals.backText);
            h1.SetPosition(50f, 80f);
            h1.Name = "leave";
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(h1);
            
            HUDObjectText sbTitle = new HUDObjectText("");
            sbTitle.SetPosition(130f, pos);
            sbTitle.SetColor(1.0f, 0.0f, 0.0f);
            sbTitle.SetScale(30.0f);
            AddHUDObject(sbTitle);

            HUDObjectText score = new HUDObjectText("Score: " + Globals.totalScore + " Punkte");
            score.Name = "score";
            score.SetPosition(730f, 80);
            score.SetColor(1.0f, 0.0f, 0.0f);
            score.SetScale(25.0f);
            AddHUDObject(score);

            pos += 50;
            HUDObjectText buy1 = new HUDObjectText("Buy");
            buy1.SetPosition(160f, pos);
            buy1.Name = "buy1";
            buy1.SetColor(1.0f, 0.0f, 0.0f);
            buy1.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(buy1);

            HUDObjectText option1 = new HUDObjectText("500  Punkte - Unbreakable Flashlight");
            option1.SetPosition(posY, pos);
            option1.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(option1);

            pos += 50;
            HUDObjectText buy2 = new HUDObjectText("Buy");
            buy2.SetPosition(160f, pos);
            buy2.Name = "buy2";
            buy2.SetColor(1.0f, 0.0f, 0.0f);
            buy2.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(buy2);

            HUDObjectText option2 = new HUDObjectText("3000 Punkte - 2 Lifes");
            option2.SetPosition(posY, pos);
            option2.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(option2);

            pos += 50;
            HUDObjectText buy3 = new HUDObjectText("Buy");
            buy3.SetPosition(160f, pos);
            buy3.Name = "buy3";
            buy3.SetColor(1.0f, 0.0f, 0.0f);
            buy3.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(buy3);

            HUDObjectText option3 = new HUDObjectText("1800 Punkte - Slow Enemy");
            option3.SetPosition(posY, pos);
            option3.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(option3);
        }
    }
}