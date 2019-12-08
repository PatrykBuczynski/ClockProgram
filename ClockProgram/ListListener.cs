using System;
using System.Collections.Generic;
using System.Text;

namespace ClockProgram
{
    public class ListListener
    {
        public void Subscribe(List theList) 
        {
            theList.ListChange += new List.ListChangeHandler(ListHasChanged);
        }
        public void Unsubscribe(List theList) 
        {
            theList.ListChange -= new List.ListChangeHandler(ListHasChanged);
        }
        public void ListHasChanged(object theList, TimeInfoEventArgs ti) 
        {
            int h;
            int min;
            int sec;
            GetTimes(ti.date, out h, out min, out sec);
            Console.WriteLine("This is called when the events fires.\nEvent fired at {0}h {1}min {2}sec\nChanged elements are:", h, min, sec);
            foreach (object obj in ti.listArg) 
            {
                Console.WriteLine(obj);
            }
        }
        void GetTimes(DateTime date, out int h, out int min, out int sec) 
        {
            h = date.Hour;
            min = date.Minute;
            sec = date.Second;
        }
    }
}
