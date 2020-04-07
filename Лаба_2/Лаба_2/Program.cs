using System;
using System.Collections.Generic;

namespace Лаба_2
{

    interface Ibase { }
    abstract class Base : Ibase { }
    class Class : Base { }
    class Derived : Class { }
    class Program
    {
        static void Main(string[] args)
        {
            //Adapter
            Drive drive = new Drive();
            Move_1 move_1 = new Move_1();
            drive.Travel(move_1);
            Move_2 move_2 = new Move_2();
            IMoveX moveX = new From_Move2_to_Move1(move_2);
            drive.Travel(moveX);
            //
            Console.WriteLine();
            //

            IElement print = new Element { text = "Its Lab" };
            print.print();
            IElement printer = new newelement(print);
            printer.print();
            ///
            var district = new Map { Title = "District" };
            district.AddComponent(new MapComponent { Title = "Move1" });
            district.AddComponent(new MapComponent { Title = "Move2" });
            district.AddComponent(new MapComponent { Title = "Move3" });
            var city = new Map { Title = "New object" };
            city.AddComponent(district);
            city.Draw();
            var house = city.Find("Move1");
            house.Draw();

            Base b = new Class();
            Console.WriteLine(    $"{ b is Derived}");
            Console.WriteLine($"{ b is Class}");
            Console.WriteLine($"{ b.GetType() == typeof(Class)}");
        }


    }
  
    public interface IComponent
    {
        string Title { get; set; }
        void Draw();
        IComponent Find(string title);
    }
    public class MapComponent : IComponent
    {
        public string Title { get; set; }
        public void Draw()
        {
            Console.WriteLine(Title);
        }
        public IComponent Find(string title)
        {
            return Title == title ? this : null;
        }
    }
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }
        public void AddComponent(IComponent component)
        {
            _map.Add(component);
        }
        public void Draw()
        {
            Console.WriteLine(Title);
            foreach (var component in _map)
            {
                component.Draw();
            }
        }
        public IComponent Find(string title)
        {
            if (Title == title)
            {
                return this;
            }
            foreach (var component in _map)
            {
                var found = component.Find(title);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }
}



}
