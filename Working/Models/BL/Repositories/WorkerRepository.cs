
using System.Collections.Generic;
using System.Threading.Tasks;
using Working.Models.BL.Repositories.Interfaces;
using Working.Models.BO.Domain;

namespace Working.Models.BL.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        public Task AddAsync(TaskToWork tsk)
        {
            throw new System.NotImplementedException();
        }

        public List<TaskToWork> GetNotRunnigTasks()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TaskToWork tsk)
        {
            throw new System.NotImplementedException();
        }
    }
}
