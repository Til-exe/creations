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


        public Enemy(string name, float x, float y, float z)
        {
            this.SetModel("Pascal");
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(0f, 0f, 0f);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetScale(1, 2, 1);

            p = CurrentWorld.GetGameObjectByName<Player>("Yasin");
        }

        public override void Act()
        {
            if (Globals.gameRunning) { 
            Vector3 raystart = this.Center;
            Vector3 rayDirection = this.LookAtVector;
            Vector3 myDirection = Vector3.Zero;
            playerPos = p.Position;
            FlowField f = CurrentWorld.GetFlowField();
                if (f != null)
                {                    
                     f.SetPosition(this.Position.X, this.Position.Z);                    
                }
                List<RayIntersectionExt> results = HelperIntersection.RayTraceObjectsForViewVector(raystart, rayDirection, 14f, true, this, typeof(Wall), typeof(Player));
            if (results.Count > 0)
            {
                raycollision = results[0];  //definiert erstes objekt welches im ray getroffen wird 
                objectHitByRay = raycollision.Object; // object welches getroffen wurde 
                distanceToObject = raycollision.Distance;  // Distanz zwischen Strahl-Startposition und dem Treffer:
                target = raycollision.IntersectionPoint; // Genaue Trefferposition:
                normal = raycollision.SurfaceNormal;       // Ebenenvektor der Oberfläche, die vom Strahl getroffen wurde:
            }
            if (f != null && f.Contains(playerPos) && f.Contains(this.Position))
            {
                f.SetTarget(playerPos);
            }
            if (f.Contains(this.Position) && f.HasTarget)
            {
                myDirection = f.GetBestDirectionForPosition(this.Position);
            }
            if (objectHitByRay == p)
            {
                Console.WriteLine("attack");
                timestampLastSighting = WorldTime;
                TurnTowardsXZ(playerPos);
                if (myDirection != Vector3.Zero)
                {
                    MoveAlongVector(myDirection, 0.05f);                                //Attackgeschwindigkeit
                }
            }
            else if (timestampLastSighting + 4f > WorldTime && timestampLastSighting != 0)          //NOTIZ AN TIL: Wie lang kann der Gegner dich noch um Wände sehen und folgen
            {
                Console.WriteLine("not in sight still attack");
                if (myDirection != Vector3.Zero)
                {
                    MoveAlongVector(myDirection, 0.05f);
                }
            }
            else                      
            {
                Move(0.1f);                                                 //NOTIZ AN TIL HIER KANNST DU ROAMING GESCHWINDIGKEIT ANPASSEN (für difficulty)
                Console.WriteLine("roaming");
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
                //ZUM AKTIVIEREN UND DEAKTIVIEREN DES TODES | Steht nun in Globals.cs
                MoveOffset(intersection.MTV);
                GameObject collider = intersection.Object;
                if (collider is Player && Globals.deathreal)            //WIRD AUSGEFÜHRT BEI TOT
                {
                    Console.WriteLine("skill issue");
                    Player.gotoHauptmenu();
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
                FlowFieldCell cell = pathfinding.GetCellForWorldPosition(this.Position);
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
                    this.TurnTowardsXZ(this.Position + chosenDirection.target);
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
            unblockTime = WorldTime + 3f;
        }
        private void UnblockDirectionsIfNeeded()
        {
            if (WorldTime >= unblockTime)
            {
                blockedDirections.Clear();
            }
        }
    }
}