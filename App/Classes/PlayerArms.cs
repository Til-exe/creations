using ImGuiNET;
using KWEngine3.GameObjects;

namespace Gruppenprojekt.App.Classes
{
    internal class PlayerArms : ViewSpaceGameObject
    {
        public PlayerArms()
        {
            SetModel("FPSARMS");
            SetAnimationID(0);
            SetAnimationPercentage(0.25f);
            SetRotation(-10f, 0f, 0f);
            SetOffset(0, -0.25f, 0f);
            SetScale(0.5f);
            IsShadowCaster = true;
            DepthTestingEnabled = false;
        }

        public override void Act()
        {
            UpdatePosition();   
        }
    }
}
