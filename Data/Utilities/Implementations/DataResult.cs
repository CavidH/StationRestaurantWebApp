using System;
using Data.Utilities.ComplexTypes;
using Data.Utilities.Interfaces;

namespace Data.Utilities.Implementations
{
    public class DataResult<Entity> : IDataResult<Entity>
    {
        public DataResult(ResultStatus resultStatus, Entity data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, Entity data, string info)
        {
            ResultStatus = resultStatus;
            Data = data;
            Info = info;
        }
        public DataResult(ResultStatus resultStatus, Entity data, string info, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Info = info;
            Exception = exception;
        }
        public Entity Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Info { get; }
        public Exception Exception { get; }
    }
}
