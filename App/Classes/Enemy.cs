using KWEngine3.GameObjects;
using KWEngine3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using KWEngine3;
using KWEngine3.Audio;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System.Diagnostics;
using System.Threading;
using OpenTK.Windowing.Common.Input;
using Assimp;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Transactions;
using Gruppenprojekt.App.Menus;
using System.Security.Cryptography.X509Certificates;
using OpenTK.Platform.Windows;
using Gruppenprojekt.App.death_winscreen;

namespace Gruppenprojekt.App.Classes
{
    internal class Enemy : GameObject
    {
        Player p;
        Vector3 playerPos;
        RayIntersectionExt raycollision;
        GameObject objectHitByRay;
        Vector3 target;
        float distanceToObject;
        float timestampLastSighting = 0;
        Vector3 normal;
        static Vector3 collectableposlol;
        static bool OverridePathfinding = false;
        private const int MAXDIRECTIONS = 64;
        private Queue<Vector3> directions = new Queue<Vector3>(MAXDIRECTIONS);
        private float lastActionTime = 0;
        float cooldownDuration = 1.5f;

        public Enemy(string name, float x, float y, float z)
        {
            this.SetModel("EnemyClown");
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(1f, 1f, 1f);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetScale(2f, 2f,2f);
            this.SetColorEmissive(1, 1, 1, 0);
            this.SetHitboxToCapsule(Vector3.Zero, CapsuleHitboxType.Default);
            this.SetHitboxScale(0.25f, 1f, 1f);
            //this.SetHitboxScale(0.75f);
            p = CurrentWorld.GetGameObjectByName<Player>("Yasin");
            this.SetAnimationID(2);
        }

