using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Working.Models.BO.Domain;

namespace Working.Models.BL.Handlers.Interfaces
{
    public interface ITaskWorkHandler
    {
        string GetHandlerId();
        Task<bool> Handle(TaskToWork tsk);
    }
}
