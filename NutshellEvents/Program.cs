using System;

namespace NutshellEvents
{

    public delegate string Mydelegate(int paramA, string paramB); // тип делегата

    //delegate void MyEventHandler(object o, EventArgs args); 

    public delegate void EventHandler(object o, EventArgs args);



    class Program
    {
        public string Name { get; set; } = "default";

        static string AddText(Mydelegate mydelegate, int value)
        {
            return String.Format($"{mydelegate(value, "and")} - {value}");
        }

        static string SomeMethod(int val1, string val2)
        {
            return val2 + ' ' + val1.ToString();
        }

        static void Main(string[] args)
        {
            // Action - тип делегата (public delegate void Action)
            Action a = () => Console.Write("A");
            
            var myDelegate = new Mydelegate(SomeMethod); // экземпляр делегата
            var result = AddText(myDelegate, 5);
            Console.WriteLine(result);

            
            Boozer vasya = new Boozer();
            
            vasya.OilNeeded += OilNeeded;
            vasya.myEvent += myDelegate;
            vasya.GetDrunk();

            {
                // кортежи
                var tuple1 = (5, 10, "sdc");

                (int first, string second) tuple2 = (first: 5, second: "vs"); // name


            }



            Example1 example1 = new Example1();
            Hendler1 hendler1 = new Hendler1();
            Hendler2 hendler2 = new Hendler2();
            example1.Notify += hendler1.message;
            example1.Notify += hendler2.message;

            example1.Count();


            StaticExample staticExample = new StaticExample();
            staticExample.staticEvent += Stat1.Meth;
            staticExample.Go("davai");


            //staticExample.evn += new EventHandler(StaticExample_evn);


            SomeGettingClass someGettingClass = new SomeGettingClass();
            staticExample.evn += someGettingClass.Happened;
            staticExample.GoEventHendler();
        }

        private static void StaticExample_evn(object o, EventArgs args)
        {
            throw new NotImplementedException();
        }

        private static void OilNeeded(object o, EventArgs e)
        {
            if (o is Boozer)
            {
                Console.WriteLine("go to more piva");
            }
        }
    }

    public class Boozer
    {

        public Int32 oilAmount { get; private set; }

        public event Mydelegate myEvent;

        public event EventHandler OilNeeded = (s, e) => {  }; // null object pattern

        public Boozer()
        {
            oilAmount = 20;
        }

        public void GetDrunk()
        {
            for (var i = oilAmount; i >= 0; i--)
            {
                System.Threading.Thread.Sleep(10);
                Console.WriteLine($"bottles : {i}");
                if (oilAmount == 0)
                {
                    OilNeeded?.Invoke(this, new EventArgs()); // invoke delegate if not null
                    Console.WriteLine(myEvent?.Invoke(0, "text")); // вызов всем методов делегата
                }

                oilAmount--;
            }
        }

    }
}
