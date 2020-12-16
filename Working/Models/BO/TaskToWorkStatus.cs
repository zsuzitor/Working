using System;
using System.Collections.Generic;
using System.Text;

namespace Working.Models.BO
{
    public enum TaskToWorkStatus
    {
        NotHandling,
        Success,
        Failed,//отправил хенддер
        Error,//хендлер упал
    }
}
