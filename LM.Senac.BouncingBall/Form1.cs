using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LM.Senac.BouncingBall.Physics;

namespace LM.Senac.BouncingBall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            this._mainGame = new MainControl(new Planet("Earth", 9.58f * 3.5f));
            this.InitializeBodies();
            this._mainGame.AfterDraw += new EventHandler(_mainGame_AfterDraw);
            //this.MainGame.Start();
            this.timer1.Start();
            this.timer2.Start();          
        }

        bool firstExec = true;

        void _mainGame_AfterDraw(object sender, EventArgs e)
        {
            //this.pictureBox1.Refresh();
        }

        private Body _myBody = null;
        public Body MyBody { get { return this._myBody; } set { this._myBody = value; } }

        private MainControl _mainGame = null;
        public MainControl MainGame { get { return this._mainGame; } }

        private void Clear()
        {
            lock (this._mainGame.MyPlanet)
            {
                this._mainGame.MyPlanet.Bodies.Clear();
            }
        }

        private void InitializeBodies()
        {
            lock (this._mainGame.MyPlanet)
            {
                this._mainGame.MyPlanet.Bodies.Clear();

                Body floor = new Body();
                floor.UseGravity = false;
                floor.Position = new LM.Senac.BouncingBall.Physics.Vector2d(0, 600);
                floor.Size = new Size2d(1000, 20);
                floor.Friction = 0.03f;
                floor.Color = Brushes.Brown;
                this._mainGame.MyPlanet.AddBody(floor);

                Body floor02 = new Body();
                floor02.UseGravity = false;
                floor02.Position = new LM.Senac.BouncingBall.Physics.Vector2d(0, 200);
                floor02.Size = new Size2d(200, 20);
                floor02.Color = Brushes.Brown;
                this._mainGame.MyPlanet.AddBody(floor02);

                Body floor03 = new Body();
                floor03.UseGravity = false;
                floor03.Position = new LM.Senac.BouncingBall.Physics.Vector2d(200, 300);
                floor03.Size = new Size2d(300, 20);
                floor03.Color = Brushes.Brown;
                this._mainGame.MyPlanet.AddBody(floor03);

                Body floor04 = new Body();
                floor04.UseGravity = false;
                floor04.Position = new LM.Senac.BouncingBall.Physics.Vector2d(950, 30);
                floor04.Size = new Size2d(60, 600);
                floor04.Color = Brushes.Brown;
                this._mainGame.MyPlanet.AddBody(floor04);

                Body teste = new Body();
                teste.UseGravity = true;
                teste.Position = new LM.Senac.BouncingBall.Physics.Vector2d(100, 0);
                teste.Size = new Size2d(15, 15);
                teste.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(7, 0);
                this._mainGame.MyPlanet.AddBody(teste);

                teste = new Body();
                teste.UseGravity = true;
                teste.Position = new LM.Senac.BouncingBall.Physics.Vector2d(50, 20);
                teste.Size = new Size2d(12, 12);
                teste.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(6, -10);
                this._mainGame.MyPlanet.AddBody(teste);

                MyBody = new Circle();
                MyBody.UseGravity = true;
                MyBody.Position = new LM.Senac.BouncingBall.Physics.Vector2d(600, 200);
                MyBody.Size = new Size2d(20, 20);
                MyBody.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(-6, -10);
                MyBody.Color = Brushes.Green;
                MyBody.Mass = 3;
                this._mainGame.MyPlanet.AddBody(MyBody);
            }
            
        }

        private void DrawBodyInfo(Body body, Graphics graphics)
        {
            graphics.DrawString("Y: " + body.Position.Y.ToString("#,##0.00"), this.Font, Brushes.Blue, 400, 30);
            graphics.DrawString("Velocity: " + body.Velocity.Y.ToString("#,##0.00"), this.Font, Brushes.Blue, 400, 50);
            graphics.DrawString("Time: " + MainGame.Timer.ElapsedTime.ToString("#,##0.00"), this.Font, Brushes.Blue, 400, 70);
            graphics.DrawString("Gravity: " + MainGame.MyPlanet.Gravity.ToString("#,##0.00"), this.Font, Brushes.Blue, 400, 90);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            lock (this.MyBody)
            {
                if (e.KeyData == Keys.Up)
                {
                    this.MyBody.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(this.MyBody.Velocity.X, this.MyBody.Velocity.Y - 30);
                }
                if (e.KeyData == Keys.Down)
                {
                    this.MyBody.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(this.MyBody.Velocity.X, this.MyBody.Velocity.Y + 30);
                }
                if (e.KeyData == Keys.Left)
                {
                    this.MyBody.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(this.MyBody.Velocity.X - 5, this.MyBody.Velocity.Y);
                }
                if (e.KeyData == Keys.Right)
                {
                    this.MyBody.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(this.MyBody.Velocity.X + 5, this.MyBody.Velocity.Y);
                }
            }

            lock (this.MainGame.MyPlanet.Bodies)
            {
                if (e.KeyData == Keys.L)
                {
                    Body bd = new Body();
                    bd.UseGravity = true;
                    bd.Color = Brushes.Black;
                    bd.Position = new LM.Senac.BouncingBall.Physics.Vector2d(400, 400);
                    bd.Velocity = AuxMath.AngleDegreesToVector(85, -135);
                    bd.Size = new Size2d(12, 12);
                    this._mainGame.MyPlanet.AddBody(bd);
                }
                if (e.KeyData == Keys.K)
                {
                    Body bd = new Body();
                    bd.UseGravity = true;
                    bd.Color = Brushes.Black;
                    bd.Position = new LM.Senac.BouncingBall.Physics.Vector2d(30, 400);
                    bd.Velocity = AuxMath.AngleDegreesToVector(85, -45);
                    bd.Size = new Size2d(12, 12);
                    this._mainGame.MyPlanet.AddBody(bd);
                }
                if (e.KeyData == Keys.J)
                {
                    Body bd = new Body();
                    bd.UseGravity = true;
                    bd.Color = Brushes.Black;
                    bd.Position = new LM.Senac.BouncingBall.Physics.Vector2d(70, 400);
                    bd.Velocity = AuxMath.AngleDegreesToVector(85, -90);
                    bd.Size = new Size2d(12, 12);
                    this._mainGame.MyPlanet.AddBody(bd);
                }
            }

            if (e.KeyData == Keys.Add)
            {
                this.MainGame.MyPlanet.Gravity += 5d;
            }

            if (e.KeyData == Keys.Subtract)
            {
                this.MainGame.MyPlanet.Gravity -= 5d;
            }

            if (e.KeyData == Keys.C)
            {
                this.Clear();
            }

            if (e.KeyData == Keys.R)
            {
                this.InitializeBodies();
            }

            if (e.KeyData == Keys.P)
            {
                this._mainGame.Paused();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._mainGame.Stop();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            lock (this._mainGame)
            {
                if (!firstExec && _mainGame.CurrentRender != null)
                {
                    e.Graphics.DrawImage(_mainGame.CurrentRender, 0, 0, this.pictureBox1.Width, this.pictureBox1.Height);
                    this.DrawBodyInfo(this.MyBody, e.Graphics);
                }
            }

        }

        Random rd = new Random();
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            lock (this.MainGame.MyPlanet)
            {
                lock (this._mainGame)
                {
                    MyBody = new Circle();
                    MyBody.UseGravity = true;
                    MyBody.Position = new LM.Senac.BouncingBall.Physics.Vector2d(e.X, e.Y);
                    MyBody.Size = new Size2d(15, 15);
                    MyBody.Velocity = new LM.Senac.BouncingBall.Physics.Vector2d(rd.Next(-10, 10), rd.Next(-5, 5));
                    MyBody.Color = Brushes.Green;
                    MyBody.Mass = 3;

                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            MyBody.Elasticity = 0.8d;
                            break;
                        case MouseButtons.Middle:
                            MyBody.Elasticity = 0.4d;
                            break;
                        case MouseButtons.Right:
                            MyBody.Elasticity = 0.2d;
                            break;
                    }
                   
                    this._mainGame.MyPlanet.AddBody(MyBody);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.MainGame.StartWT();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (firstExec)
            {
                this.MainGame.StartInitialize();
                firstExec = false;
            }
            this.MainGame.RunWT();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Refresh();
        }
    }
}
