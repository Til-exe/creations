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
using Assimp;

namespace Gruppenprojekt.App.Classes
{
    internal class Enemy: GameObject
    {
        Player p;
        Vector3 playerPos;
        RayIntersectionExt raycollision;
        GameObject objectHitByRay;
        Vector3 target;
        float distanceToObject;
        float timestampLastSighting = 0;
        Vector3 normal;
       

        public Enemy(string name, float x, float y, float z) {
            this.Name = name;
            this.SetPosition(x, y, z);
            this.SetColor(0f, 0f, 1f);
            this.IsCollisionObject = true;
            this.IsShadowCaster = true;
            this.SetScale(1, 2, 1);

            p = CurrentWorld.GetGameObjectByName<Player>("Yasin");
        }

        public override void Act()
        {
            Vector3 raystart = this.Center;
            Vector3 rayDirection = this.LookAtVector;
            Vector3 myDirection = Vector3.Zero;
            playerPos = p.Position;
            FlowField f = CurrentWorld.GetFlowField();
            TurnTowardsXZ(playerPos);

            List<RayIntersectionExt> results = HelperIntersection.RayTraceObjectsForViewVector(raystart, rayDirection, 6f, true, this, typeof(Wall), typeof(Player));

            if(results.Count > 0)
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
                Console.WriteLine("if");
                timestampLastSighting = WorldTime;
                             
                if (myDirection != Vector3.Zero)
                {
                    MoveAlongVector(myDirection, 0.05f);
                    
                }
            }
            else if (timestampLastSighting + 5 > WorldTime && timestampLastSighting != 0)
            {
                Console.WriteLine("else");
                                 
                if (myDirection != Vector3.Zero)
                {
                    MoveAlongVector(myDirection, 0.05f);

                }
                
            }











                List<Intersection> intersections = GetIntersections();
                foreach (Intersection intersection in intersections)
                {
                    MoveOffset(intersection.MTV);
                }
            
        }
    }
}
