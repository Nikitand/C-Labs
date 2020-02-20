using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace LAB_1
{
    class Program
    {

        static void Main(string[] args)
        {
            IFactory factory = new Rich_car();
            var speed = factory.Createspeed();
            var color = factory.CreateCars();
            Console.WriteLine("Rich_car - Vw, characteristics:");
            color.Get_color();
            speed.Speed();
            Police police = new Police();
            police.GetInfo();


            var carsbuild = new CarsBuilder();
            var pageDirector = new CarDirectory(carsbuild);
            var newcar = pageDirector.BuildPage(370, "Green");
            Console.WriteLine("New car: Porshe");
            Console.WriteLine("Characteristic:");
            Console.WriteLine(newcar);
            


            IFigure cars = new Cars(30, "red");
            IFigure clonedFigure = cars.Clone();
            cars.GetInfo();
           
            clonedFigure.GetInfo();
        }
    }
   
    

}