        public override void Act()
        {
            if (Globals.gameRunning) 
            {
                float distance;
                distance = GetDistanceTo(p);
                float maxDistance = 100f;
                float baseProximity = 1f - (distance / maxDistance);
                float proximityPercent;
                if (baseProximity <= 0.8f)
                {
                    proximityPercent = baseProximity * 0.8f;
                }
                else
                {
                    proximityPercent = 0.8f + (float)Math.Pow((baseProximity - 0.8f) / 0.2f, 2) * 0.2f;
                }
                double proxiround = Math.Round(proximityPercent, 2);
                Console.WriteLine($"Nähe des penisman: {proxiround}");
                if (WorldTime - lastActionTime >= cooldownDuration)
                {
                    Random rnd = new Random();
                    int rndsound = rnd.Next(1, 3);
                    if(rndsound == 1)
                    {
                        Audio.PlaySound(@"./App/Sounds/thump3.wav", false, (float)proxiround);
                        Console.WriteLine("sound 3 also 1 gemacht");
                        lastActionTime = WorldTime;
                    }
                    else if(rndsound == 2)
                    {
                        Audio.PlaySound(@"./App/Sounds/thump2.wav", false, (float)proxiround);
                        Console.WriteLine("sound 2 also 2 gemacht");
                        lastActionTime = WorldTime;
                    }
                    else if(rndsound == 3)
                    {
                        Audio.PlaySound(@"./App/Sounds/thump1.wav", false, (float)proxiround);
                        Console.WriteLine("sound 1 also 3 gemacht");
                        lastActionTime = WorldTime;
                    }
                }

                this.SetAnimationPercentageAdvance(0.005f);
               
                playerPos = p.Center;
                Vector3 raystart = this.Center;
                Vector3 rayDirection = HelperVector.GetDirectionFromVectorToVectorXZ(this.Center,playerPos);
                Vector3 myDirection = Vector3.Zero;
                FlowField f = CurrentWorld.GetFlowField();
                /* KAR: f nicht mehr mitbewegen!
                if (f != null)
                {
                    f.SetPosition(this.Position.X, this.Position.Z);
                }
                */

                if (Globals.FinalChase == true)
                {
                    Player.enemyspeedcap = false;
                    OverridePathfinding = false;
                    Console.WriteLine("attack [" + Globals.EnemySpeed + "]");                  //DEBUG ATTACK
                    timestampLastSighting = WorldTime;
                    TurnTowardsXZ(playerPos);
                    if (myDirection != Vector3.Zero)
                    {
                        MoveAlongVector(myDirection, Globals.EnemySpeed);                                //Attackgeschwindigkeit
                    }
                }





                List<RayIntersectionExt> results = HelperIntersection.RayTraceObjectsForViewVector(raystart, rayDirection, 40f, true, this, typeof(Wall), typeof(Player), typeof(Map));
                if (results.Count > 0)
                {
                    raycollision = results[0];
                    objectHitByRay = raycollision.Object;
                    distanceToObject = raycollision.Distance;
                    target = raycollision.IntersectionPoint;
                    normal = raycollision.SurfaceNormal;
                }
                if (f != null && f.Contains(playerPos) && f.Contains(this.Center))
                {
                    f.SetTarget(playerPos);

                }
                if (f.Contains(this.Center) && f.HasTarget)
                {
                    myDirection = f.GetBestDirectionForPosition(this.Center);
                }

               


                if (objectHitByRay == p && Globals.FinalChase == false)
                {
                    Player.enemyspeedcap = false;
                    OverridePathfinding = false;
                    Console.WriteLine("attack [" + Globals.EnemySpeed+ "]");                  //DEBUG ATTACK
                    timestampLastSighting = WorldTime;
                    TurnTowardsXZ(playerPos);
                    if (myDirection != Vector3.Zero)
                    {
                        MoveAlongVector(myDirection, Globals.EnemySpeed);
                        cooldownDuration = 0.5f;                                                        //Attackgeschwindigkeit
                    }
                }
               
                else if (timestampLastSighting + 4f > WorldTime && timestampLastSighting != 0)          //NOTIZ AN TIL: Wie lang kann der Gegner dich noch um Wände sehen und folgen
                {
                    Player.enemyspeedcap = false;
                    OverridePathfinding = false;
                    Console.WriteLine("not in sight still attack [" + Globals.EnemySpeed+ "]");       //DEBUG NOT IN SIGHT
                    if (myDirection != Vector3.Zero)
                    {
                        MoveAlongVector(myDirection, Globals.EnemySpeed);
                        cooldownDuration = 1.5f;
                    }
                }
                else if (OverridePathfinding == true)
                {
                    Player.enemyspeedcap = false;
                    FlowField pathfinding = CurrentWorld.GetFlowField();
                    if (pathfinding != null)
                    {
                        pathfinding.SetTarget(collectableposlol, true);
                        if (pathfinding.HasTarget && pathfinding.ContainsXZ(collectableposlol))
                        {
                            cooldownDuration = 0.5f;
                            Console.WriteLine("Aufsammeln erkannt und auf Weg [" + Globals.EnemySpeed+ "] ");
                            if(directions.Count >= MAXDIRECTIONS)
                            {
                                directions.Dequeue();
                            }

                            FlowFieldCell cell = pathfinding.GetCellForWorldPosition(this.Center);
                            // KAR: Die Zelle nur für die Durchschnittsrichtung berücksichtigen, wenn 
                            //      ihre Kosten unter 255 sind (also keine Wand dort ist).
                            /*if(cell.Cost < 255)
                            {
                                directions.Enqueue(pathfinding.GetBestDirectionForPosition(this.Position));
                            }*/
                            directions.Enqueue(pathfinding.GetBestDirectionForPosition(this.Center));
                            myDirection = GetAverageDirection();
                            if(HelperVector.GetDistanceBetweenVectorsXZ(this.Center, collectableposlol) <= 3f)
                            {
                                Console.WriteLine("angekommen bei location [" + Globals.EnemySpeed+ "]");
                                OverridePathfinding = false;
                                cooldownDuration = 1.5f;
                            }
                        }
                    }
                    if (myDirection != Vector3.Zero)
                    {
                        Player.enemyspeedcap = false;
                        MoveAlongVector(myDirection, Globals.EnemySpeed);
                    }
                    List<Intersection> intersections1 = GetIntersections();
                    foreach (Intersection intersection in intersections1)
                    {
                        MoveOffset(intersection.MTV);
                    }
                }
                else
                {
                    cooldownDuration = 1.5f;
                    Player.enemyspeedcap = false;
                    Move(Globals.EnemySpeed);                                                 //NOTIZ AN TIL HIER KANNST DU ROAMING GESCHWINDIGKEIT ANPASSEN (für difficulty)
                    Console.WriteLine("roaming [" + Globals.EnemySpeed+ "] ");               //DEBUG ROAMING
                    List<Intersection> intersections1 = GetIntersections();
                    foreach (Intersection intersection in intersections1)
                    {
                        MoveOffset(intersection.MTV);
                        DecideNewDirection();
                    }
                }
            List<Intersection> intersections = GetIntersections();
            foreach (Intersection intersection in intersections)            
            {
                //Aktivieren und Deaktivieren des Todes aka deathreal? | Steht nun in Globals.cs
                MoveOffset(intersection.MTV);
                GameObject collider = intersection.Object;
                if (collider is Player && Globals.deathreal && !Globals.debugMode)            //Wird bei GameOver ausgeführt
                {
                    Console.WriteLine("skill issue");
                    Player.safeScore();
                        death1 deathscreen = new death1();
                        Window.SetWorld(deathscreen);
                }
            }
            }
        }

