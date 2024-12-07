using KWEngine3.GameObjects;
using KWEngine3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using System.Security.Cryptography.X509Certificates;

namespace Gruppenprojekt.App.Classes
{
    internal class Enemy: GameObject
    {
        public Enemy(string name, float x, float y, float z) {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(0f, 0f, 1f);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetScale(1, 2, 1);




        }

        public override void Act()
        {
            Move(0.1f);



































































            

           

            List<Intersection> intersections = GetIntersections();
            foreach (Intersection intersection in intersections)
            {
                MoveOffset(intersection.MTV);
                DecideNewDirection();
            }
        }
        private HashSet<string> blockedDirections = new HashSet<string>();
        private float unblockTime = 0f;
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
            unblockTime = WorldTime + 5f;
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

