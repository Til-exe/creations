using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Gruppenprojekt.App
{
    public class GameWorldStartMenu : World
    {
        public override void Act()
        {
            HUDObjectImage background = GetHUDObjectImageByName("MyHUDObject");
            if (background != null)
            {
                if (background.IsMouseCursorOnMe() == true)
                {
                    background.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    background.SetColorEmissiveIntensity(0.0f);
                }
            }
            HUDObjectText h1 = GetHUDObjectTextByName("MyHUDObject1");
            HUDObjectText h2 = GetHUDObjectTextByName("MyHUDObject2");
            HUDObjectText h3 = GetHUDObjectTextByName("MyHUDObject3");
            HUDObjectText credits = GetHUDObjectTextByName("credits");

            // Wenn ein Objekt dieses Typs und dieses Namens gefunden werden
            // konnte, ist die Variable h nicht 'leer', also 'nicht null':
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

            /*
            // Platziere ein bildbasiertes HUD-Objekt:
            HUDObject screen = new HUDObjectImage("./App/Textures/Screen.png");
            screen.SetPosition(640f, 370f);               // Position in Pixeln (von links oben des Bildschirms aus gesehen)
            screen.Name = "MyHUDObject";                // Interner Name des Objekts
            screen.SetScale(128f, 128f);                // Skalierung des Bildes
            screen.SetColorEmissive(1.0f, 1.0f, 1.0f);  // Glühfarbe (RGB), die Intensität wird separat geregelt
            //AddHUDObject(screen);
            */
            // Platziere ein textbasiertes HUD-Objekt:


            HUDObjectText hName = new HUDObjectText("DOMINIK PASCAL TIL GAME");
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
            s1.Name = "scoreboard";
            s1.SetCharacterDistanceFactor(1.0f);
            s1.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s1);

            HUDObjectText s2 = new HUDObjectText("2#");
            s2.SetPosition(700f, 260f);
            s2.Name = "scoreboard";
            s2.SetCharacterDistanceFactor(1.0f);
            s2.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s2);


            HUDObjectText s3 = new HUDObjectText("3#");
            s3.SetPosition(700f, 300f);
            s3.Name = "scoreboard";
            s3.SetCharacterDistanceFactor(1.0f);
            s3.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s3);


            HUDObjectText s4 = new HUDObjectText("4#");
            s4.SetPosition(700f, 340f);
            s4.Name = "scoreboard";
            s4.SetCharacterDistanceFactor(1.0f);
            s4.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s4);


            HUDObjectText s5 = new HUDObjectText("5#");
            s5.SetPosition(700f, 380f);
            s5.Name = "scoreboard";
            s5.SetCharacterDistanceFactor(1.0f);
            s5.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s5);

            HUDObjectText s6 = new HUDObjectText("6#");
            s6.SetPosition(700f, 420f);
            s6.Name = "scoreboard";
            s6.SetCharacterDistanceFactor(1.0f);
            s6.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s6);

            HUDObjectText s7 = new HUDObjectText("7#");
            s7.SetPosition(700f, 460f);
            s7.Name = "scoreboard";
            s7.SetCharacterDistanceFactor(1.0f);
            s7.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s7);


            HUDObjectText s8 = new HUDObjectText("8#");
            s8.SetPosition(700f, 500f);
            s8.Name = "scoreboard";
            s8.SetCharacterDistanceFactor(1.0f);
            s8.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s8);


            HUDObjectText s9 = new HUDObjectText("9#");
            s9.SetPosition(700f, 540f);
            s9.Name = "scoreboard";
            s9.SetCharacterDistanceFactor(1.0f);
            s9.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s9);


            HUDObjectText s10 = new HUDObjectText("1O#");
            s10.SetPosition(678f, 580f);
            s10.Name = "scoreboard";
            s10.SetCharacterDistanceFactor(1.0f);
            s10.SetColor(1.0f, 0.0f, 0.0f);

            AddHUDObject(s10);






        }
    }
}
