using System;
using System.Collections.Generic;
using System.Text;

namespace NutshellEvents
{

    public delegate void dell(Int32 i);

    class Example1
    {
        public event dell Notify = (Int32) => { };

        public void Count()
        {
            for (var i = 0; i < 100; i++)
            {
                if (i == 71)
                {
                    Notify?.Invoke(i);
                }
            }
        }
    }

    class Hendler1
    {
        public void message(Int32 i)
        {
            Console.WriteLine($"hand1 : {i}");
        }
    }

    class Hendler2
    {
        public void message(Int32 i)
        {
            Console.WriteLine($"hand2 : {i}");
        }
    }
}
