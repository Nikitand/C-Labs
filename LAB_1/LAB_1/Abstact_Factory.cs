using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_1
{
   
    public interface Icar
    {
        void Get_color();
    }
     public interface ISpeed
    {
     public void Speed(); 
    }
    public class VW : Icar
    {
       public void Get_color() => Console.WriteLine("black");
    }
    public class Lada : Icar
    {
        public void Get_color() => Console.WriteLine("white");
    }

    public class Good_car : ISpeed
    {
        public void Speed() => Console.WriteLine("Max speed - 250");
    }
    public class Bad_car : ISpeed
    {
        public  void Speed() => Console.WriteLine("Max speed - 150");
    }
    public interface IFactory
    {
        ISpeed Createspeed();
        Icar CreateCars();
    }
    public class Rich_car : IFactory
    {
        public ISpeed Createspeed()
        {
            return new Good_car();
        }
        public Icar CreateCars()
        {
            return new VW();
        }
    }
    public class Pool_car : IFactory
    {
        public ISpeed Createspeed()
        {
            return new Bad_car();
        }
        public Icar CreateCars()
        {
            return new Lada();
        }
    }

}
