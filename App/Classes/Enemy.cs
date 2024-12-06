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
        bool Süd = true;
        bool Nord = true;
        bool Ost = true;
        bool West = true;
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
            Move(0.005f);



































































            

           

            List<Intersection> intersections = GetIntersections();
            foreach (Intersection intersection in intersections)
            {
                MoveOffset(intersection.MTV);
                DecideNewDirection();

            }
        }

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


                    if (neighbourNorth != null)
                    {
                        costNorth = neighbourNorth.Cost;
                    }
                    if (neighbourSouth != null)
                    {
                        costSouth = neighbourSouth.Cost;
                    }
                    if (neighbourWest != null)
                    {
                        costWest = neighbourWest.Cost;
                    }
                    if (neighbourEast != null)
                    {
                        costEast = neighbourEast.Cost;
                    }




                    if (costNorth <= costSouth && costNorth <= costEast && costNorth <= costWest && Nord == true)
                    {
                        this.TurnTowardsXZ(this.Position + new Vector3(0, 0, -1));
                        Console.WriteLine("Norden");
                        Süd = false;
                        Nord = true;
                        //Ost = true;
                        //West = true;
                    }
                    else if (costSouth <= costNorth && costSouth <= costEast && costSouth <= costWest && Süd == true)
                    {
                        this.TurnTowardsXZ(this.Position + new Vector3(0, 0, 1));
                        Console.WriteLine("Süden");
                        Nord = false;
                        Süd = true;
                        //Ost = true;
                        //West = true;
                    }
                    else if (costEast <= costNorth && costEast <= costSouth && costEast <= costWest && Ost == true)
                    {
                        this.TurnTowardsXZ(this.Position + new Vector3(-1, 0, 0));
                        Console.WriteLine("Osten");
                        West = false;
                        //Nord = true;
                        //Süd = true;
                        Ost = true;
                    }
                    else if (costWest <= costNorth && costWest <= costSouth && costWest <= costEast && West == true)
                    {
                        this.TurnTowardsXZ(this.Position + new Vector3(1, 0, 0));
                        Console.WriteLine("Westen");
                        Ost = false;
                        West = true;
                        //Nord = true;
                        //Süd = true;
                    }
                    else
                    {
                        Console.WriteLine("keine wand in sicht");
                    }


                }
            }
        }
    }
}
