using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppenprojekt.App.Classes
{
    internal class Globals
    {
        public static bool gameRunning = true;
        public static float[] scores = new float[9];
#pragma warning disable CS0649 // Dem Feld "Globals.GamesCounter" wird nie etwas zugewiesen, und es hat immer seinen Standardwert von "0".
        public static int GamesCounter;
#pragma warning restore CS0649 // Dem Feld "Globals.GamesCounter" wird nie etwas zugewiesen, und es hat immer seinen Standardwert von "0".
        public static int Trys;
        public static int Score;
        public static string getInfoFromFile()
        {
            return null;
        }
        
            
        
    }
}
