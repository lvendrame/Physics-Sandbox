using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public class Box2d
    {
        public Box2d()
            : this(Vector2d.Zero, Size2d.Zero)
        {
        }

        public Box2d(Vector2d position, Size2d size)
        {
            this.v2dPosition = position;
            this.s2dSize = size;
        }

        public Box2d(double x, double y, double width, double height)
            : this(new Vector2d(x, y), new Size2d(width, height))
        {
        }

        private Vector2d v2dPosition;
        public Vector2d Position
        {
            get { return v2dPosition; }
            set { v2dPosition = value; }
        }

        private Size2d s2dSize;
        public Size2d Size
        {
            get { return s2dSize; }
            set { s2dSize = value; }
        }

        public double X
        {
            get
            {
                return v2dPosition.X;
            }
        }

        public double Y
        {
            get
            {
                return v2dPosition.Y;
            }
        }

        public double Width
        {
            get
            {
                return s2dSize.Width;
            }
        }

        public double Height
        {
            get
            {
                return s2dSize.Height;
            }
        }

        public double Right
        {
            get
            {
                return this.v2dPosition.X + s2dSize.Width;
            }
        }

        public double Bottom
        {
            get
            {
                return this.v2dPosition.Y + s2dSize.Height;
            }
        }
        
        public static implicit operator System.Drawing.RectangleF(Box2d thisB)
        {
            return new System.Drawing.RectangleF(thisB.v2dPosition, thisB.s2dSize);
        }

        public bool IntersectsWith(Box2d box2d)
        {
            if (this.Right < box2d.X)
                return false;

            if (box2d.Right < this.X)
                return false;

            if (this.Bottom < box2d.Y)
                return false;

            if (box2d.Bottom < this.Y)
                return false;

            return true;
        }

        internal bool IntersectsVerticalWith(Box2d box2d)
        {
            if (this.Bottom < box2d.Y)
                return false;

            if (box2d.Bottom < this.Y)
                return false;

            return true;
        }

        public bool IntersectsHorizontalWith(Box2d box2d)
        {
            if (this.Right < box2d.X)
                return false;

            if (box2d.Right < this.X)
                return false;

            return true;
        }
    }
}
