using KWEngine3;
using KWEngine3.Audio;
using KWEngine3.GameObjects;
using Gruppenprojekt.App.Classes;
using OpenTK.Mathematics;

namespace Gruppenprojekt.App
{
    public class GameWorldStart : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetCameraPosition(0.0f, 0.0f, 15.0f);
            SetCameraTarget(0.0f, 0.0f, 0.0f);
            SetCameraFOV(90);
            SetColorAmbient(0.75f, 0.75f, 0.75f);
        }
    }
}
