using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace Gruppenprojekt.App.Menus
{
    public class InfoMenu : World
    {
        int dLevel = 0;
        public override void Act()
        {
            HUDObjectText back = GetHUDObjectTextByName("back");
            HUDObjectText dLevelText = GetHUDObjectTextByName("dLevelText");
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
        }
        public override void Prepare()
        {
            int posX = 200;
            int posY = 200;
            int posSX = 100;
            int pusSY = 150;
            HUDObjectText back = new HUDObjectText("BACK");
            back.SetPosition(50f, 80f);
            back.Name = "back";
            back.SetColor(1.0f, 0.0f, 0.0f);
            back.SetColorEmissive(1.0f, 1.0f, 1.0f);

            
            posY += 50;


            HUDObjectText Map = new HUDObjectText("MAP");
            Map.SetPosition(posSX, pusSY);
            Map.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(Map);
            pusSY += 50;
            HUDObjectText World = new HUDObjectText("WORLD");
            World.SetPosition(posSX, pusSY);
            World.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(World);
            pusSY += 50;
            HUDObjectText Enemy = new HUDObjectText("ENEMY");
            Enemy.SetPosition(posSX, pusSY);
            Enemy.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(Enemy);
            pusSY += 30;
            HUDObjectText EnemyAttack = new HUDObjectText(">ATTACK");
            EnemyAttack.SetPosition(posSX, pusSY);
            EnemyAttack.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(EnemyAttack);
            pusSY += 30;
            HUDObjectText EnemyBehaviour = new HUDObjectText(">BEHAVIOUR");
            EnemyBehaviour.SetPosition(posSX, pusSY);
            EnemyBehaviour.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(EnemyBehaviour);
            pusSY += 30;
            HUDObjectText EnemyMovement = new HUDObjectText(">MOVEMENT");
            EnemyMovement.SetPosition(posSX, pusSY);
            EnemyMovement.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(EnemyMovement);
            pusSY += 50;
            HUDObjectText Flashlight = new HUDObjectText("FLASHLIGHT");
            Flashlight.SetPosition(posSX, pusSY);
            Flashlight.SetColor(1.0f, 0.0f, 0.0f);
            AddHUDObject(Flashlight);

            HUDObjectText border1 = new HUDObjectText("|");
            HUDObjectText border2 = new HUDObjectText("|");
            HUDObjectText border3 = new HUDObjectText("|");
            border1.SetScale(10f,800.0f);
            border2.SetScale(128.0f);
            border3.SetScale(128.0f);
            border1.SetPosition(350, 450);
            border2.SetPosition(350, 100);
            border3.SetPosition(350, 150);
            AddHUDObject(border1);
        }
    }
}
