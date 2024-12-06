using KWEngine3.GameObjects;
using KWEngine3.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using KWEngine3;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Gruppenprojekt.App.Classes
{
    internal class Enemy: GameObject
    {
        Player p;
        public Enemy(string name, float x, float y, float z) {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(0f, 0f, 1f);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetScale(1, 5, 1);

            p = CurrentWorld.GetGameObjectByName<Player>("Yasin");
        }

        public override void Act()
        {

            Vector3 playerPos = p.Position;
            Vector3 myDirection = Vector3.Zero; 
            FlowField f = CurrentWorld.GetFlowField();

            if (f != null && f.Contains(playerPos) && f.Contains(this.Position)) {
            
            f.SetTarget(playerPos);
            }

            if (f.Contains(this.Position) && f.HasTarget) { 
            myDirection = f.GetBestDirectionForPosition(this.Position);
            }

            if (myDirection != Vector3.Zero)
            {
                MoveAlongVector(myDirection, 0.05f); 

            }

            List<Intersection> intersections = GetIntersections();
            foreach (Intersection intersection in intersections)
            {
                MoveOffset(intersection.MTV);
            }
        }
    }
}
