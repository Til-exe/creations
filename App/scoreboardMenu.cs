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
        public override void Act()
        {

            HUDObjectText leave = GetHUDObjectTextByName("leave");
            HUDObjectText clear = GetHUDObjectTextByName("clear");
            HUDObjectText English = GetHUDObjectTextByName("English");
            HUDObjectText Spanisch = GetHUDObjectTextByName("Spanisch");
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
                if (clear.IsMouseCursorOnMe() == true)
                {
                    clear.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    clear.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && clear.IsMouseCursorOnMe() == true)
                {
                    
                }
            }
            if (English != null)
            {
                if (English.IsMouseCursorOnMe() == true)
                {
                    English.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    English.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && English.IsMouseCursorOnMe() == true)
                {
                    
                }
            }
            if (Spanisch != null)
            {
                if (Spanisch.IsMouseCursorOnMe() == true)
                {
                    Spanisch.SetColorEmissiveIntensity(1.5f);
                }
                else
                {
                    Spanisch.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && Spanisch.IsMouseCursorOnMe() == true)
                {
                    
                }
            }            
        }


        public override void Prepare()
        {



            HUDObjectText h1 = new HUDObjectText("BACK");
            h1.SetPosition(50f, 80f);
            h1.Name = "leave";
            h1.SetCharacterDistanceFactor(1.0f);
            h1.SetColor(1.0f, 0.0f, 0.0f);
            h1.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(h1);


            HUDObjectText clear = new HUDObjectText("clear");
            clear.SetPosition(160f, 250f);
            clear.Name = "clear";
            clear.SetCharacterDistanceFactor(1.0f);
            clear.SetColor(1.0f, 0.0f, 0.0f);
            clear.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(clear);


            HUDObjectText English = new HUDObjectText("English");
            English.SetPosition(160f, 300f);
            English.Name = "English";
            English.SetCharacterDistanceFactor(1.0f);
            English.SetColor(1.0f, 0.0f, 0.0f);
            English.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(English);

            HUDObjectText Spanisch = new HUDObjectText("Spanisch");
            Spanisch.SetPosition(160f, 350f);
            Spanisch.Name = "Spanisch";
            Spanisch.SetCharacterDistanceFactor(1.0f);
            Spanisch.SetColor(1.0f, 0.0f, 0.0f);
            Spanisch.SetColorEmissive(1.0f, 1.0f, 1.0f);

            AddHUDObject(Spanisch);


            /*
            string filePath = @"F:\.Programming\Repositys\Gruppenprojekt\App\data\scoreboardSettings.txt";
            //filePath = @"C:\Users\Til.Stuckenberg\source\GAME\App\data\data.txt";
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
                Console.WriteLine("Inhalt der Datei (als Ganzes):");
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine(fileContent);

                Console.WriteLine("\n---\n");

                // Methode 2: Datei zeilenweise einlesen
                Console.WriteLine("Inhalt der Datei (zeilenweise):");
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {

            }*/




        }        
    }
}
