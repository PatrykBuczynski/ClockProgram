using System;
using System.Threading;

namespace ClockProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List newList = new List();
            ListListener newListListener = new ListListener();
            ListListenerSaveToFile newListListenerSaveToFile = new ListListenerSaveToFile(@"c:\temp\changes.txt");

            newListListener.Subscribe(newList);
            newListListenerSaveToFile.Subscribe(newList);

            newList.Add(1);
            newList.Add(2);
            newList.Add(1 + 2);

            newList[1] = "New Object3";

            Thread.Sleep(1000);

            newList.Clear();

            newListListener.Unsubscribe(newList);
            newListListenerSaveToFile.Unsubscribe(newList);

            newList.Add("I added it after unsubscribing");
            Console.ReadKey();
        }
    }
}
