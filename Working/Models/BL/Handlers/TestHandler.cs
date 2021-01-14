using System;
using System.Threading.Tasks;
using Working.Models.BL.Handlers.Interfaces;
using Working.Models.BO.Domain;

namespace Working.Models.BL.Handlers
{
    public class TestHandler : ITaskWorkHandler
    {
        private readonly string _handlerId;

        public TestHandler()
        {
            _handlerId = "test_handler_1";
        }
        public string GetHandlerId()
        {
            return _handlerId;
        }

        public Task<bool> Handle(TaskToWork tsk)
        {
            return Task.FromResult(true);
        }
    }
}
