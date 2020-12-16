


using System.Collections.Generic;
using System.Threading.Tasks;
using Working.Models.BO.Domain;

namespace Working.Models.BL.Services.Interfaces
{
    public interface IWorkerService
    {
        Task AddTaskAsync(TaskToWork tsk);
        Task StartActualTaskHandleAsync(List<ITaskWorkHandler> handlers);
        void Stop();
        void Up();
    }
}
