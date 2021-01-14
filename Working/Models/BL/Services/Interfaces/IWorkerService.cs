


using System.Collections.Generic;
using System.Threading.Tasks;
using Working.Models.BL.Handlers.Interfaces;
using Working.Models.BO;

namespace Working.Models.BL.Services.Interfaces
{
    public interface IWorkerService
    {
        Task AddTaskAsync(NewTaskToWork tsk);
        Task StartActualTaskHandleAsync(List<ITaskWorkHandler> handlers);
        //void Stop();
        //void Up();
    }
}
