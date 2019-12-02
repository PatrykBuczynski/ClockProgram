using System;
using System.Threading;

namespace ClockProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List newList = new List();
            newList.Add("New object");
            ListListener newListListener = new ListListener();
            newListListener.Subscribe(newList);
            newList.Add(1);
            Thread.Sleep(1000);
            newList.Clear();
        }
    }
}
