using System;
using System.Collections.Generic;
using System.Text;

namespace NutshellEvents
{

    public class MyEventArgs : EventArgs
    {
        
        private readonly string info = null;
        private readonly int id = 0;

        public MyEventArgs(string info, int id)
        {
            this.info = info;
            this.id = id;
        }

        public void ShowArgs()
        {
            Console.WriteLine($"info : {info} id = {id}");
        }

    }

    //public delegate EventHandler(object o, EventArgs args);

    public delegate void StaticDell(string info);

    class StaticExample
    {
        public event EventHandler evn;

        public event StaticDell staticEvent = (info) => { };

        public void Go(string s)
        {
            staticEvent?.Invoke(s);
        }

        public void GoEventHendler()
        {
            evn?.Invoke(this, new MyEventArgs("rabotaet?", 0));
        }

    }

    public class SomeGettingClass
    {
        public void Happened(object o, EventArgs e)
        {
            StaticExample staticExample = o as StaticExample;
            MyEventArgs myEventArgs = e as MyEventArgs;

            myEventArgs.ShowArgs();

            //e.ShowArgs();
        }
    }

    static internal class Stat1
    {
        public static void Meth(string s)
        {
            Console.WriteLine($"here is {s}");
        }
    }
}
