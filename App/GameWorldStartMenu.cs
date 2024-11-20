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



        }
    }
}
