using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_2
{
    interface IMoveX
    {
        void MoveX();
    }
    class Move_1 : IMoveX
    {
        public void MoveX()
        {
            Console.WriteLine(" Движение по  XXXXX");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("X");
            }
            Console.WriteLine();
        }
    }
    class Drive
    {
        public void Travel(IMoveX move)
        {
            move.MoveX();
        }
    }
    interface IMoveY
    {
        void MoveY();
    }
    class Move_2 : IMoveY
    {
        public void MoveY()
        {
            Console.WriteLine(" Движение по  YYYY");
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Y");
            }
        }
    }
    class From_Move2_to_Move1 : IMoveX
    {
        Move_2 move_2;
        public From_Move2_to_Move1(Move_2 c)
        {
            move_2 = c;
        }

        public void MoveX()
        {
            move_2.MoveY();
        }
    }
}
