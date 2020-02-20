using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LAB_1
{
    
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Cars : IFigure
    {
        int Speed;
        string Color;
        public Cars(int s, string c)
        {
            Speed = s;
            Color = c;
        }

        public IFigure Clone()
        {
            return new Cars(this.Speed, this.Color);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Car with max speed {Speed} and color {Color}");
        }
    }
}
