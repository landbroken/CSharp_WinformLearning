using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGridViewLearning
{
    struct GPSData
    {
        private double longtitude;
        private double latitude;
        private double velocity;

        public double Longtitude
        {
            get
            {
                return longtitude;
            }

            set
            {
                longtitude = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        public enum ColumnNum
        {
            Longtitude=0, Latitude=1, Velocity=2
        }

        public GPSData(double LongtitudeIn,double LatitudeIn, double VelocityIn)
        {
            longtitude = LongtitudeIn;
            latitude = LatitudeIn;
            velocity = VelocityIn;
        }
    }
}
