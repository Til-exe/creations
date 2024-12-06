using KWEngine3.GameObjects;
using KWEngine3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

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
            this.SetScale(1, 5, 1);




        }

        public override void Act()
        {








































































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
                        int costNorth = neighbourNorth.Cost;
                    }
                    if (neighbourSouth != null)
                    {
                        int costNorth = neighbourNorth.Cost;
                    }
                    if (neighbourWest != null)
                    {
                        int costNorth = neighbourNorth.Cost;
                    }
                    if (neighbourEast != null)
                    {
                        int costNorth = neighbourNorth.Cost;
                    }
                }
            }
        }
    }
}
