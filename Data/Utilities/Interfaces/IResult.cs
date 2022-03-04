using System;
using Data.Utilities.ComplexTypes;

namespace Data.Utilities.Interfaces
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Info { get; }
        public Exception Exception { get; }
    }
}
