using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Xml.Linq;

namespace Gruppenprojekt.App.Menus
{
    public class InfoMenu : World
    {
        int posX = 200;
        int posY = 200;
        int posSX = 100;
        int pusSY = 150;
        int dLevel = 0;
        bool toggleEnemyText = true;
        bool displayText = true;
        bool notDisplayed = true;
        public override void Act()
        {
            HUDObjectText back = GetHUDObjectTextByName("back");
            HUDObjectText Map = GetHUDObjectTextByName("Map");
            HUDObjectText World = GetHUDObjectTextByName("World");
            HUDObjectText Enemy= GetHUDObjectTextByName("Enemy");
            HUDObjectText Attack = GetHUDObjectTextByName("Attack");
            HUDObjectText Benehmen = GetHUDObjectTextByName("Benehmen");
            HUDObjectText Movement = GetHUDObjectTextByName("Movement");
            HUDObjectText Flashlight = GetHUDObjectTextByName("Flashlight");
            HUDObjectText text1 =  GetHUDObjectTextByName("text1");
            HUDObjectText text2 =  GetHUDObjectTextByName("text2");
            HUDObjectText text3 =  GetHUDObjectTextByName("text3");
            HUDObjectText text4 =  GetHUDObjectTextByName("text4");
            HUDObjectText text5 =  GetHUDObjectTextByName("text5");
            HUDObjectText text6 =  GetHUDObjectTextByName("text6");


            text1.SetText("");
            text2.SetText("");
            text3.SetText("");
            text4.SetText("");
            text5.SetText("");
            text6.SetText("");
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
                    GwStartMenuOption gwo = new GwStartMenuOption();
                    Window.SetWorld(gwo);
                }
            }
            if (Enemy != null)
            {
                if (Enemy.IsMouseCursorOnMe() == true)
                {
                    Enemy.SetColorEmissiveIntensity(0.8f);                
                }
                else
                {
                    Enemy.SetColorEmissiveIntensity(0.0f);
                    Enemy.SetText(">Enemy");
                    if (toggleEnemyText)
                    {
                        Flashlight.SetPosition(100, 300);
                    }      
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && Enemy.IsMouseCursorOnMe() == true)
                {
                    Enemy.SetText("vEnemy");
                    Flashlight.SetPosition(100, 400);
                    if (toggleEnemyText)
                    {
                        Attack.SetPosition(110, 280);
                        Benehmen.SetPosition(110, 310);
                        Movement.SetPosition(110, 340);
                    }
                    else
                    {
                        Attack.SetPosition(110, 2800);
                        Benehmen.SetPosition(110, 3100);
                        Movement.SetPosition(110, 3400);
                    }
                    toggleEnemyText = !toggleEnemyText;
                    
                }
            }            
            if (Flashlight != null)
            {
                if (Flashlight.IsMouseCursorOnMe() == true)
                {
                    Flashlight.SetColorEmissiveIntensity(0.8f);
                    text1.SetText("Du kannst die Taschenlampe nutzen um");
                    text2.SetText("den Gegner zu blenden wenn er vor dir");
                    text3.SetText("ist. Er wird sich für kurze Zeit");
                    text4.SetText("Langsamer bewegen. Doch pass auf..");
                    text5.SetText("Die Taschenlampe kann ganz zufällig");
                    text6.SetText("kaputt gehen und sich ausschalten.");
                }
                else 
                {
                    Flashlight.SetColorEmissiveIntensity(0.0f);
                }
            }
            if (Attack != null)
            {
                if (Attack.IsMouseCursorOnMe() == true)
                {
                    Attack.SetColorEmissiveIntensity(0.8f);
                    text1.SetText("Sollte der Gegner dich sehen wird er ");
                    text2.SetText("dich verfolgen bis er dich aus den Augen");
                    text3.SetText("verloren hat. Sei Vorsichtig. Der Gegner");
                    text4.SetText("ist schneller als du. LAUF!");
                    text5.SetText("Du kannst ihm entkommen indem du schnell um");
                    text6.SetText("Ecken läufst!");
                }
                else
                {
                    Attack.SetColorEmissiveIntensity(0.0f);
                }
            }
            if (World != null)
            {
                if (World.IsMouseCursorOnMe() == true)
                {
                    World.SetColorEmissiveIntensity(0.8f);
                    text1.SetText("Im Spiel befindest du dich in einem");
                    text2.SetText("Labyrinth indem jeder gang einen");
                    text3.SetText("ausweg hat. Bisauf die großen Räume!");
                    text4.SetText("Die meisten sind Sackgassen.");
                }
                else 
                {
                    World.SetColorEmissiveIntensity(0.0f);
                }
            }
            if (Map != null)
            {
                if (Map.IsMouseCursorOnMe() == true)
                {
                    Map.SetColorEmissiveIntensity(0.8f);
                    text1.SetText("Die Map zeigt nicht den Gegner an.");
                    text2.SetText("Sei Also vorsichtig wenn du ");
                    text3.SetText("die Map benutzt! Der Gegner könnte");
                    text4.SetText("bereits auf dem Weg sein!");
                }
                else
                {
                    Map.SetColorEmissiveIntensity(0.0f);
                }
            }
            if (Benehmen != null)
            {
                if (Benehmen.IsMouseCursorOnMe() == true)
                {
                    Benehmen.SetColorEmissiveIntensity(0.8f);
                    text1.SetText("Der Gegner wird durch das Labyrinth");
                    text2.SetText("laufen und dich suchen. Er kann hinter");
                    text3.SetText("jeder ecke lauern. Sobald er dich berührt");
                    text4.SetText("ist es aus für dich und du musst neustarten!");
                    text5.SetText("Du wirst ihn sehen, aber nicht immer sieht");
                    text6.SetText("er dich dann auch.");
                }
                else
                {
                    Benehmen.SetColorEmissiveIntensity(0.0f);
                    
                }
            }
            if (Movement != null)
            {
                if (Movement.IsMouseCursorOnMe() == true)
                {
                    displayText = true;
                    Movement.SetColorEmissiveIntensity(0.8f);
                    text1.SetText("Der Gegner ist viel Schneller als du");
                    text2.SetText("und wird dich erbahmungslos durch die");
                    text3.SetText("gesamte Map jagen.");
                }
                else
                {
                    Movement.SetColorEmissiveIntensity(0.0f);
                }
            }
        }
        public override void Prepare()
        {
            
            HUDObjectText back = new HUDObjectText("Back");
            back.SetPosition(50f, 80f);
            back.Name = "back";
            back.SetColor(1.0f, 0.0f, 0.0f);
            back.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(back);
            
            posY += 50;


            HUDObjectText Map = new HUDObjectText("MAP");
            Map.SetColor(1.0f, 0.0f, 0.0f);
            Map.SetPosition(posSX, pusSY);
            Map.SetColorEmissive(1.0f, 1.0f, 1.0f);
            Map.Name = "Map"; 
            AddHUDObject(Map);
            pusSY += 50;                                        //200
            HUDObjectText World = new HUDObjectText("WORLD");
            World.Name = "World";
            World.SetPosition(posSX, pusSY);
            World.SetColor(1.0f, 0.0f, 0.0f);
            World.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(World);
            pusSY += 50;                                        //250
            HUDObjectText Enemy = new HUDObjectText("ENEMY");
            Enemy.Name = "Enemy";
            Enemy.SetPosition(posSX, pusSY);
            Enemy.SetColor(1.0f, 0.0f, 0.0f);
            Enemy.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(Enemy);
            pusSY += 30;                                        //280
            HUDObjectText EnemyAttack = new HUDObjectText("ATTACK");
            EnemyAttack.Name = "Attack";
            EnemyAttack.SetPosition(posSX+10, 2800);
            EnemyAttack.SetColor(1.0f, 0.0f, 0.0f);
            EnemyAttack.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(EnemyAttack);
            pusSY += 30;                                        //310
            HUDObjectText EnemyBehaviour = new HUDObjectText("BEHAVIOUR");
            EnemyBehaviour.Name = "Benehmen";
            EnemyBehaviour.SetPosition(posSX + 10, 3100);
            EnemyBehaviour.SetColor(1.0f, 0.0f, 0.0f);
            EnemyBehaviour.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(EnemyBehaviour);
            pusSY += 30;                                        //340
            HUDObjectText EnemyMovement = new HUDObjectText(">MOVEMENT");
            EnemyMovement.SetPosition(posSX + 10, 3400);
            EnemyMovement.SetColor(1.0f, 0.0f, 0.0f);
            EnemyMovement.SetColorEmissive(1.0f, 1.0f, 1.0f);
            EnemyMovement.Name = "Movement";
            AddHUDObject(EnemyMovement);
            pusSY += 50;                                        //390
            HUDObjectText Flashlight = new HUDObjectText("FLASHLIGHT");
            Flashlight.Name = "Flashlight";
            Flashlight.SetColorEmissive(1.0f, 1.0f, 1.0f);
            Flashlight.SetPosition(posSX, 390);
            Flashlight.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(Flashlight);

            HUDObjectText border1 = new HUDObjectText("|");
            border1.SetScale(10f,800.0f);
            border1.SetPosition(350, 450);
            AddHUDObject(border1);

            HUDObjectText text1 = new HUDObjectText("");
            text1.Name = "text1";
            text1.SetPosition(400, 100);
            text1.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text1);
            HUDObjectText text2 = new HUDObjectText("");
            text2.Name = "text2";
            text2.SetPosition(400, 150);
            text2.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text2);
            HUDObjectText text3 = new HUDObjectText("");
            text3.Name = "text3";
            text3.SetPosition(400, 200);
            text3.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text3);
            HUDObjectText text4 = new HUDObjectText("");
            text4.Name = "text4";
            text4.SetPosition(400, 250);
            text4.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text4);
            HUDObjectText text5 = new HUDObjectText("");
            text5.Name = "text5";
            text5.SetPosition(400, 300);
            text5.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text5);
            HUDObjectText text6 = new HUDObjectText("");
            text6.Name = "text6";
            text6.SetPosition(400, 350);
            text6.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(text6);



        }
    }
}
