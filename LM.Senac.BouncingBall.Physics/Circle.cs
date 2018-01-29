using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public class Circle: Body
    {

        public Circle()
        {
            this._radius = 0f;
        }

        public Circle(double radius)
        {
            this._radius = radius;
        }


        private double _radius = 0;
        public double Radius
        {
            get
            {
                if (_radius == 0)
                {
                    _radius = this.Box2D.Width / 2d;
                }
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (this.IsVisible)
                g.FillEllipse(this.Color, this.Box2D);
        }

        public override bool IsColliding(Body otherBody)
        {
            if (base.IsColliding(otherBody))
            {
                if (otherBody is Circle)
                {
                    double distX = otherBody.Position.X - this.Position.X;
                    double distY = otherBody.Position.Y - this.Position.Y;
                    double rad = (otherBody as Circle).Radius + this.Radius;

                    return ((rad * rad) > (distX * distX + distY * distY));
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
