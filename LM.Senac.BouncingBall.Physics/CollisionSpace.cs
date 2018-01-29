using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public abstract class CollisionSpace
    {
        public CollisionSpace()
        {
            this.Bodies = new List<Body>();
        }

        public List<Body> _bodies = new List<Body>();
        public List<Body> Bodies { get { return this._bodies;} set { this._bodies = value;} }

        public virtual void VerifyCollisions(float elapsedTime)
        {
            int finalVerify = Bodies.Count - 1;

            for (int i = 0; i < finalVerify; i++)
            {
                Body body = this.Bodies[i];
                for (int j = i + 1; j < this.Bodies.Count; j++)
                {
                    Body otherBody = this.Bodies[j];

                    if (body.IsColliding(otherBody))
                    {
                        this.OnCollide(elapsedTime, body, otherBody);
                    }
                }
            }

        }

        public virtual void OnCollide(float elapsedTime, Body body, Body otherBody)
        {
            if (body.UseGravity && !otherBody.UseGravity)
            {
                this.OnCollideWithStaticBody(elapsedTime, body, otherBody);
            }
            else if (otherBody.UseGravity && !body.UseGravity)
            {
                this.OnCollideWithStaticBody(elapsedTime, otherBody, body);                
            }
            else
            {
                this.OnCollideWithDynamicBody(elapsedTime, body, otherBody);
            }
        }

        public abstract void OnCollideWithDynamicBody(float elapsedTime, Body body, Body dynamicBody);

        public abstract void OnCollideWithStaticBody(float elapsedTime, Body body, Body staticBody);

        public Body AddBody(Body body)
        {
            this.Bodies.Add(body);
            return body;
        }

        public T AddBody<T>(T body)
            where T : Body
        {
            this.Bodies.Add(body);
            return body;
        }
    }
}
