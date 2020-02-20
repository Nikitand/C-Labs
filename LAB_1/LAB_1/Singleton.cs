using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_1
{

   
   public sealed class Police
    {
        public static Police instance;

        public string Color { get;}
        public int max_speed { get;}
        public Police()   
        {
            this.Color = "Special";
            this.max_speed = 280;
        }

        public static Police getInstance ()
        {
            if (instance == null)
                instance = new Police();
            return instance;
        }
        public void GetInfo()
        {
            Console.WriteLine("Its a police car!!!");
            Console.WriteLine($"Color: {Color}, max_speed - {max_speed}");
        }
    }
}
