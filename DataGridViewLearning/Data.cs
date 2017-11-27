using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGridViewLearning
{
    struct GPSData
    {
        private double longitude;
        private double latitude;
        private double velocity;

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
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
            Longitude=0, Latitude=1, Velocity=2
        }

        public GPSData(double LongitudeIn,double LatitudeIn, double VelocityIn)
        {
            longitude = LongitudeIn;
            latitude = LatitudeIn;
            velocity = VelocityIn;
        }
    }
}
