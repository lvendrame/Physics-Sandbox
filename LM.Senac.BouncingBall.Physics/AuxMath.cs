using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LM.Senac.BouncingBall.Physics
{
    public class AuxMath
    {
        public const double PI = 3.141592920353982d;
        public const double G = 0.0000000000667428d;
        public const double Earth_Gravity_Acceleration = 9.8062d;

        public static Vector2d AngleToVector(double length, double angle)
        {
            return new Vector2d(
                length * System.Math.Cos(angle),
                length * System.Math.Sin(angle)
                );
        }

        public static Vector2d AngleDegreesToVector(double length, double degrees)
        {
            return AngleToVector(length, ((degrees * PI) / 180));
        }

        public static double AccelarationGravity(double mass, double radius)
        {
            return (mass * G) / (radius * radius);
        }

        public static double RadianToDegrees(double radian)
        {
            return (radian * 180) / PI;
        }

        public static double DegreesToRadian(double degrees)
        {
            return (degrees * PI) / 180;
        }

        public static Vector2d CenterMassVelocity(Body body, Body otherBody)
        {
            Vector2d p1 = body.Velocity * body.Mass;
            Vector2d p2 = otherBody.Velocity * otherBody.Mass;

            p1 = p1 + p2;

            double mass = body.Mass + otherBody.Mass;


            return p1 / mass;            
        }

    }
}
