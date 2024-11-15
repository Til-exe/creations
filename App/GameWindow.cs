using KWEngine3;

namespace Gruppenprojekt.App
{
    public class GameWindow : GLWindow
    {
        public GameWindow() : base(
            1280,                               // Fensterbreite
            720,                                // Fensterhöhe
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
