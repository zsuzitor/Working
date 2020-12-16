using System;
using System.Collections.Generic;
using System.Text;
using Working.Models.BL.Services.Interfaces;

namespace Working.Models.BL.Interfaces
{
    public interface IWorkerFactory
    {
        IWorkerService GetService();
    }
}
