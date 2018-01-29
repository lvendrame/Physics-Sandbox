using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public class Size2d
    {

        public Size2d(double width, double height)
        {
            this.dWidth = width;
            this.dHeight = height;
        }

        public static Size2d Zero = new Size2d(0, 0);

        private double dWidth;
        public double Width
        {
            get { return dWidth; }
            set { dWidth = value; }
        }

        private double dHeight;
        public double Height
        {
            get { return dHeight; }
            set { dHeight = value; }
        }        


        #region Operators

        public static Size2d operator +(Size2d thisP, Size2d pt)
        {
            return new Size2d(thisP.dWidth + pt.dWidth, thisP.dHeight + pt.dHeight);
        }

        public static Size2d operator -(Size2d thisP, Size2d pt)
        {
            return new Size2d(thisP.dWidth - pt.dWidth, thisP.dHeight - pt.dHeight);
        }

        public static Size2d operator *(Size2d thisP, Size2d pt)
        {
            return new Size2d(thisP.dWidth * pt.dWidth, thisP.dHeight * pt.dHeight);
        }

        public static Size2d operator /(Size2d thisP, Size2d pt)
        {
            return new Size2d(thisP.dWidth / pt.dWidth, thisP.dHeight / pt.dHeight);
        }

        public static Size2d operator *(Size2d thisP, double scalar)
        {
            return new Size2d(thisP.dWidth * scalar, thisP.dHeight * scalar);
        }

        public static Size2d operator /(Size2d thisP, double scalar)
        {
            return new Size2d(thisP.dWidth / scalar, thisP.dHeight / scalar);
        }

        public static Size2d operator *(double scalar, Size2d thisP)
        {
            return new Size2d(thisP.dWidth * scalar, thisP.dHeight * scalar);
        }

        public static bool operator ==(Size2d thisP, Size2d pt)
        {
            return thisP.dWidth == pt.dWidth && thisP.dHeight == pt.dHeight;
        }

        public static bool operator !=(Size2d thisP, Size2d pt)
        {
            return thisP.dWidth != pt.dWidth || thisP.dHeight != pt.dHeight;
        }

        public static implicit operator System.Drawing.SizeF(Size2d thisP)
        {
            return new System.Drawing.SizeF(Convert.ToSingle(thisP.dWidth), Convert.ToSingle(thisP.dHeight));
        }

        #endregion
    }
}
