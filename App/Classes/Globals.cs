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
        public static bool gameRunning = true;
        public static float totalScore = 0;
        public static int Trys;
        public static float Score;
        public static int ReturnCode;
        public static float speed = 0.05f;
        public static bool Sprinting = false;
        public static float multiplikator = 1;
        public static float moveCameraX = 0;
        public static float moveCameraY = 2.5f;
        public static float moveCameraMultiplier = 1;
        public static bool bgAnimation = true;
        public static string choseGamemode = "Tutorial";
        public static int SpawnColByDeath = 1;
        public static bool MapOpen = false;


        public static string Cpath = @"./App/data/credits.txt";        
        public static bool deathreal = false;
        public static bool GameEnd = false;
        public static bool EndReal = true;
        public static string path = @"./App/data/data.txt";
        public static string timePath = @"./App/data/time.txt";


        public static int posWert;
        public static int posYWert;

        public static bool DisplayStartGameButton = true;
        public static bool DisplayOptionButton = true;
        public static bool DisplayLanguageButton = false;
        public static bool DisplayCreditsButton = true;
        public static bool DisplayScoreboardButton = false;
        public static bool DisplayLeaveButton = true;

        public static string enabledText = "";
        public static string disabledText = "";
        public static string backText = "";
        public static string StartButtonText = "";
        public static string OptionButtonText = "";
        public static string LanguageButtonText = "";
        public static string CreditsButtonText = "";
        public static string ScoreboardButtonText = "";
        public static string LeaveButtonText = "";
        public static string ActualScoreboardText = "";
        public static string SetLanguage = "English";
        public static string displayCounter = "";
        public static string choseGamemodeText = "";

        public static int fensterBreite = 1280;     
        //public static int fensterBreite = 1920;
        public static int fensterHoehe = 720;
        //public static int fensterHoehe = 1080;

        public static bool TutorialComplete = false;
        public static bool InteractionCollectable = false;
        public static int TutorialProgress = 0;
    }
}