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
    public class IntroScreen : World
    {
        int hochzähler = 0;
        int hochzähler1 = 0;
        float tScale = 1.0f;
        bool maxGerreicht = true;
        bool toggleSave = true;
        bool adminmin = false;

        bool allesStoppt = true;
        bool bool1 = false;
        float titleOpacity = 0;
        float startOpacity = 0;
        public override void Act()
        {
            
            HUDObjectText title = GetHUDObjectTextByName("itSteals");
            HUDObjectText start = GetHUDObjectTextByName("start");
            HUDObjectText save = GetHUDObjectTextByName("save");
            HUDObjectText add = GetHUDObjectTextByName("add");
            HUDObjectTextInput h = GetHUDObjectTextInputByName("input");


            //bei start zählt hoch
            //opacity von start wird damit erhöht
            //wenn bestimmter wert
            //opacity stoppt
            //neuer zähler
            //start zählt hoch
            //opacity zählt mit hoch
            //wenn bestimmter werd
            //alles stoppt

            if (allesStoppt){
                if(titleOpacity != -1f && !bool1)
                {
                    titleOpacity += 0.003f;
                    title.SetOpacity(titleOpacity);
                }
                if(titleOpacity > 1f && !bool1)
                {
                    bool1 = true;
                }
                if (startOpacity != -1f && bool1 == true) 
                {
                    startOpacity += 0.003f;
                    start.SetOpacity(startOpacity);

                }
                if(startOpacity > 1f && bool1 == true)
                {
                    allesStoppt = false;
                }
            }
            if(!allesStoppt && !start.IsMouseCursorOnMe())
            {                
                float time = WorldTime;
                float amplitude = 1f;
                float frequency = 2f;
                float sinusValue = (float)Math.Sin(frequency * time);
                float newY = 1f + amplitude * sinusValue;
                start.SetOpacity(newY);
            }            
            if(Keyboard.IsKeyDown(Keys.Space)) 
            {
                titleOpacity = 1f;
                startOpacity = 1f;
            }

            if (start != null)
            {
                if (start.IsMouseCursorOnMe() == true)
                {
                    start.SetColorEmissiveIntensity(1.0f);
                }
                else
                {
                    start.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && start.IsMouseCursorOnMe() == true)
                {
                    
                    GameWorldStartMenu gwo = new GameWorldStartMenu();
                    Window.SetWorld(gwo);

                    KWEngine3.Audio.Audio.StopAllSound();
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);

                }
            }
            if(Keyboard.IsKeyPressed(Keys.Escape))
            {
                //Window.Close();
            }
            if (Keyboard.IsKeyPressed(Keys.Enter
                ))
            {
                GameWorldStartMenu gwo = new GameWorldStartMenu();
                Window.SetWorld(gwo);

                KWEngine3.Audio.Audio.StopAllSound();
                KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
            }
            if (save != null)
            {
                if (save.IsMouseCursorOnMe() == true)
                {
                    save.SetColorEmissiveIntensity(1.0f);
                }
                else
                {
                    save.SetColorEmissiveIntensity(0.0f);
                }
                if ( Mouse.IsButtonPressed(MouseButton.Left) && save.IsMouseCursorOnMe() == true && Keyboard.IsKeyDown(Keys.LeftShift) )
                {
                    adminmin = true;
                    if (toggleSave)
                    {
                        add.SetPosition(30, Globals.fensterHoehe - 90);
                        for (int i = 0; i < admins.Count; i++) { admins[i].SetPosition(30, Globals.fensterHoehe - (120 + 30 * i)); }
                    }
                    
                }                
                else if (Mouse.IsButtonPressed(MouseButton.Left) && save.IsMouseCursorOnMe() == true)
                {                    
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);
                    if (toggleSave && !adminmin) 
                    {
                        add.SetPosition(30, Globals.fensterHoehe - 90);
                        for (int i = 0;i < user.Count; i++) { user[i].SetPosition(30, Globals.fensterHoehe - (120 + 30 * i)); }
                    }
                    else
                    {
                        add.SetPosition(-1000, -1000);
                        for(int i = 0;i < user.Count; i++) { user[i].SetPosition(-1000, -1000); }
                        for (int i = 0; i < admins.Count; i++) { admins[i].SetPosition(-1000, -1000); }

                    }
                    toggleSave = !toggleSave;
                    
                    adminmin = false;
                }
            }
            if (add != null)
            {
                if (add.IsMouseCursorOnMe() == true)
                {
                    add.SetColorEmissiveIntensity(1.0f);
                }
                else
                {
                    add.SetColorEmissiveIntensity(0.0f);
                }
                if (Mouse.IsButtonPressed(MouseButton.Left) && add.IsMouseCursorOnMe() == true && adminmin)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                    if (admins.Count < 10)
                    {
                        HUDObjectText a = new HUDObjectText("A:" + (admins.Count + 1));
                        a.SetScale(25f);
                        a.SetPosition(30, Globals.fensterHoehe - (120 + 30 * admins.Count));
                        a.SetColor(1, 0, 0);
                        AddHUDObject(a);
                        admins.Add(a);
                    }
                }
                else if (Mouse.IsButtonPressed(MouseButton.Left) && add.IsMouseCursorOnMe() == true)
                {
                    KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/basicClick.wav", false, 0.2f);                    
                    if (user.Count < 10)
                    {
                        HUDObjectText u = new HUDObjectText("U:" + (user.Count + 1));
                        u.SetScale(25f);
                        u.SetPosition(30, Globals.fensterHoehe - (120 + 30 * user.Count));
                        u.SetColor(1, 0, 0);
                        u.SetColorEmissive(1.0f, 1.0f, 1.0f);
                        AddHUDObject(u);
                        user.Add(u);
                    }

                }
            }
            for (int i = 0; i < user.Count; i++) {
                if (user[i] != null)
                {
                    if (user[i].IsMouseCursorOnMe() == true)
                    {
                        user[i].SetColorEmissiveIntensity(1.0f);
                    }
                    else
                    {
                        user[i].SetColorEmissiveIntensity(0.0f);
                    }
                    if (Mouse.IsButtonPressed(MouseButton.Left) && user[i].IsMouseCursorOnMe() == true)
                    {
                        KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/on.wav", false, 0.2f);
                        if(adminmin)
                        {
                        }
                        else
                        {

                        }
                    }
                    else if (Mouse.IsButtonPressed(MouseButton.Right) && user[i].IsMouseCursorOnMe() == true)
                    {
                        KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/off.wav", false, 0.2f);
                        h.GetFocus(false);
                        h.SetText("");
                        h.SetPosition(200, Globals.fensterHoehe - (120 + 30 * i));

                        user[i].SetText("U:" + h.Text);
                    }
                }

            }


            // Wenn ein Objekt dieses Typs und dieses Namens gefunden werden
            // konnte, ist die Variable h nicht 'leer', also 'nicht null':
            if (h != null)
            {
                if (
                    h.IsMouseCursorOnMe() == true &&
                    Mouse.IsButtonPressed(MouseButton.Left) == true &&
                    h.HasFocus == false
                )
                {
                    h.SetText("");       // vorherigen Textinhalt löschen
                    h.SetColor(1, 1, 0); // Farbe zu gelb verändern
                    h.GetFocus();        // Texteingabefeld erfragt den Fokus
                }
            }
        }
        private List<HUDObjectText> user = new List<HUDObjectText>();
        private List<HUDObjectText> admins = new List<HUDObjectText>();
        public override void Prepare()
        {
            if(Globals.TutorialComplete)
            {
                Globals.choseGamemode ="Normal"; 
            }
            else
            {
                Globals.choseGamemode = "Tutorial";
            }
            
            KWEngine3.Audio.Audio.PlaySound(@"./App/Sounds/IntroMusic1.wav", false, 0.06f);
            HUDObjectText title = new HUDObjectText("ITS STOLEN");
            title.Name = "itSteals";
            title.SetScale(120);
            title.SetPosition(Globals.fensterBreite/2,Globals.fensterHoehe/2-100);
            title.SetTextAlignment(TextAlignMode.Center);
            title.SetColor(1, 0, 0);
            AddHUDObject(title);

            HUDObjectText start = new HUDObjectText("Start");
            start.Name = "start";
            start.SetScale(50);
            start.SetPosition(Globals.fensterBreite / 2, Globals.fensterHoehe / 2 + 100f);
            start.SetTextAlignment(TextAlignMode.Center);
            start.SetColor(1, 0, 0);
            start.SetOpacity(0);
            start.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(start);

            HUDObjectText save = new HUDObjectText("ACCOUNT");
            save.Name = "save";
            save.SetScale(30f);
            save.SetPosition(10, Globals.fensterHoehe-50);
            save.SetColor(1, 0, 0);
            save.SetColorEmissive(1.0f, 1.0f, 1.0f);
            //AddHUDObject(save);

            HUDObjectTextInput h = new HUDObjectTextInput("Name..");
            h.SetPosition(200, Globals.fensterHoehe - (120 + 30 * user.Count));
            h.Name = "input";
            h.SetColor(1.0f, 1.0f, 1.0f);
            h.CursorBehaviour = KeyboardCursorBehaviour.Fade;
            h.CursorType = KeyboardCursorType.Underscore;
            //AddHUDObject(h);

            HUDObjectText add = new HUDObjectText("add +");
            add.Name = "add";
            add.SetScale(25f);
            add.SetPosition(-1000, -1000);
            add.SetColor(1, 0, 0);
            add.SetColorEmissive(1.0f, 1.0f, 1.0f);
            AddHUDObject(add);

        }
        protected override void OnWorldEvent(WorldEvent e)
        {
            if (e.GeneratedByInputFocusLost == true)
            {
                // Objekt erfragen, das das Event ausgelöst hat:
                // (Im Feld 'Tag' des Events befindet sich die HUDObjectTextInput-
                // Instanz, die das Event ursprünglich ausgelöst hat)
                HUDObjectTextInput h = e.Tag as HUDObjectTextInput;
                if (e.Description == "[HUDObjectTextInput|CONFIRM]")
                {
                    // Wenn die Bezeichnung "CONFIRM" enthält, kann man an dieser 
                    // Stelle sicher sein, dass die Eingabe erfolgreich war.   

                    // Eingabefokus lösen:
                    h.ReleaseFocus();
                }
                else if (e.Description == "[HUDObjectTextInput|ABORT]")
                {
                    // Andernfalls wäre die Eingabe hier wegen eines Abbruchs
                    // beendet worden.
                    // Eingabefokus lösen:
                    h.ReleaseFocus();
                }
                else
                h.SetColor(1, 1, 1); // Farbe zurück auf weiß setzen
            }
        }

    }
}
