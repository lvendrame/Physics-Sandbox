using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LM.Senac.BouncingBall.Physics
{
    public class Body
    {

        public Body()
        {
            this.UseGravity = true;
            this.IsVisible = true;

            this.Color = Brushes.Red;

            this._position = Vector2d.Zero;
            this._velocity = Vector2d.Zero;
            this._acceleration = Vector2d.Zero;
            this._mass = 1f;
            this._elasticity = 0.4;
        }
        

        private double _elasticity;
        public double Elasticity
        {
            get { return _elasticity; }
            set { _elasticity = value; }
        }

        private Brush _color;
        public Brush Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private Vector2d _position;
        public Vector2d Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private Size2d _size;
        public Size2d Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Box2d Box2D
        {
            get
            {
                return new Box2d(this.Position, this.Size);
            }
        }

        public Vector2d Centre
        {
            get
            {
                return new Vector2d(this.Box2D.Right / 2.0d, this.Box2D.Bottom / 2.0d);
            }
        }

        private Vector2d _velocity;
        public Vector2d Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        private Vector2d _acceleration;
        public Vector2d Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        private double _mass;
        public double Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }

        private double _friction;
        public double Friction
        {
            get { return _friction; }
            set { _friction = value; }
        }

        private bool _useGravity;
        public bool UseGravity
        {
            get { return _useGravity; }
            set { _useGravity = value; }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }


        public virtual bool IsColliding(Body otherBody)
        {
            return this.Box2D.IntersectsWith(otherBody.Box2D);
        }

        public virtual void Draw(Graphics g)
        {
            if(this.IsVisible)
                g.FillRectangle(this.Color, this.Box2D);
        }
    }
}
