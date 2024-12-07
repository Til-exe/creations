using Gruppenprojekt.App.Classes;
using KWEngine3;
using System.Runtime.CompilerServices;

namespace Gruppenprojekt.App
{
    public class GameWindow : GLWindow
    {
        public GameWindow() : base(
            Globals.fensterBreite,                               // Fensterbreite
            Globals.fensterHoehe,                                // Fensterhöhe
            true,                               // VSync?
            PostProcessingQuality.Standard,     // Qualität der PP-Effekte (Standard für iGPUs)
            WindowMode.Default)                 // Fensterdekorationsmodus
        {
            //this.Title = "My infamous game title";
            
            GameWorldStart gws = new GameWorldStart();
            GameWorldStartMenu sm = new GameWorldStartMenu();
            this.SetWorld(sm);
        }
    }
}
