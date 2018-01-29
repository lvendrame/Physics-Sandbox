using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public class Planet: CollisionSpace
    {
        public Planet(string name, float gravity)
        {
            this._gravity = gravity;
            this._name = name;
        }

        public double _gravity;
        public double Gravity { get { return this._gravity; } set { this._gravity = value; } }
        
        public string _name;
        public string Name { get { return this._name; } set { this._name = value; } }

        public double _friction;
        public double Friction { get { return this._friction; } set { this._friction = value; } }

        public double _wind;
        public double Wind { get { return this._wind; } set { this._wind = value; } }

        public double ResultingWindAndFriction
        {
            get
            {
                return this._wind + this._friction;
            }
        }

        public void Update(float elapsedTime)
        {
            this.UpdateMUV(elapsedTime);

            this.VerifyCollisions(elapsedTime);
        }

        public void UpdateMUV(float elapsedTime)
        {
            foreach (Body body in this.Bodies)
            {
                if (body.UseGravity)
                {
                    bool useMRUV = body.Velocity.Y > -200.0d && body.Velocity.Y < 200.0d;

                    body.Position = new Vector2d(
                            Physics.MRUV.GetPosition(body.Position.X, body.Velocity.X, elapsedTime, body.Acceleration.X + this.ResultingWindAndFriction),
                            useMRUV ?
                                Physics.MRUV.GetPosition(body.Position.Y, body.Velocity.Y, elapsedTime, body.Acceleration.Y + this.Gravity):
                                Physics.MRU.GetPosition(body.Position.Y, body.Velocity.Y, elapsedTime)
                        );

                    body.Velocity = new Vector2d(
                            Physics.MRUV.GetVelocity(body.Velocity.X, elapsedTime, body.Acceleration.X + this.ResultingWindAndFriction),
                            useMRUV ?
                                Physics.MRUV.GetVelocity(body.Velocity.Y, elapsedTime, body.Acceleration.Y + this.Gravity):
                                body.Velocity.Y
                        );
                }
            }
        }

        public void Draw(System.Drawing.Graphics g)
        {
            foreach (Body body in this.Bodies)
            {
                body.Draw(g);
            }
        }

        public override void OnCollideWithDynamicBody(float elapsedTime, Body body, Body dynamicBody)
        {
            Vector2d cm = AuxMath.CenterMassVelocity(body, dynamicBody);
            body.Velocity = (2 * cm) - body.Velocity;
            dynamicBody.Velocity = (2 * cm) - dynamicBody.Velocity;
        }

        public override void OnCollideWithStaticBody(float elapsedTime, Body body, Body staticBody)
        {
            Vector2d position = body.Position;
            Vector2d velocity = body.Velocity;
            Box2d bodyBox = body.Box2D;
            Box2d stBdBox = staticBody.Box2D;

            double elasticity = body.Elasticity + staticBody.Elasticity;


            if (velocity.X > 0)
            {                
                double b = bodyBox.Right - stBdBox.X;

                if ((bodyBox.Width * bodyBox.Width) > (b * b))
                {
                    position.X = position.X - b;
                    velocity.X = velocity.X * -elasticity;
                    velocity.Y = velocity.Y * (1 - staticBody.Friction);
                }
            } 
            else if (velocity.X < -4)
            {
                double b = stBdBox.Right - bodyBox.X;

                if ((bodyBox.Width * bodyBox.Width) > (b * b))
                {
                    position.X = position.X + b;
                    velocity.X = velocity.X * -elasticity;
                    velocity.Y = velocity.Y * (1 - staticBody.Friction);
                }
            }
            else
            {
                double b = stBdBox.Right - bodyBox.X;

                if ((bodyBox.Width * bodyBox.Width) > (b * b))
                {
                    position.X = position.X + b;
                    velocity.X = 0;
                    velocity.Y = velocity.Y * (1 - staticBody.Friction);
                }
            }

            if (velocity.Y > 0)
            {
                double b = bodyBox.Bottom - stBdBox.Y;

                if ((bodyBox.Height * bodyBox.Height) > (b * b))
                {
                    position.Y = position.Y - b;
                    velocity.Y = velocity.Y * -elasticity;
                    velocity.X = velocity.X * (1 - staticBody.Friction);
                }
            }
            else if (velocity.Y < -4)
            {
                double b = stBdBox.Bottom - bodyBox.Y;

                if ((bodyBox.Height * bodyBox.Height) > (b * b))
                {
                    position.Y = position.Y + b;
                    velocity.Y = velocity.Y * -elasticity;
                    velocity.X = velocity.X * (1 - staticBody.Friction);
                }
            }
            else
            {
                double b = stBdBox.Bottom - bodyBox.Y;

                if ((bodyBox.Height * bodyBox.Height) > (b * b))
                {
                    position.Y = position.Y + b;
                    velocity.Y = 0;
                    velocity.X = velocity.X * (1 - staticBody.Friction);
                }
            }

            body.Position = position;
            body.Velocity = velocity;


            //body.Velocity = new Vector2d(
            //                        body.Velocity.X * (1 - staticBody.Friction),
            //                        body.Velocity.Y > 0 ? body.Velocity.Y * -0.8d : body.Velocity.Y
            //                    );
        }
    }
}