        private HashSet<string> blockedDirections = new HashSet<string>();
        private float unblockTime = 0;
        private void DecideNewDirection()
        {
            int costNorth = 255;
            int costSouth = 255;
            int costEast = 255;
            int costWest = 255;

            FlowField pathfinding = CurrentWorld.GetFlowField();
            if (pathfinding != null)
            {
                FlowFieldCell cell = pathfinding.GetCellForWorldPosition(this.Center);
                if (cell != null)
                {
                    FlowFieldCell neighbourNorth = cell.GetNeighbourCellAtOffset(0, -1);
                    FlowFieldCell neighbourSouth = cell.GetNeighbourCellAtOffset(0, 1);
                    FlowFieldCell neighbourWest = cell.GetNeighbourCellAtOffset(-1, 0);
                    FlowFieldCell neighbourEast = cell.GetNeighbourCellAtOffset(1, 0);

                    if (neighbourNorth != null && !blockedDirections.Contains("North"))
                        costNorth = neighbourNorth.Cost;
                    if (neighbourSouth != null && !blockedDirections.Contains("South"))
                        costSouth = neighbourSouth.Cost;
                    if (neighbourWest != null && !blockedDirections.Contains("West"))
                        costWest = neighbourWest.Cost;
                    if (neighbourEast != null && !blockedDirections.Contains("East"))
                        costEast = neighbourEast.Cost;

                    List<(string direction, int cost, Vector3 target)> directions = new List<(string, int, Vector3)>
                    {
                        ("North", costNorth, new Vector3(0, 0, -1)),
                        ("South", costSouth, new Vector3(0, 0, 1)),
                        ("West", costWest, new Vector3(-1, 0, 0)),
                        ("East", costEast, new Vector3(1, 0, 0))
                    };
                    directions = directions.OrderBy(d => d.cost).ToList();
                    int minCost = directions.First().cost;
                    var bestDirections = directions.Where(d => d.cost == minCost).ToList();
                    var chosenDirection = bestDirections[new Random().Next(bestDirections.Count)];
                    this.TurnTowardsXZ(this.Center + chosenDirection.target);
                    UpdateBlockedDirections(chosenDirection.direction);
                }
                else
                {
                    Console.WriteLine("Digga was IST PASSIERT");
                }
            }
            UnblockDirectionsIfNeeded();
        }
        private void UpdateBlockedDirections(string chosenDirection)
        {
            switch (chosenDirection)
            {
                case "North":
                    blockedDirections.Add("South");
                    break;
                case "South":
                    blockedDirections.Add("North");
                    break;
                case "East":
                    blockedDirections.Add("West");
                    break;
                case "West":
                    blockedDirections.Add("East");
                    break;
            }
            unblockTime = WorldTime;
        }
        private void UnblockDirectionsIfNeeded()
        {
            if (WorldTime >= unblockTime)
            {
                blockedDirections.Clear();
            }
        }

        public static void Collectabletarget(Vector3 collectablepos)
        {
            Console.WriteLine($"Collectable target: {collectablepos}");
            collectableposlol = collectablepos;
            OverridePathfinding = true;
            
        }

        // test kar
        private Vector3 GetAverageDirection()
        {
            Vector3 dir = Vector3.Zero;
            foreach(Vector3 v in directions)
            {
                dir += v;
            }
            return dir / directions.Count;
        }
    }
}