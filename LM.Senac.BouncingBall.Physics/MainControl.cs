using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace LM.Senac.BouncingBall.Physics
{
    public class MainControl
    {

        public MainControl(Planet myPlanet)
        {
            this._myPlanet = myPlanet;
        }

        private bool isPaused = false;
        public bool IsPaused { get { return this.isPaused; } }

        private Planet _myPlanet = null;
        public Planet MyPlanet { get { return this._myPlanet; } }

        private Image _currentRender = null;
        public Image CurrentRender { get { return this._currentRender; } set { this._currentRender = value; } }

        private bool _isRunning = false;
        public bool IsRunning { get { return this._isRunning;} set { this._isRunning = value;} }

        private Time _timer = null;
        public Time Timer { get { return this._timer; } set { this._timer = value; } }

        public void Start()
        {
            Thread th = new Thread(this.Run);
            this._isRunning = true;

            this._timer = new Time();
            th.Start();
        }
        
        public void Paused()
        {
            this.isPaused = !this.isPaused;
        }

        public void StartWT()
        {            
            this._isRunning = true;

            this._timer = new Time();
            this.Run();
        }

        public void Stop()
        {
            this._isRunning = false;
        }

        public void Run()
        {
            this._timer.Update();
            while (this._isRunning)
            {
                this._timer.Update();

                if (!this.isPaused)
                {
                    this.Update();
                    this.Draw();
                }
                GC.Collect();
                Thread.Sleep(5);
            }
        }

        private void Update()
        {
            this._myPlanet.Update(this._timer.ElapsedTime);
        }

        private void Draw()
        {
            Image img = new Bitmap(1280, 800, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(img))
            {
                this._myPlanet.Draw(g);
                g.Save();
            }

            lock (this)
            {
                this.CurrentRender = img;
            }
            
            if (this.AfterDraw != null)
                this.AfterDraw(this, new EventArgs());
        }

        public event EventHandler AfterDraw;




        public void RunWT()
        {            
            if (this._isRunning)
            {
                this._timer.Update();

                if (!this.isPaused)
                {
                    this.Update();
                    this.Draw();
                }
                GC.Collect();
            }
        }

        public void StartInitialize()
        {
            this._isRunning = true;

            this._timer = new Time();
            this._timer.Update();
        }

    }
}
