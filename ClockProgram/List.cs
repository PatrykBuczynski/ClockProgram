using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClockProgram
{
    public class TimeInfoEventArgs : EventArgs 
    {
        public readonly DateTime date;
        public readonly ArrayList listArg;

        public TimeInfoEventArgs(DateTime date, ArrayList listArg) 
        {
            this.date = date;
            this.listArg = listArg;
               
        }
    }
    public class List : ArrayList
    {

        public delegate void ListChangeHandler(object List, TimeInfoEventArgs timeInformation);

        public event ListChangeHandler ListChange;

        protected void OnListChange(TimeInfoEventArgs timeInformation) 
        {
            if (ListChange != null) 
            {
                ListChange(this, timeInformation);
            }
        }
        public override int Add(object Value)
        {
            ArrayList changes = new ArrayList();
            changes.Add(Value);
            System.DateTime dt = System.DateTime.Now;
            TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt, changes);
            OnListChange(timeInformation);
            return base.Add(Value);
        }
        public override void Clear()
        {
            ArrayList changes = new ArrayList();
            changes = (ArrayList)this.Clone();
            System.DateTime dt = System.DateTime.Now;
            TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt, changes);
            OnListChange(timeInformation);

            base.Clear();
        }
        public override object this[int index] 
        {
            get 
            {
                return base[index];
            }
            set
            {
                ArrayList changes = new ArrayList();
                changes.Add(base[index]);
                changes.Add(value);
                System.DateTime dt = System.DateTime.Now;
                TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt, changes);
                OnListChange(timeInformation);

                base[index] = value;
            }
        }
    }
}
