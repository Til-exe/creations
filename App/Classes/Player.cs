using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace Gruppenprojekt.App.Classes
{
    public class Player : GameObject
    {
        public Player(string name,float x, float y, float z ) {
        this.Name = name;
        this.SetPosition(x,y,z);
        this.SetColor(1, 0, 0);
        
        
        
        }

        public override void Act()
        {

            int forward = 0;
            int strafe = 0;
            if (Keyboard.IsKeyDown(Keys.W)) {
                forward += 1;  
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                strafe += 1;
            }
            if (Keyboard.IsKeyDown(Keys.A))
            {
                strafe -= 1;
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                forward -= 1;
            }


            CurrentWorld.AddCameraRotationFromMouseDelta();
            CurrentWorld.UpdateCameraPositionForFirstPersonView(Center,2f);
            MoveAndStrafeAlongCameraXZ(forward, strafe, 0.05f);
            TurnTowardsXZ(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector);




        }
    }
}
