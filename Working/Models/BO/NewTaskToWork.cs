using System;
using System.Collections.Generic;
using System.Text;

namespace Working.Models.BO
{
    public class NewTaskToWork
    {
        public string HandlerId { get; set; }
        //public DateTime DateOfCreated { get; set; }
        public long StartIn { get; set; }//second
        public bool Recycle { get; set; }
        
        public NewTaskToWork(string handlerId, long startIn, bool recycle)
        {
            HandlerId = handlerId;
            StartIn = startIn;
            Recycle = recycle;

        }
    }
}
