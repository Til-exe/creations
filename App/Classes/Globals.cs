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
using System.Diagnostics;

namespace Gruppenprojekt.App.Classes
{
    internal class Globals
    {
        //public static int GamesCounter;
        public static bool gameRunning = true;
        public static float[] scores = new float[9];
        public static int Trys;
        public static float Score;
        public static int ReturnCode;
        public static float speed = 0.05f;
        public static bool Sprinting = false;
        public static float multiplikator = 1;
        public static float moveCameraX = 0;
        public static float moveCameraY = 2.5f;
        public static float moveCameraMultiplier = 1;


        
        public static string Cpath = @"./App/data/credits.txt";        
        public static string path = @"./App/data/data.txt";
        public static string[] Clines = File.ReadAllLines(Cpath);
        



        public static bool DisplayStartGameButton = true;
        public static bool DisplayOptionButton = true;
        public static bool DisplayLanguageButton = false;
        public static bool DisplayCreditsButton = true;
        public static bool DisplayScoreboardButton = false;
        public static bool DisplayLeaveButton = true;       
        public static int posWert;
        public static int posYWert;

        public static string StartButtonText = "";
        public static string OptionButtonText = "";
        public static string LanguageButtonText = "";
        public static string CreditsButtonText = "";
        public static string ScoreboardButtonText = "";
        public static string LeaveButtonText = "";
        public static string ActualScoreboardText = "";
        public static string SetLanguage = "English";



    }
    
}
