using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatFormer
{
    public class Platform
    {
        double positionX;
        double positionY;
        double lenght;
        double height;

        public Platform(double positionX, double positionY, double lenght, double height)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Lenght = lenght;
            this.Height = height;
        }

        public double PositionX { get => positionX; set => positionX = value; }
        public double PositionY { get => positionY; set => positionY = value; }
        public double Lenght { get => lenght; set => lenght = value; }
        public double Height { get => height; set => height = value; }
    }
}
