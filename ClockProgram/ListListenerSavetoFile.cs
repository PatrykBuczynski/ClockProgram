using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClockProgram
{
    class ListListenerSaveToFile
    {
        private String nameOfFile;
        public ListListenerSaveToFile(String fileName) 
        {
            this.nameOfFile = fileName;
            if (File.Exists(nameOfFile))
            {
                File.Delete(nameOfFile);
            }
        }
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
            FileStream fileStream;
            StreamWriter streamWriter;

            fileStream = new FileStream(nameOfFile, FileMode.Append);
            streamWriter = new StreamWriter(fileStream);

            int h;
            int min;
            int sec;
            GetTimes(ti.date, out h, out min, out sec);
            streamWriter.WriteLine("This is called when the events fires.\nEvent fired at {0}h {1}min {2}sec", h, min, sec);
            streamWriter.WriteLine("Changed elements are:");
            foreach (object obj in ti.listArg)
            {
                streamWriter.WriteLine(obj);
            }
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }
        void GetTimes(DateTime date, out int h, out int min, out int sec)
        {
            h = date.Hour;
            min = date.Minute;
            sec = date.Second;
        }
    }
}
