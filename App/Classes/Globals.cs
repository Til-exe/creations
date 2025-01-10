using System.Security.Cryptography.X509Certificates;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Collections.Immutable;
using System.Collections.Generic;
using Gruppenprojekt.App.Classes;
using System.Diagnostics.Metrics;
using KWEngine3.GameObjects;
using OpenTK.Mathematics;
using System.Diagnostics;
using KWEngine3.Audio;
using System.Linq;
using System.IO;
using KWEngine3;
using System;

namespace Gruppenprojekt.App.Classes
{
    internal class Globals
    {                
        public static bool gameRunning = true;                          //gameRunning - Wenn dieses Bool auf False ist wird das gesamte Spiel pausiert        
        public static bool Sprinting = false;                           //Sprinitng - Indikator dafür ob der Spieler Sprintet        
        public static string choseGamemode = "Tutorial";                //choseGamemode - gibt an welcher Spielmodus ausgewählt ist
        public static string SetLanguage = "English";                   //SetLanguage - gibt an welche Sprache angezeigt werden soll
        public static float Score;                                      //Score - ist der Punktestand, dieser wird aus allen eingesammelten Orbs berechnet        
        public static int Trys;                                         //gibt an wie viele Spiele bereits bei Laufendem Programm gespielt wurden        
        public static int ReturnCode;                                   //ReturnCode - ist ein Wert der dafür da ist funktionen zu aktivieren wenn in den Optionen ein bestimmter Code eingegeben wurde        
        public static int SpawnColByDeath = 1;                          //SpawnColByDeath - gibt an wie viele Orbs bei einsammeln eines Orbes im 'Infinit' modus erstellt werden sollen
        public static float speed = 0.05f;                              //speed - ist die Geschwindingkeit des Spielers        
        public static int ColCount = 10;
        public static float EnemySpeed;                        //EnemySpeed - ist die Geschwindigkeit des Enemy        
        public static float totalScore;                                 //totalScore - ist ein Wert der aus allen eingesammelten Orbs berechnet wird, bei laufendem Programm            
        public static float multiplikator = 1f;                         //totalScore - ist ein Wert der aus allen eingesammelten Orbs berechnet wird, bei laufendem Programm        
        public static float moveCameraX = 0f;                           //moveCameraX        
        public static float moveCameraY = 2.5f;                         //moveCameraY        
        public static float moveCameraMultiplier = 1f;                  //moveCameraMultiplier        
        public static bool EndReal = true;                              //EndReal
        public static bool GameEnd = false;                             //GameEnd
        public static bool MapOpen = false;                             //MapOpen - Indikator dafür ob die Karte geöffnet ist
        public static bool deathreal = true;                           //deathreal - Indikator dafür ob der Enemy das spiel bei Collision beenden soll
        public static bool bgAnimation = true;                          //bgAnimation - gibt an ob der Hintergrund im Startmenu animiert sein soll oder nicht        
        public static bool TutorialComplete = false;                    //TutorialComplete - gibt an ob das Tutorial abgeschlossen wurde
        public static bool debugMode = true;
        public static bool UseLevelProgess = true;                      //UseLevelProgress - gibt an ob die gesammelten Level Vorteile brigen sollen
        
        public static int TutorialProgress = 0;                         //TutorialProgress - gibt an wie weit das Tutorial abgeschlossen wurde
        public static int Experience = 0;                               //Experience - gibt die Erfahrungspunkte an die gesammelt wurden
        public static int Level = 1;                                    //Level - gibt das Gesammelte Level an

        public static int posWert;                                      //gibt an wie bestimmte Texte positioniert sind                             
        public static int posYWert;

        public static string Cpath = @"./App/data/credits.txt";         //Cpath - allgemeiner Pfad für die "credits.txt" datei        
        public static string path = @"./App/data/data.txt";             //path - allgemeiner Pfad für die "data.txt" datei
        public static string timePath = @"./App/data/time.txt";         //timePath - allgemeiner Pfad für die "time.txt" datei

        public static bool DisplayStartGameButton = true;               //Diese Boolean's geben an ob die genannten Button angezeigt werden sollen
        public static bool DisplayOptionButton = true;
        public static bool DisplayLanguageButton = false;
        public static bool DisplayCreditsButton = true;
        public static bool DisplayLevelButton = false;
        public static bool DisplayScoreboardButton = false;
        public static bool DisplayLeaveButton = true;

        public static string enabledText = "";                          //Diese String's sind dafür da um das Spiel in Verschiedenen Sprachen darstellen zu können
        public static string disabledText = "";
        public static string backText = "";
        public static string StartButtonText = "";
        public static string OptionButtonText = "";
        public static string LanguageButtonText = "";
        public static string CreditsButtonText = "";
        public static string ScoreboardButtonText = "";
        public static string LevelButtonText = "";
        public static string LeaveButtonText = "";
        public static string ActualScoreboardText = "";
        public static string displayCounter = "";
        public static string choseGamemodeText = "";

        public static int fensterBreite = 1280;                         //gibt die maße des Spiel Fensters an
        public static int fensterHoehe = 720;
    }
}