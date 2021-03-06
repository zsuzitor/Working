﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working.Models.BL.Handlers.Interfaces;
using Working.Models.BL.Repositories.Interfaces;
using Working.Models.BL.Services.Interfaces;
using Working.Models.BO;
using Working.Models.BO.Domain;

namespace Working.Models.BL.Services
{
    public class WorkerService : IWorkerService
    {
        private static WorkerService _workerService;
        private static object _init;

        private IWorkerRepository _workerRepository;
        private readonly ConcurrentDictionary<long, TaskToWork> _processTask;

        static WorkerService()
        {
            _init = new object();
        }

        private WorkerService(IWorkerRepository workerRepo)
        {
            _workerRepository = workerRepo;
            _processTask = new ConcurrentDictionary<long, TaskToWork>();
        }

        public static void Init(IWorkerRepository workerRepo)
        {
            if (_workerService != null)
            {
                return;
            }

            lock (_init)
            {
                _workerService = new WorkerService(workerRepo);
            }
        }

        public static IWorkerService GetObject()
        {
            //if (_workerService == null)
            //{
            //    lock (_init)
            //    {
            //        if (_workerService == null)
            //        {
            //            _workerService = new WorkerService(workerRepo);
            //        }
            //    }
            //}

            return _workerService;
        }

        public async Task AddTaskAsync(NewTaskToWork newTask)
        {
            var tsk = new TaskToWork();
            tsk.FillByNewTask(newTask);
            tsk.DateOfCreated = DateTime.Now;
            tsk.Status = TaskToWorkStatus.NotHandling;
            await AddTaskAsync(tsk);
        }

        private async Task AddTaskAsync(TaskToWork newTask)
        {
            await _workerRepository.AddAsync(newTask);
        }


        public async Task StartActualTaskHandleAsync(List<ITaskWorkHandler> handlers)
        {
            if (handlers.Count == 0)
            {
                return;
            }

            var tasksToRun = _workerRepository.GetNotRunnigTasks();//TODO думаю лучше сразу получать то что можно запустить, получитс так? может хранить дату и при добавлении ее высчитывать?
            if (tasksToRun.Count == 0)
            {
                return;
            }

            foreach (var handler in handlers)
            {
                var handlerId = handler.GetHandlerId();
                var tasksForHandler = tasksToRun.Where(x => x.HandlerId == handlerId);
                foreach (var task in tasksForHandler)
                {
                    //TODO тут работа с очередью и потом обновление бд по очереди
                    if (_processTask.ContainsKey(task.Id))
                    {
                        continue;
                    }

                    try
                    {
                        if (task.NeedHandleNow())
                        {
                            if (!_processTask.TryAdd(task.Id, task))
                            {
                                continue;
                            }

                            var taskToSend = task.Clone();
                            await handler.Handle(taskToSend);//TODO надо ли ждать?

                            task.Status = taskToSend.Status;
                            task.DateOfEnd = DateTime.Now;
                            task.ErrorText = taskToSend.ErrorText;
                        }
                    }
                    catch (Exception e)
                    {
                        task.ErrorText = e.Message;
                        task.Status = TaskToWorkStatus.Error;
                    }

                    await _workerRepository.UpdateAsync(task);
                    _processTask.TryRemove(task.Id, out _);

                    if (task.Recycle)
                    {
                        var newTsk = CloneForNewByOld(task);
                        await AddTaskAsync(newTsk);
                    }

                }
            }
        }

        /// <summary>
        /// создать точно такую же задачу, которая будет выполнена потом,
        /// убираем из нее результаты выполнения текущей и тд
        /// </summary>
        /// <param name="tsk"></param>
        /// <returns></returns>
        private TaskToWork CloneForNewByOld(TaskToWork tsk)
        {
            var newTsk = tsk.Clone();
            newTsk.Id = 0;
            newTsk.DateOfCreated = DateTime.Now;
            newTsk.DateOfEnd = null;
            newTsk.ErrorText = null;
            newTsk.Status = TaskToWorkStatus.NotHandling;
            return newTsk;
        }


    }

    //public class TaskToWorkInProgress
    //{

    //}


}
