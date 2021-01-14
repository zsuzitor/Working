using System;
using System.Collections.Generic;
using System.Text;

namespace Working.Models.BO.Domain
{
    public class TaskToWork : ICloneable
    {
        public long Id { get; set; }
        public string HandlerId { get; set; }
        public DateTime DateOfCreated { get; set; }
        public long StartIn { get; set; }//second
        public bool Recycle { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public TaskToWorkStatus Status { get; set; }

        public string ErrorText { get; set; }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        public void FillByNewTask(NewTaskToWork newTask)
        {
            this.HandlerId = newTask.HandlerId;
            //this.DateOfCreated = newTask.DateOfCreated;
            this.StartIn = newTask.StartIn;
            this.Recycle = newTask.Recycle;
        }

        public TaskToWork Clone()
        {
            return (TaskToWork)Clone();
        }

        public bool NeedHandleNow()
        {
            return DateOfCreated.AddSeconds(StartIn) >= DateTime.Now;
        }
    }
}
