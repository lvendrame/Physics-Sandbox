using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LM.Senac.BouncingBall.Physics
{
    public static class Functions
    {
        public static bool IsApproximate(float meValue, float value, float limit)
        {
            return (meValue + limit) >= value && (meValue - limit) <= value;
        }

        /*public static bool IsApproximate(this float meValue, float value, float limit)
        {
            return (meValue + limit) >= value && (meValue - limit) <= value;
        }

        public static PointF Mult(this PointF pt, float value)
        {
            return new PointF(pt.X * value, pt.Y * value);
        }

        public static PointF Div(this PointF pt, float value)
        {
            return new PointF(pt.X / value, pt.Y / value);
        }

        public static PointF Add(this PointF pt, this PointF value)
        {
            return new PointF(pt.X + value.X, pt.Y + value.Y);
        }

        public static PointF Mult(this PointF pt, this PointF value)
        {
            return new PointF(pt.X * value.X, pt.Y * value.Y);
        }

        public static PointF Div(this PointF pt, this PointF value)
        {
            return new PointF(pt.X / value.X, pt.Y / value.Y);
        }*/
    }
}
