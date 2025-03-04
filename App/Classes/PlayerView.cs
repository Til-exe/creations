using System;

namespace Gruppenprojekt.App.Classes
{
    internal struct PlayerView
    {
        public enum MovementMode
        {
            Idle = 0,
            Walk = 1,
            Run = 2
        }

        public float BobX { get; private set; }
        public float BobY { get; private set; }
        public float BobZ { get; private set; }
        public float BobTime { get; private set; }
        private float Step { get; set; }

        private const float STEPSIZE = 0.04f;
        private const float STEPSIZE_ACCELERATION = 1.5f;

        public PlayerView()
        {
            BobX = 0f;
            BobY = 0f;
            BobZ = 0f;
            BobTime = 0f;
            Step = 0f;
        }

        public void Update(MovementMode mode)
        {
            if (mode > MovementMode.Idle)
            {
                BobX = MathF.Sin(BobTime) * 0.25f;
                BobZ = MathF.Sin(BobTime) * 1f;
                BobY = (BobZ - 1f) * 0.5f;
                if (mode == MovementMode.Walk)
                {
                    BobTime += STEPSIZE;
                }
                else
                {
                    BobTime += STEPSIZE * STEPSIZE_ACCELERATION;
                }
            }
            else
            {
                BobTime = 0f;
                BobX *= 0.9f;
                BobY *= 0.9f;
                BobZ *= 0.9f;
                if (BobX < 0.00001f)
                    BobX = 0f;
                if (BobY < 0.00001f)
                    BobY = 0f;
                if (BobZ < 0.00001f)
                    BobZ = 0f;
            }
        }
    }
}
