using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public static class MRU
    {
        public static double GetPosition(double initialPosition, double velocity, double elapsedTime)
        {
            return initialPosition + (velocity * elapsedTime);
        }
    }
}
