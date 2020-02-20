using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_1
{
   public interface IBuilder
    {
        public  void EngineBuild( string speed);
        public   void ColorBuild(string color);
        public  string GetResult();
       
    }
    public class CarsBuilder : IBuilder
    {
        private string Car = string.Empty;

  
        void IBuilder.ColorBuild(string color)
        {
            
        }
        void IBuilder.EngineBuild(string speed)
        {
          
        }
        string IBuilder.GetResult()
        {
            return Car;
        }
    }
    public class CarDirectory
    {
        private readonly IBuilder _builder;
        public CarDirectory(IBuilder builder)
        { _builder = builder; }
        public string BuildPage(int speed, string Color)
        {
            _builder.EngineBuild(Getengine(speed));
            _builder.ColorBuild(GetColor(Color));
            return _builder.GetResult();
        }
     
        private string Getengine(int speed)
        { 
            return "Speed " + speed;
        }
        private string GetColor(string Color)
        { 
            return "Color: " + Color;
        }
       
    }
}
