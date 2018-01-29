using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public static class MRUV
    {


        public static double GetPosition(double initialPosition, double velocity, double elapsedTime, double acelaration)
        {
            return initialPosition + (velocity * elapsedTime) + ((acelaration / 2) * elapsedTime * elapsedTime);
        }

        public static double GetVelocity(double initialVelocity, double elapsedTime, double acelaration)
        {
            return initialVelocity + (acelaration * elapsedTime);
        }
    }
}
