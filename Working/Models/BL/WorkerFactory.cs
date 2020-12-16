using System;
using System.Collections.Generic;
using System.Text;
using Working.Models.BL.Interfaces;
using Working.Models.BL.Repositories.Interfaces;
using Working.Models.BL.Services;
using Working.Models.BL.Services.Interfaces;

namespace Working.Models.BL
{
    public class WorkerFactory : IWorkerFactory
    {
        private readonly IWorkerRepository _workerRepo;

        public WorkerFactory(IWorkerRepository workerRepo)
        {
            _workerRepo = workerRepo;
        }
        public IWorkerService GetService()
        {
            WorkerService.Init(_workerRepo);
            return WorkerService.GetObject();
        }
    }
}
