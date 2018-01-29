using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public class Vector2d
    {

        public Vector2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2d Zero = new Vector2d(0, 0);

        private double x;
        public double X
        {
            get { return x; }
            set { this.ResetConstants(); x = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { this.ResetConstants(); y = value; }
        }

        private double? _module;
        public double Module
        {
            get
            {
                if(!this._module.HasValue)
                    this._module = Math.Sqrt(x * x + y * y);
                return this._module.Value;
            }
        }

        private Vector2d _versor = null;
        public Vector2d Versor
        {
            get
            {
                if (_versor == null)
                {
                    this._versor = this / this.Module;
                }
                return this._versor;
            }
        }

        private void ResetConstants()
        {
            this._module = null;
            this._versor = null;
        }

        public double Distance(Vector2d pt)
        {
            double xi = pt.x - this.x;
            double yi = pt.y - this.y;

            return Math.Sqrt(xi * xi + yi * yi);
        }

        #region Operators

        public static Vector2d operator +(Vector2d thisP, Vector2d pt)
        {
            return new Vector2d(thisP.x + pt.x, thisP.y + pt.y);
        }

        public static Vector2d operator -(Vector2d thisP, Vector2d pt)
        {
            return new Vector2d(thisP.x - pt.x, thisP.y - pt.y);
        }

        public static Vector2d operator *(Vector2d thisP, Vector2d pt)
        {
            return new Vector2d(thisP.x * pt.x, thisP.y * pt.y);
        }

        public static Vector2d operator /(Vector2d thisP, Vector2d pt)
        {
            return new Vector2d(thisP.x / pt.x, thisP.y / pt.y);
        }

        public static Vector2d operator *(Vector2d thisP, double scalar)
        {
            return new Vector2d(thisP.x * scalar, thisP.y * scalar);
        }

        public static Vector2d operator /(Vector2d thisP, double scalar)
        {
            return new Vector2d(thisP.x / scalar, thisP.y / scalar);
        }

        public static Vector2d operator *(double scalar, Vector2d thisP)
        {
            return new Vector2d(thisP.x * scalar, thisP.y * scalar);
        }

        public static bool operator ==(Vector2d thisP, Vector2d pt)
        {
            return thisP.x == pt.x && thisP.y == pt.y;
        }

        public static bool operator !=(Vector2d thisP, Vector2d pt)
        {
            return thisP.x != pt.x || thisP.y != pt.y;
        }

        public static implicit operator System.Drawing.PointF(Vector2d thisP)
        {
            return new System.Drawing.PointF(Convert.ToSingle(thisP.x), Convert.ToSingle(thisP.y));
        }

        #endregion


    }
}
