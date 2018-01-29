using System;
using System.Collections.Generic;
using System.Text;

namespace LM.Senac.BouncingBall.Physics
{
    public class Time
    {
        private TimeSpan tsLastUpdate;
        public TimeSpan LastUpdate
        {
            get { return tsLastUpdate; }
            set { tsLastUpdate = value; }
        }

        private TimeSpan tsNow;
        public TimeSpan Now
        {
            get { return tsNow; }
            set { tsNow = value; }
        }

        private float dblElapsedTime;
        public float ElapsedTime
        {
            get { return dblElapsedTime; }
        }

        private TimeSpan tsStartTime = DateTime.Now.TimeOfDay;
        public TimeSpan StartTime
        {
            get { return tsStartTime; }
        }

        public void Update()
        {
            tsLastUpdate = tsNow;
            tsNow = DateTime.Now.TimeOfDay;
            dblElapsedTime = (float)tsNow.Subtract(tsLastUpdate).TotalSeconds;
        }
    }
}
