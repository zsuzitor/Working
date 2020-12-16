using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Working.Models.BO;
using Working.Models.BO.Domain;

namespace Working.Models.BL.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        Task AddAsync(TaskToWork tsk);
        Task UpdateAsync(TaskToWork tsk);
        List<TaskToWork> GetNotRunnigTasks();
    }
}
