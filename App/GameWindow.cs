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
namespace Gruppenprojekt.App
{
    public class GameWindow : GLWindow
    {

        public GameWindow() : base(
            
            Globals.fensterBreite,                               // Fensterbreite
            Globals.fensterHoehe,                                // Fensterhöhe
            true,                               // VSync?
            PostProcessingQuality.Standard,     // Qualität der PP-Effekte (Standard für iGPUs)
            WindowMode.BorderlessWindow)                 // Fensterdekorationsmodus
        {

            this.Title = "Its Stolen";      
            
            GameWorldStart game = new GameWorldStart();
            GameWorldStartMenu StartMenu = new GameWorldStartMenu();
            IntroScreen intro = new IntroScreen();
            this.SetWorld(intro);
            Console.WriteLine("[CONSOLE] Game Start");

        }
    }
}